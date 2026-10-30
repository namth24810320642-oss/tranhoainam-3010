using System.Data;
using Microsoft.Data.SqlClient;

namespace HotelDB.DAL
{
    public class PhongDAL : DatabaseAccess
    {
        public DataTable GetAllPhong()
        {
            return ExecuteQueryDataTable("SELECT * FROM phong");
        }

        public bool UpdateTrangThai(string soPhong, string trangThai)
        {
            string query = "UPDATE phong SET trangthai = @TrangThai WHERE sophong = @SoPhong";
            SqlParameter[] param = {
                new SqlParameter("@TrangThai", trangThai),
                new SqlParameter("@SoPhong", soPhong)
            };
            return ExecuteNonQuery(query, param) > 0;
        }
    }
}