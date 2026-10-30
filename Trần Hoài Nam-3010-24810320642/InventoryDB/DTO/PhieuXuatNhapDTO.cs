using System;

namespace InventoryDB.DTO
{
    public class PhieuXuatNhapDTO
    {
        public int MaPhieu { get; set; }
        public string LoaiPhieu { get; set; } = string.Empty; // "NHẬP" hoặc "XUẤT"
        public DateTime NgayLap { get; set; }
        public string GhiChu { get; set; } = string.Empty;
    }
}