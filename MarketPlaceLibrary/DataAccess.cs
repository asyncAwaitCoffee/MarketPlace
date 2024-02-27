using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static async Task<int> SaveUserToDB(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                byte[] data = Encoding.UTF8.GetBytes(password);
                data = System.Security.Cryptography.SHA256.HashData(data);
                string encryptedPassword = Encoding.UTF8.GetString(data);

                SqlCommand sqlCommand = await CreateSqlCommand(
                    connection,
                    "MARKET_PLACE.USER_REGISTRATION",
                    new SqlParameter("@USER_LOGIN", username),
                    new SqlParameter("@USER_PASSWORD", encryptedPassword)
                    );
                
                
                await sqlCommand.ExecuteNonQueryAsync();
            }

            return 1;
        }
    }
}
