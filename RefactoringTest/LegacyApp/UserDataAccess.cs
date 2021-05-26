using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LegacyApp
{
    public static class UserDataAccess
    {
        public static void AddUser(User usuer) 
        {
            var connectionString = ConfigurationManager.ConnectionStrings["appDataBase"].ConnectionString;
            using (var connection = new SqlConnection(connectionString)) 
            {
                var command = new SqlCommand
                {
                    Connection = connection,
                    CommandType = System.Data.CommandType.StoredProcedure,
                    CommandText = "uspAddUser"
                };
            }
        }
    }
}
