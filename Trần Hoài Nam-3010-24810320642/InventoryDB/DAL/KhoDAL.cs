using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace InventoryDB.DAL
{
    public class KhoDAL : DatabaseAccess
    {
        // Thực hiện Tạo Phiếu + Chi Tiết Phiếu + Cập Nhật Tồn Kho dùng SqlTransaction
        public bool TaoPhieuKho(string loaiPhieu, string ghiChu, int maHang, int soLuong, decimal donGia, out string errorMessage)
        {
            errorMessage = string.Empty;
            using SqlConnection conn = GetConnection();
            conn.Open();
            using SqlTransaction trans = conn.BeginTransaction();
            try
            {
                // 1. Kiểm tra tồn kho nếu là phiếu XUẤT
                if (loaiPhieu == "XUẤT")
                {
                    string sqlCheckTon = "SELECT soluongton FROM hanghoa WHERE mahang = @MaHang";
                    using SqlCommand cmdCheck = new SqlCommand(sqlCheckTon, conn, trans);
                    cmdCheck.Parameters.AddWithValue("@MaHang", maHang);
                    object? resTon = cmdCheck.ExecuteScalar();
                    int tonHienTai = (resTon != null && resTon != DBNull.Value) ? Convert.ToInt32(resTon) : 0;

                    if (tonHienTai < soLuong)
                    {
                        errorMessage = $"Số lượng tồn kho không đủ! (Hiện còn: {tonHienTai})";
                        trans.Rollback();
                        return false;
                    }
                }

                // 2. Tạo Phiếu Xuất/Nhập
                string sqlPhieu = "INSERT INTO phieuxuatnhap (loaiphieu, ngaylap, ghichu) VALUES (@Loai, GETDATE(), @GhiChu); SELECT SCOPE_IDENTITY();";
                using SqlCommand cmdPhieu = new SqlCommand(sqlPhieu, conn, trans);
                cmdPhieu.Parameters.AddWithValue("@Loai", loaiPhieu);
                cmdPhieu.Parameters.AddWithValue("@GhiChu", ghiChu);
                int maPhieu = Convert.ToInt32(cmdPhieu.ExecuteScalar());

                // 3. Thêm Chi Tiết Phiếu
                string sqlChiTiet = "INSERT INTO chitietphieu (maphieu, mahang, soluong, dongia) VALUES (@MaPhieu, @MaHang, @SoLuong, @DonGia)";
                using SqlCommand cmdChiTiet = new SqlCommand(sqlChiTiet, conn, trans);
                cmdChiTiet.Parameters.AddWithValue("@MaPhieu", maPhieu);
                cmdChiTiet.Parameters.AddWithValue("@MaHang", maHang);
                cmdChiTiet.Parameters.AddWithValue("@SoLuong", soLuong);
                cmdChiTiet.Parameters.AddWithValue("@DonGia", donGia);
                cmdChiTiet.ExecuteNonQuery();

                // 4. Cập nhật Số Lượng Tồn Kho trong bảng HangHoa
                string sqlUpdateTon = (loaiPhieu == "NHẬP")
                    ? "UPDATE hanghoa SET soluongton = soluongton + @SoLuong WHERE mahang = @MaHang"
                    : "UPDATE hanghoa SET soluongton = soluongton - @SoLuong WHERE mahang = @MaHang";

                using SqlCommand cmdUpdate = new SqlCommand(sqlUpdateTon, conn, trans);
                cmdUpdate.Parameters.AddWithValue("@SoLuong", soLuong);
                cmdUpdate.Parameters.AddWithValue("@MaHang", maHang);
                cmdUpdate.ExecuteNonQuery();

                trans.Commit();
                return true;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                errorMessage = ex.Message;
                return false;
            }
        }

        public DataTable GetLichSuXuatNhap()
        {
            string query = @"SELECT p.maphieu AS MaPhieu, p.loaiphieu AS LoaiPhieu, p.ngaylap AS NgayLap,
                                   h.tenhang AS TenHang, c.soluong AS SoLuong, c.dongia AS DonGia, 
                                   (c.soluong * c.dongia) AS TongTien, p.ghichu AS GhiChu
                            FROM phieuxuatnhap p
                            JOIN chitietphieu c ON p.maphieu = c.maphieu
                            JOIN hanghoa h ON c.mahang = h.mahang
                            ORDER BY p.ngaylap DESC";
            return ExecuteQueryDataTable(query);
        }
    }
}