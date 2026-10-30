using System.Data;
using Microsoft.Data.SqlClient; // Dùng thư viện mới nhất để không bị Obsolete warning

namespace CafePOS.DAL
{
    public class DatabaseAccess
    {
        protected static readonly string connectionString = @"Data Source=.;Initial Catalog=CafePOSDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static DataTable ExecuteQueryDataTable(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection conn = GetConnection();
            using SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
            if (parameters != null)
            {
                adapter.SelectCommand.Parameters.AddRange(parameters);
            }
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[]? parameters = null)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlCommand cmd = new SqlCommand(query, conn);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            return cmd.ExecuteNonQuery();
        }
    }
}