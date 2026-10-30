using System.Data;
using CafePOS.DAL;
using CafePOS.DTO;

namespace CafePOS.BUS
{
    public class MonAnBUS
    {
        private readonly MonAnDAL monAnDAL = new MonAnDAL();

        public DataTable GetAllDanhMuc() => monAnDAL.GetAllDanhMuc();

        public DataTable GetMonAnByDanhMuc(int maDM) => monAnDAL.GetMonAnByDanhMuc(maDM);

        public DataTable GetAllMonAnWithCategory() => monAnDAL.GetAllMonAnWithCategory();

        public string? ValidateAndInsert(MonAnDTO monAn)
        {
            if (string.IsNullOrWhiteSpace(monAn.TenMon))
                return "Tên món không được để trống!";
            if (monAn.DonGia < 0)
                return "Đơn giá không được nhỏ hơn 0!";

            return monAnDAL.InsertMonAn(monAn) ? null : "Thêm món thất bại!";
        }

        public string? ValidateAndUpdate(MonAnDTO monAn)
        {
            if (string.IsNullOrWhiteSpace(monAn.TenMon))
                return "Tên món không được để trống!";
            if (monAn.DonGia < 0)
                return "Đơn giá không được nhỏ hơn 0!";

            return monAnDAL.UpdateMonAn(monAn) ? null : "Cập nhật thất bại!";
        }

        public bool DeleteMonAn(int maMon) => monAnDAL.DeleteMonAn(maMon);
    }
}