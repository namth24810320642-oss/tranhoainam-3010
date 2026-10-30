using System.Data;
using InventoryDB.DAL;
using InventoryDB.DTO;

namespace InventoryDB.BUS
{
    public class HangHoaBUS
    {
        private readonly HangHoaDAL hangHoaDAL = new HangHoaDAL();

        public DataTable GetAllHangHoa() => hangHoaDAL.GetAllHangHoa();

        public string? ValidateAndInsert(HangHoaDTO hang)
        {
            if (string.IsNullOrWhiteSpace(hang.TenHang)) return "Tên hàng không được để trống!";
            if (string.IsNullOrWhiteSpace(hang.DonViTinh)) return "Đơn vị tính không được để trống!";
            if (hang.DonGiaNhap < 0 || hang.DonGiaXuat < 0) return "Đơn giá không được nhỏ hơn 0!";

            return hangHoaDAL.InsertHangHoa(hang) ? null : "Thêm hàng hóa thất bại!";
        }

        public string? ValidateAndUpdate(HangHoaDTO hang)
        {
            if (string.IsNullOrWhiteSpace(hang.TenHang)) return "Tên hàng không được để trống!";
            if (string.IsNullOrWhiteSpace(hang.DonViTinh)) return "Đơn vị tính không được để trống!";

            return hangHoaDAL.UpdateHangHoa(hang) ? null : "Cập nhật thất bại!";
        }
    }
}