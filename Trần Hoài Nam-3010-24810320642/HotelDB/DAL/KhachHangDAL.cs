using System;
using System.Data;
using Microsoft.Data.SqlClient;
using HotelDB.DTO;

namespace HotelDB.DAL
{
    public class KhachHangDAL : DatabaseAccess
    {
        public KhachHangDTO? GetKhachHangByCCCD(string cccd)
        {
            string query = "SELECT * FROM khachhang WHERE cccd = @CCCD";
            SqlParameter[] param = { new SqlParameter("@CCCD", cccd) };
            DataTable dt = ExecuteQueryDataTable(query, param);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                return new KhachHangDTO
                {
                    MaKH = Convert.ToInt32(row["makh"]),
                    HoTen = row["hoten"]?.ToString() ?? "",
                    CCCD = row["cccd"]?.ToString() ?? "",
                    SoDienThoai = row["sodienthoai"]?.ToString() ?? ""
                };
            }
            return null;
        }

        public int InsertKhachHang(KhachHangDTO kh)
        {
            string query = "INSERT INTO khachhang (hoten, cccd, sodienthoai) VALUES (@HoTen, @CCCD, @SDT); SELECT SCOPE_IDENTITY();";
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@HoTen", kh.HoTen);
            cmd.Parameters.AddWithValue("@CCCD", kh.CCCD);
            cmd.Parameters.AddWithValue("@SDT", kh.SoDienThoai);
            return Convert.ToInt32(cmd.ExecuteScalar());
        }
    }
}