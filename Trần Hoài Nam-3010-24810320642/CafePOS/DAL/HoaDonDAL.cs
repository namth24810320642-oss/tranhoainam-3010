using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CafePOS.DAL
{
    public class HoaDonDAL : DatabaseAccess
    {
        public int GetUnpaidBillIdByTable(int maBan)
        {
            string query = "SELECT mahoadon FROM hoadon WHERE maban = @MaBan AND trangthai = 0";
            SqlParameter[] param = { new SqlParameter("@MaBan", maBan) };
            DataTable dt = ExecuteQueryDataTable(query, param);
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["mahoadon"]);
            return -1;
        }

        public int GetUnpaidBillIdByTable(int maBan, SqlConnection conn, SqlTransaction trans)
        {
            string query = "SELECT mahoadon FROM hoadon WHERE maban = @MaBan AND trangthai = 0";
            using SqlCommand cmd = new SqlCommand(query, conn, trans);
            cmd.Parameters.AddWithValue("@MaBan", maBan);
            object? res = cmd.ExecuteScalar();
            return res != null ? Convert.ToInt32(res) : -1;
        }

        public DataTable GetBillDetails(int maHoaDon)
        {
            string query = @"SELECT m.tenmon AS TenMon, c.soluong AS SoLuong, c.dongia AS DonGia, (c.soluong * c.dongia) AS ThanhTien 
                            FROM chitiethoadon c 
                            JOIN monan m ON c.mamon = m.mamon 
                            WHERE c.mahoadon = @MaHD";
            SqlParameter[] param = { new SqlParameter("@MaHD", maHoaDon) };
            return ExecuteQueryDataTable(query, param);
        }

        public bool AddOrder(int maBan, int maMon, int soLuong, decimal donGia)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                int maHoaDon = GetUnpaidBillIdByTable(maBan, conn, transaction);

                if (maHoaDon == -1)
                {
                    string insertHD = "INSERT INTO hoadon (maban, giovao, trangthai) VALUES (@MaBan, GETDATE(), 0); SELECT SCOPE_IDENTITY();";
                    using SqlCommand cmdHD = new SqlCommand(insertHD, conn, transaction);
                    cmdHD.Parameters.AddWithValue("@MaBan", maBan);
                    maHoaDon = Convert.ToInt32(cmdHD.ExecuteScalar());

                    string updateBan = "UPDATE banan SET trangthai = N'Có khách' WHERE maban = @MaBan";
                    using SqlCommand cmdBan = new SqlCommand(updateBan, conn, transaction);
                    cmdBan.Parameters.AddWithValue("@MaBan", maBan);
                    cmdBan.ExecuteNonQuery();
                }

                string checkCT = "SELECT soluong FROM chitiethoadon WHERE mahoadon = @MaHD AND mamon = @MaMon";
                using SqlCommand cmdCheck = new SqlCommand(checkCT, conn, transaction);
                cmdCheck.Parameters.AddWithValue("@MaHD", maHoaDon);
                cmdCheck.Parameters.AddWithValue("@MaMon", maMon);
                object? result = cmdCheck.ExecuteScalar();

                if (result != null)
                {
                    string updateCT = "UPDATE chitiethoadon SET soluong = soluong + @SoLuong WHERE mahoadon = @MaHD AND mamon = @MaMon";
                    using SqlCommand cmdUpdateCT = new SqlCommand(updateCT, conn, transaction);
                    cmdUpdateCT.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdUpdateCT.Parameters.AddWithValue("@MaHD", maHoaDon);
                    cmdUpdateCT.Parameters.AddWithValue("@MaMon", maMon);
                    cmdUpdateCT.ExecuteNonQuery();
                }
                else
                {
                    string insertCT = "INSERT INTO chitiethoadon (mahoadon, mamon, soluong, dongia) VALUES (@MaHD, @MaMon, @SoLuong, @DonGia)";
                    using SqlCommand cmdInsertCT = new SqlCommand(insertCT, conn, transaction);
                    cmdInsertCT.Parameters.AddWithValue("@MaHD", maHoaDon);
                    cmdInsertCT.Parameters.AddWithValue("@MaMon", maMon);
                    cmdInsertCT.Parameters.AddWithValue("@SoLuong", soLuong);
                    cmdInsertCT.Parameters.AddWithValue("@DonGia", donGia);
                    cmdInsertCT.ExecuteNonQuery();
                }

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }

        public bool Checkout(int maHoaDon, int maBan, decimal tongTien)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                string updateHD = "UPDATE hoadon SET giora = GETDATE(), tongtien = @TongTien, trangthai = 1 WHERE mahoadon = @MaHD";
                using SqlCommand cmdHD = new SqlCommand(updateHD, conn, transaction);
                cmdHD.Parameters.AddWithValue("@TongTien", tongTien);
                cmdHD.Parameters.AddWithValue("@MaHD", maHoaDon);
                cmdHD.ExecuteNonQuery();

                string updateBan = "UPDATE banan SET trangthai = N'Trống' WHERE maban = @MaBan";
                using SqlCommand cmdBan = new SqlCommand(updateBan, conn, transaction);
                cmdBan.Parameters.AddWithValue("@MaBan", maBan);
                cmdBan.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                return false;
            }
        }
    }
}