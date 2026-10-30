using System.Data;
using Microsoft.Data.SqlClient;
using InventoryDB.DTO;

namespace InventoryDB.DAL
{
    public class HangHoaDAL : DatabaseAccess
    {
        public DataTable GetAllHangHoa()
        {
            return ExecuteQueryDataTable("SELECT * FROM hanghoa");
        }

        public bool InsertHangHoa(HangHoaDTO hang)
        {
            string query = "INSERT INTO hanghoa (tenhang, donvitinh, soluongton, dongianhap, dongiaxuat) VALUES (@Ten, @DVT, @SL, @GiaNhap, @GiaXuat)";
            SqlParameter[] param = {
                new SqlParameter("@Ten", hang.TenHang),
                new SqlParameter("@DVT", hang.DonViTinh),
                new SqlParameter("@SL", hang.SoLuongTon),
                new SqlParameter("@GiaNhap", hang.DonGiaNhap),
                new SqlParameter("@GiaXuat", hang.DonGiaXuat)
            };
            return ExecuteNonQuery(query, param) > 0;
        }

        public bool UpdateHangHoa(HangHoaDTO hang)
        {
            string query = "UPDATE hanghoa SET tenhang = @Ten, donvitinh = @DVT, dongianhap = @GiaNhap, dongiaxuat = @GiaXuat WHERE mahang = @Ma";
            SqlParameter[] param = {
                new SqlParameter("@Ten", hang.TenHang),
                new SqlParameter("@DVT", hang.DonViTinh),
                new SqlParameter("@GiaNhap", hang.DonGiaNhap),
                new SqlParameter("@GiaXuat", hang.DonGiaXuat),
                new SqlParameter("@Ma", hang.MaHang)
            };
            return ExecuteNonQuery(query, param) > 0;
        }
    }
}