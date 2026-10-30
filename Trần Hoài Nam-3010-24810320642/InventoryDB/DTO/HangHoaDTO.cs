namespace InventoryDB.DTO
{
    public class HangHoaDTO
    {
        public int MaHang { get; set; }
        public string TenHang { get; set; } = string.Empty;
        public string DonViTinh { get; set; } = string.Empty;
        public int SoLuongTon { get; set; }
        public decimal DonGiaNhap { get; set; }
        public decimal DonGiaXuat { get; set; }
    }
}