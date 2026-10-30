using System.Data;
using Microsoft.Data.SqlClient;
using CafePOS.DTO;

namespace CafePOS.DAL
{
    public class MonAnDAL : DatabaseAccess
    {
        public DataTable GetAllDanhMuc()
        {
            return ExecuteQueryDataTable("SELECT * FROM danhmuc");
        }

        public DataTable GetMonAnByDanhMuc(int maDanhMuc)
        {
            string query = "SELECT * FROM monan WHERE madanhmuc = @MaDM";
            SqlParameter[] param = { new SqlParameter("@MaDM", maDanhMuc) };
            return ExecuteQueryDataTable(query, param);
        }

        public DataTable GetAllMonAnWithCategory()
        {
            string query = @"SELECT m.mamon AS MaMon, m.tenmon AS TenMon, d.tendanhmuc AS TenDanhMuc, m.dongia AS DonGia, m.madanhmuc AS MaDanhMuc
                            FROM monan m JOIN danhmuc d ON m.madanhmuc = d.madanhmuc";
            return ExecuteQueryDataTable(query);
        }

        public bool InsertMonAn(MonAnDTO monAn)
        {
            string query = "INSERT INTO monan (tenmon, madanhmuc, dongia) VALUES (@Ten, @MaDM, @Gia)";
            SqlParameter[] param = {
                new SqlParameter("@Ten", monAn.TenMon),
                new SqlParameter("@MaDM", monAn.MaDanhMuc),
                new SqlParameter("@Gia", monAn.DonGia)
            };
            return ExecuteNonQuery(query, param) > 0;
        }

        public bool UpdateMonAn(MonAnDTO monAn)
        {
            string query = "UPDATE monan SET tenmon = @Ten, madanhmuc = @MaDM, dongia = @Gia WHERE mamon = @MaMon";
            SqlParameter[] param = {
                new SqlParameter("@Ten", monAn.TenMon),
                new SqlParameter("@MaDM", monAn.MaDanhMuc),
                new SqlParameter("@Gia", monAn.DonGia),
                new SqlParameter("@MaMon", monAn.MaMon)
            };
            return ExecuteNonQuery(query, param) > 0;
        }

        public bool DeleteMonAn(int maMon)
        {
            string query = "DELETE FROM monan WHERE mamon = @MaMon";
            SqlParameter[] param = { new SqlParameter("@MaMon", maMon) };
            return ExecuteNonQuery(query, param) > 0;
        }
    }
}