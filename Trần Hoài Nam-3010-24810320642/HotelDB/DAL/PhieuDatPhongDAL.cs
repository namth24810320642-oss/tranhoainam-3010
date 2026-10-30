using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace HotelDB.DAL
{
    public class PhieuDatPhongDAL : DatabaseAccess
    {
        public int GetActivePhieuByRoom(string soPhong)
        {
            string query = "SELECT maphieu FROM phieudatphong WHERE sophong = @SoPhong AND ngaytraphong IS NULL";
            SqlParameter[] param = { new SqlParameter("@SoPhong", soPhong) };
            DataTable dt = ExecuteQueryDataTable(query, param);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["maphieu"]) : -1;
        }

        public bool CheckIn(string soPhong, int maKH)
        {
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlTransaction trans = conn.BeginTransaction();
            try
            {
                string sqlPhieu = "INSERT INTO phieudatphong (sophong, makh, ngaynhanphong) VALUES (@SoPhong, @MaKH, GETDATE())";
                using SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, conn, trans);
                cmdPhieu.Parameters.AddWithValue("@SoPhong", soPhong);
                cmdPhieu.Parameters.AddWithValue("@MaKH", maKH);
                cmdPhieu.ExecuteNonQuery();

                string sqlPhong = "UPDATE phong SET trangthai = N'Đang ở' WHERE sophong = @SoPhong";
                using SqlCommand cmdPhong = new SqlCommand(sqlPhong, conn, trans);
                cmdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                cmdPhong.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
        }

        public bool AddService(int maPhieu, int maDV, int soLuong)
        {
            string query = "INSERT INTO sudungdichvu (maphieu, madv, soluong, thoigian) VALUES (@MaPhieu, @MaDV, @SoLuong, GETDATE())";
            SqlParameter[] param = {
                new SqlParameter("@MaPhieu", maPhieu),
                new SqlParameter("@MaDV", maDV),
                new SqlParameter("@SoLuong", soLuong)
            };
            return ExecuteNonQuery(query, param) > 0;
        }

        public DataTable GetSuDungDichVuByPhieu(int maPhieu)
        {
            string query = @"SELECT d.tendv AS TenDV, s.soluong AS SoLuong, d.dongia AS DonGia, (s.soluong * d.dongia) AS ThanhTien, s.thoigian AS ThoiGian
                            FROM sudungdichvu s JOIN dichvu d ON s.madv = d.madv WHERE s.maphieu = @MaPhieu";
            SqlParameter[] param = { new SqlParameter("@MaPhieu", maPhieu) };
            return ExecuteQueryDataTable(query, param);
        }

        public bool CheckOut(int maPhieu, string soPhong, decimal giaTheoGio, out decimal tongTienOut)
        {
            tongTienOut = 0;
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlTransaction trans = conn.BeginTransaction();
            try
            {
                // 1. Lấy thời gian nhận phòng
                string sqlTime = "SELECT ngaynhanphong FROM phieudatphong WHERE maphieu = @MaPhieu";
                using SqlCommand cmdTime = new SqlCommand(sqlTime, conn, trans);
                cmdTime.Parameters.AddWithValue("@MaPhieu", maPhieu);
                object resTime = cmdTime.ExecuteScalar();

                if (resTime == null || resTime == DBNull.Value)
                {
                    trans.Rollback();
                    return false;
                }

                DateTime ngayNhan = Convert.ToDateTime(resTime);
                double soGio = Math.Ceiling((DateTime.Now - ngayNhan).TotalHours);
                if (soGio < 1) soGio = 1;
                decimal tienPhong = (decimal)soGio * giaTheoGio;

                // 2. Tính tiền dịch vụ (SỬA Ở ĐÂY: Tránh lỗi DBNull)
                string sqlDV = "SELECT SUM(s.soluong * d.dongia) FROM sudungdichvu s JOIN dichvu d ON s.madv = d.madv WHERE s.maphieu = @MaPhieu";
                using SqlCommand cmdDV = new SqlCommand(sqlDV, conn, trans);
                cmdDV.Parameters.AddWithValue("@MaPhieu", maPhieu);
                object resDV = cmdDV.ExecuteScalar();

                // Nếu phòng chưa dùng dịch vụ nào (resDV là DBNull), gán bằng 0
                decimal tienDV = (resDV != null && resDV != DBNull.Value) ? Convert.ToDecimal(resDV) : 0;

                tongTienOut = tienPhong + tienDV;

                // 3. Cập nhật phiếu đặt phòng
                string sqlPhieu = "UPDATE phieudatphong SET ngaytraphong = GETDATE(), tongtienthanhtoan = @TongTien WHERE maphieu = @MaPhieu";
                using SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, conn, trans);
                cmdPhieu.Parameters.AddWithValue("@TongTien", tongTienOut);
                cmdPhieu.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmdPhieu.ExecuteNonQuery();

                // 4. Chuyển trạng thái phòng sang 'Đang dọn dẹp'
                string sqlPhong = "UPDATE phong SET trangthai = N'Đang dọn dẹp' WHERE sophong = @SoPhong";
                using SqlCommand cmdPhong = new SqlCommand(sqlPhong, conn, trans);
                cmdPhong.Parameters.AddWithValue("@SoPhong", soPhong);
                cmdPhong.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch
            {
                trans.Rollback();
                return false;
            }
        }
    }
}
