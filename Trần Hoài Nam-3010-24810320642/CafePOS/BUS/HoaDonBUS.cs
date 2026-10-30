using System.Data;
using CafePOS.DAL;

namespace CafePOS.BUS
{
    public class HoaDonBUS
    {
        private readonly HoaDonDAL hoaDonDAL = new HoaDonDAL();

        public int GetUnpaidBillIdByTable(int maBan) => hoaDonDAL.GetUnpaidBillIdByTable(maBan);

        public DataTable GetBillDetails(int maHoaDon) => hoaDonDAL.GetBillDetails(maHoaDon);

        public bool AddOrder(int maBan, int maMon, int soLuong, decimal donGia) => hoaDonDAL.AddOrder(maBan, maMon, soLuong, donGia);

        public bool Checkout(int maHoaDon, int maBan, decimal tongTien) => hoaDonDAL.Checkout(maHoaDon, maBan, tongTien);
    }
}