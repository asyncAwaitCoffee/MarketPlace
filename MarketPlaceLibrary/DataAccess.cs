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
                                    result.GetDecimal("START_PRICE"),
                                    result.GetByte("ITEM_CATEGORY"),
                                    result.GetDateTime("DATE_START"),
                                    result.GetInt32("OWNER_ID")
                                )
                            {
                                Description = result.GetString("ITEM_DESCRIPTION")
                            }
                        ); ;
                }
            }

            return marketItems;

        }

        // For tests only
        public static async void SaveImageToDatabase(string imagePath)
        {
            byte[] imageData;
            using (FileStream fs = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
            {
                imageData = new byte[fs.Length];
                fs.Read(imageData, 0, (int)fs.Length);
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO MARKET_PLACE.IMAGES (IMAGE_BINARY) VALUES (@IMAGE_BINARY)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.Add("@IMAGE_BINARY", SqlDbType.VarBinary, -1).Value = imageData;

                await connection.OpenAsync();
                command.ExecuteNonQuery();
            }
        }

        // For tests only
        public static async Task<byte[]> RetrieveImageFromDatabase(int imageId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // TODO - remove, imitates long load
                Random random = new Random();
                int x = random.Next(0, 4);

                string query = $"WAITFOR DELAY '00:00:0{x}'; SELECT IMAGE_BINARY FROM MARKET_PLACE.IMAGES WHERE ID = @IMAGE_ID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IMAGE_ID", imageId);

                await connection.OpenAsync();
                byte[] imageData = (byte[])command.ExecuteScalar();

                return imageData;
            }
                
        }


    }
}
