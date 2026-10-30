using HotelDB.DAL;
using HotelDB.DTO;

namespace HotelDB.BUS
{
    public class KhachHangBUS
    {
        private readonly KhachHangDAL khachHangDAL = new KhachHangDAL();
        public KhachHangDTO? GetKhachHangByCCCD(string cccd) => khachHangDAL.GetKhachHangByCCCD(cccd);
        public int InsertKhachHang(KhachHangDTO kh) => khachHangDAL.InsertKhachHang(kh);
    }
}