using System.Data;
using HotelDB.DAL;

namespace HotelDB.BUS
{
    public class DichVuBUS
    {
        private readonly DichVuDAL dichVuDAL = new DichVuDAL();
        public DataTable GetAllDichVu() => dichVuDAL.GetAllDichVu();
    }
}