using System.Data;
using HotelDB.DAL;

namespace HotelDB.BUS
{
    public class PhieuDatPhongBUS
    {
        private readonly PhieuDatPhongDAL phieuDAL = new PhieuDatPhongDAL();

        public int GetActivePhieuByRoom(string soPhong) => phieuDAL.GetActivePhieuByRoom(soPhong);
        public bool CheckIn(string soPhong, int maKH) => phieuDAL.CheckIn(soPhong, maKH);
        public bool AddService(int maPhieu, int maDV, int soLuong) => phieuDAL.AddService(maPhieu, maDV, soLuong);
        public DataTable GetSuDungDichVuByPhieu(int maPhieu) => phieuDAL.GetSuDungDichVuByPhieu(maPhieu);
        public bool CheckOut(int maPhieu, string soPhong, decimal giaTheoGio, out decimal tongTien) => phieuDAL.CheckOut(maPhieu, soPhong, giaTheoGio, out tongTien);
    }
}