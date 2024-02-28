using Azure;
using MarketPlaceLibrary.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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

        public static async Task<(int?, int?)> TryUserLogin(string userLogin, string password)
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
                        }
                    );

                await sqlCommand.ExecuteNonQueryAsync();

                if (sqlCommand.Parameters["@USER_ID"].Value != DBNull.Value && sqlCommand.Parameters["@USER_LEVEL"].Value != DBNull.Value)
                {
                    int userId = (int)sqlCommand.Parameters["@USER_ID"].Value;
                    int permissionsLevel = (int)sqlCommand.Parameters["@USER_LEVEL"].Value;
                    return (userId, permissionsLevel);
                }

                return (null, null);

            }
        }
        public static async Task<List<MarketItem>> GetMarketItems(
            int pageNo, int pageCount, int ownerId, byte? itemCategory = null, int? highestBidder = null,
            bool filterByOwnerId = false, bool orderByPriceAsc = false, bool orderByPriceDesc = false,
            bool orderByDateAsc = false, bool orderByDateDesc = false
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
                    new SqlParameter("@OWNER_ID", ownerId),
                    new SqlParameter("@HIGHEST_BIDDER", highestBidder),
                    new SqlParameter("@FILTER_BY_OWNER_ID", filterByOwnerId),
                    new SqlParameter("@ORDER_BY_PRICE_ASC", orderByPriceAsc),
                    new SqlParameter("@ORDER_BY_PRICE_DESC", orderByPriceDesc),
                    new SqlParameter("@ORDER_BY_DATE_ASC", orderByDateAsc),
                    new SqlParameter("@ORDER_BY_DATE_DESC", orderByDateDesc)
                    );

                SqlDataReader result = await sqlCommand.ExecuteReaderAsync();

                while (await result.ReadAsync())
                {
                    var r = result.GetInt32("ID");
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
                            }
                        ); ;
                }
            }

            return marketItems;

        }

        public static async Task<int> OrderAdd(int userId, int itemId)
        {
            int orderId = 0;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.ORDER_ADD",
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

        // For tests only
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

        // For tests only
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


    }
}
