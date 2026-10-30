using System.Data;
using HotelDB.DAL;

namespace HotelDB.BUS
{
    public class PhongBUS
    {
        private readonly PhongDAL phongDAL = new PhongDAL();
        public DataTable GetAllPhong() => phongDAL.GetAllPhong();
        public bool UpdateTrangThai(string soPhong, string trangThai) => phongDAL.UpdateTrangThai(soPhong, trangThai);
    }
}