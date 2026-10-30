using System.Data;
using CafePOS.DAL;

namespace CafePOS.BUS
{
    public class BanAnBUS
    {
        private readonly BanAnDAL banAnDAL = new BanAnDAL();

        public DataTable GetAllBanAn() => banAnDAL.GetAllBanAn();
    }
}