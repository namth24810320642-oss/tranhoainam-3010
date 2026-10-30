using System.Data;
using InventoryDB.DAL;

namespace InventoryDB.BUS
{
    public class KhoBUS
    {
        private readonly KhoDAL khoDAL = new KhoDAL();

        public bool TaoPhieuKho(string loaiPhieu, string ghiChu, int maHang, int soLuong, decimal donGia, out string errorMessage)
        {
            if (soLuong <= 0)
            {
                errorMessage = "Số lượng phải lớn hơn 0!";
                return false;
            }
            return khoDAL.TaoPhieuKho(loaiPhieu, ghiChu, maHang, soLuong, donGia, out errorMessage);
        }

        public DataTable GetLichSuXuatNhap() => khoDAL.GetLichSuXuatNhap();
    }
}