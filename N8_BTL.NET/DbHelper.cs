using System.Data.SqlClient;

namespace KaraokeManager
{
    public class DbHelper
    {
        private readonly string connectionString;

        public DbHelper()
        {
            connectionString = @"Data Source= HAI412\SQLEXPRESS;Initial Catalog=KaraokeDb;Integrated Security=True";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}