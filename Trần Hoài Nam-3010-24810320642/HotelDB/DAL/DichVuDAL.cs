using System.Data;

namespace HotelDB.DAL
{
    public class DichVuDAL : DatabaseAccess
    {
        public DataTable GetAllDichVu()
        {
            return ExecuteQueryDataTable("SELECT * FROM dichvu");
        }
    }
}