using System.Data;

namespace CafePOS.DAL
{
    public class BanAnDAL : DatabaseAccess
    {
        public DataTable GetAllBanAn()
        {
            string query = "SELECT * FROM banan";
            return ExecuteQueryDataTable(query);
        }
    }
}