using MarketPlaceLibrary.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;

namespace MarketPlaceLibrary
{
    public static class DataAccess
    {
        private static readonly string connectionString = "Server=MSI;Database=COURSES_DB;Trusted_Connection=True;TrustServerCertificate=True;";

        private static async Task<SqlCommand> CreateSqlCommand(SqlConnection connection, string command, params SqlParameter[] sqlParameters)
        {
            await connection.OpenAsync();
            SqlCommand sqlCommand = connection.CreateCommand();

            sqlCommand.Parameters.AddRange(sqlParameters);

            sqlCommand.CommandText = command;
            sqlCommand.CommandType = CommandType.StoredProcedure;

            return sqlCommand;
        }

        public static async Task<int> SaveUserToDB(string userLogin, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                byte[] data = Encoding.UTF8.GetBytes(password);
                data = System.Security.Cryptography.SHA256.HashData(data);
                string encryptedPassword = Encoding.UTF8.GetString(data);

                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.USER_REGISTRATION",
                    new SqlParameter("@USER_LOGIN", userLogin),
                    new SqlParameter("@USER_PASSWORD", encryptedPassword)
                    );
                
                
                await sqlCommand.ExecuteNonQueryAsync();
            }

            return 1;
        }

        public static async Task<byte> UpdateUserPersonData(int userId, string personName, string email, int? countryId = null, int? cityId = null)
        {
            byte result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.USER_PERSON_DATA_UPDATE",
                    new SqlParameter("@USER_ID", userId),
                    new SqlParameter("@PERSON_NAME", personName),
                    new SqlParameter("@EMAIL", email),
                    new SqlParameter("@COUNTRY_ID", countryId),
                    new SqlParameter("@CITY_ID", cityId)
                    );


                await sqlCommand.ExecuteNonQueryAsync();

                result = 1;
            }

            return result;
        }

        public static async Task<Person?> GetUserPersonData(int userId)
        {
            Person? person = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.USER_PERSON_DATA_GET",
                    new SqlParameter("@USER_ID", userId)
                    );


                SqlDataReader result = await sqlCommand.ExecuteReaderAsync();

                while (await result.ReadAsync())
                {
                    person = new Person(userId)
                    {
                        Name = result.IsDBNull(result.GetOrdinal("PERSON_NAME")) ? null : result.GetString("PERSON_NAME"),
                        Email = result.IsDBNull(result.GetOrdinal("EMAIL")) ? null : result.GetString("EMAIL"),
                    };
                }
            }

            return person;
        }

        public static async Task<(int?, int?, decimal?)> TryUserLogin(string userLogin, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                byte[] data = Encoding.UTF8.GetBytes(password);
                data = System.Security.Cryptography.SHA256.HashData(data);
                string cryptedPassword = Encoding.UTF8.GetString(data);

                SqlCommand sqlCommand = await CreateSqlCommand(
                        connection,
                        "MARKET_PLACE.USER_AUTHORIZATION",
                        new SqlParameter("@USER_LOGIN", userLogin),
                        new SqlParameter("@USER_PASSWORD", cryptedPassword),
                        new SqlParameter
                        {
                            ParameterName = "@USER_ID",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        },
                        new SqlParameter
                        {
                            ParameterName = "@USER_LEVEL",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        },
                        new SqlParameter
                        {
                            ParameterName = "@BALANCE",
                            SqlDbType = SqlDbType.Decimal,
                            Direction = ParameterDirection.Output
                        }
                    );

                await sqlCommand.ExecuteNonQueryAsync();

                if (sqlCommand.Parameters["@USER_ID"].Value != DBNull.Value
                    && sqlCommand.Parameters["@USER_LEVEL"].Value != DBNull.Value
                    && sqlCommand.Parameters["@BALANCE"].Value != DBNull.Value)
                {
                    int userId = (int)sqlCommand.Parameters["@USER_ID"].Value;
                    int permissionsLevel = (int)sqlCommand.Parameters["@USER_LEVEL"].Value;
                    decimal balance = (decimal)sqlCommand.Parameters["@BALANCE"].Value;

                    return (userId, permissionsLevel, balance);
                }

                return (null, null, null);

            }
        }

        public static async Task<decimal> GetUserBalance(int userId)
        {
            decimal balance = 0M;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.USER_BALANCE_GET",
                    new SqlParameter("@USER_ID", userId),
                    new SqlParameter
                    {
                        ParameterName = "@BALANCE",
                        SqlDbType = SqlDbType.Decimal,
                        Direction = ParameterDirection.Output
                    }
                    );

                await sqlCommand.ExecuteNonQueryAsync();

                if (sqlCommand.Parameters["@BALANCE"].Value != DBNull.Value)
                {
                    balance = (decimal)sqlCommand.Parameters["@BALANCE"].Value;
                }

            }

            return balance;
        }

        public static async Task<List<MarketItem>> GetMarketItems(
            int pageNo, int pageCount, int userId, byte? itemCategory = null, int? highestBidder = null,
            bool filterByOwnerId = false, int? orderByPrice = null, int? orderByDate = null
            )
        {
            List<MarketItem> marketItems = new List<MarketItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.ITEMS_GET_BY_PAGE_WITH_FILTER",
                    new SqlParameter("@PAGE_NO", pageNo),
                    new SqlParameter("@PAGE_COUNT", pageCount),
                    new SqlParameter("@ITEM_CATEGORY", itemCategory),
                    new SqlParameter("@MARKET_USER_ID", userId),
                    new SqlParameter("@FILTER_BY_HIGHEST_BIDDER", highestBidder),
                    new SqlParameter("@FILTER_BY_OWNER_ID", filterByOwnerId),
                    new SqlParameter("@ORDER_BY_PRICE", orderByPrice),
                    new SqlParameter("@ORDER_BY_DATE", orderByDate)
                    );

                SqlDataReader result = await sqlCommand.ExecuteReaderAsync();

                while (await result.ReadAsync())
                {
                    marketItems.Add(
                            new MarketItem(
                                    result.GetInt32("ID"),
                                    result.GetString("TITLE"),
                                    Math.Round(result.GetDecimal("START_PRICE"), 2),
                                    result.GetByte("ITEM_CATEGORY"),
                                    result.GetDateTime("DATE_START"),
                                    result.GetInt32("OWNER_ID")
                                )
                            {
                                Description = result.GetString("ITEM_DESCRIPTION"),
                                BidStep = result.IsDBNull(result.GetOrdinal("BID_STEP")) ? 0 : result.GetDecimal("BID_STEP"),
                                PriceCurrent = result.IsDBNull(result.GetOrdinal("CURRENT_PRICE")) ? 0 : result.GetDecimal("CURRENT_PRICE"),
                            }
                        ); ;
                }
            }

            return marketItems;

        }

        public static async Task<int> AddItemToOrder(int userId, int itemId)
        {
            int orderId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.ITEM_ADD_TO_ORDER",
                    new SqlParameter("@USER_ID", userId),
                    new SqlParameter("@ITEM_ID", itemId),
                    new SqlParameter
                    {
                        ParameterName = "@ORDER_ID",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    }
                    );

                await sqlCommand.ExecuteNonQueryAsync();

                if (sqlCommand.Parameters["@ORDER_ID"].Value != DBNull.Value)
                {
                    orderId = (int)sqlCommand.Parameters["@ORDER_ID"].Value;
                }

            }

            return orderId;
        }

        public static async Task<int> AddItemToMarket(
            int ownerId, string title, string description, byte categoryId,
            decimal priceStart, decimal? priceEnd = null, decimal? bidStep = null,
            DateTime? dateEnd = null)

        {
            int itemId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.ITEM_ADD_TO_MARKET",
                    new SqlParameter("@TITLE", title),
                    new SqlParameter("@ITEM_DESCRIPTION", description),
                    new SqlParameter("@ITEM_CATEGORY", categoryId),
                    new SqlParameter("@PRICE_START", priceStart),
                    new SqlParameter("@PRICE_END", priceEnd),
                    new SqlParameter("@BID_STEP", bidStep),
                    new SqlParameter("@DATE_END", dateEnd),
                    new SqlParameter("@OWNER_ID", ownerId),
                    new SqlParameter
                    {
                        ParameterName = "@ITEM_ID",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    }
                    );

                await sqlCommand.ExecuteNonQueryAsync();

                if (sqlCommand.Parameters["@ITEM_ID"].Value != DBNull.Value)
                {
                    itemId = (int)sqlCommand.Parameters["@ITEM_ID"].Value;
                }

            }

            return itemId;
        }

        public static async Task<int> BidItem(int userId, int itemId)
        {
            int bidResult = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.ITEM_BID",
                    new SqlParameter("@USER_ID", userId),
                    new SqlParameter("@ITEM_ID", itemId),
                    new SqlParameter
                    {
                        ParameterName = "@BID_RESULT",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    }
                    );

                await sqlCommand.ExecuteNonQueryAsync();

                if (sqlCommand.Parameters["@BID_RESULT"].Value != DBNull.Value)
                {
                    bidResult = (int)sqlCommand.Parameters["@BID_RESULT"].Value;
                }

            }

            return bidResult;
        }

        // TODO - For tests only ??
        public static async Task<int> SaveImageToDatabase(int itemId, string imagePath)
        {
            byte[] imageData;
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, (int)fs.Length);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.ITEM_IMAGE_ADD",
                    new SqlParameter("@ITEM_ID", itemId),
                    new SqlParameter("@IMAGE_BINARY", imageData)
                    );


                await sqlCommand.ExecuteNonQueryAsync();
            }

            return 1;
        }

        // TODO - For tests only
        public static async Task<byte[]> RetrieveImageFromDatabase(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.ITEM_IMAGE_GET",
                    new SqlParameter("@ITEM_ID", itemId)
                    );

                byte[] imageData = (byte[])sqlCommand.ExecuteScalar();

                return imageData;
            }
                
        }

        public static async Task<byte> SaveHistory(int userId, int partnerId, int itemId, int operationType, decimal cost)
        {
            byte result = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.HISTORY_SAVE",
                    new SqlParameter("@MARKET_USER_ID", userId),
                    new SqlParameter("@MARKET_PARTNER_ID", partnerId),
                    new SqlParameter("@MARKET_ITEM_ID", itemId),
                    new SqlParameter("@OPERATION_TYPE", operationType),
                    new SqlParameter("@COST", cost)
                    );


                await sqlCommand.ExecuteNonQueryAsync();
                result = 1;
            }

            return result;
        }

        public static async Task<List<HistoryItem>> GetHsitory(int userId)
        {
            List<HistoryItem> historyItems = new List<HistoryItem>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.HISTORY_GET",
                    new SqlParameter("@MARKET_USER_ID", userId)
                    );

                SqlDataReader result = await sqlCommand.ExecuteReaderAsync();

                while (await result.ReadAsync())
                {
                    historyItems.Add(
                            new HistoryItem(
                                    result.GetInt32("MARKET_USER_ID"),
                                    result.GetInt32("MARKET_PARTNER_ID"),
                                    result.GetInt32("MARKET_ITEM_ID"),
                                    (int)result.GetByte("OPERATION_TYPE"),
                                    Math.Round(result.GetDecimal("COST"), 2),
                                    result.GetDateTime("HISTORY_DATE")
                                )
                            {
                                OrderState = result.IsDBNull(result.GetOrdinal("ORDER_STATE")) ? (byte)0 : result.GetByte("ORDER_STATE")
                            }
                        );
                }
            }

            return historyItems;

        }
    }
}
