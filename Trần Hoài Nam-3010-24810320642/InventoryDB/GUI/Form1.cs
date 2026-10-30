using System;
using System.Data;
using System.Windows.Forms;
using InventoryDB.BUS;
using InventoryDB.DTO;

namespace InventoryDB
{
    public partial class Form1 : Form
    {
        private readonly HangHoaBUS hangHoaBUS = new HangHoaBUS();
        private readonly KhoBUS khoBUS = new KhoBUS();

        private DataTable dtHangHoa = new DataTable();
        private DataView dataViewHangHoa = new DataView();
        private int selectedMaHang = -1;

        public Form1()
        {
            InitializeComponent();
            LoadDataHangHoa();
            LoadLichSu();
        }

        private void LoadDataHangHoa()
        {
            dtHangHoa = hangHoaBUS.GetAllHangHoa();
            dataViewHangHoa = new DataView(dtHangHoa);
            dgvHangHoa.DataSource = dataViewHangHoa;

            cbHangHoa.DataSource = dtHangHoa;
            cbHangHoa.DisplayMember = "tenhang";
            cbHangHoa.ValueMember = "mahang";
        }

        private void LoadLichSu()
        {
            dgvLichSu.DataSource = khoBUS.GetLichSuXuatNhap();
        }

        private void txtTimKiem_TextChanged(object? sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            dataViewHangHoa.RowFilter = string.IsNullOrEmpty(keyword) ? "" : $"tenhang LIKE '%{keyword}%'";
        }

        private void dgvHangHoa_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvHangHoa.Rows[e.RowIndex].Cells["mahang"].Value != null)
            {
                DataGridViewRow row = dgvHangHoa.Rows[e.RowIndex];
                selectedMaHang = Convert.ToInt32(row.Cells["mahang"].Value);
                txtTenHang.Text = row.Cells["tenhang"].Value?.ToString() ?? string.Empty;
                txtDVT.Text = row.Cells["donvitinh"].Value?.ToString() ?? string.Empty;
                txtGiaNhap.Text = row.Cells["dongianhap"].Value?.ToString() ?? "0";
                txtGiaXuat.Text = row.Cells["dongiaxuat"].Value?.ToString() ?? "0";

                cbHangHoa.SelectedValue = selectedMaHang;
            }
        }

        private void btnThemHang_Click(object? sender, EventArgs e)
        {
            if (!decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap) || !decimal.TryParse(txtGiaXuat.Text, out decimal giaXuat))
            {
                MessageBox.Show("Đơn giá nhập/xuat phải là số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HangHoaDTO hang = new HangHoaDTO
            {
                TenHang = txtTenHang.Text.Trim(),
                DonViTinh = txtDVT.Text.Trim(),
                SoLuongTon = 0,
                DonGiaNhap = giaNhap,
                DonGiaXuat = giaXuat
            };

            string? err = hangHoaBUS.ValidateAndInsert(hang);
            if (err != null)
                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MessageBox.Show("Thêm hàng hóa mới thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataHangHoa();
            }
        }

        private void btnSuaHang_Click(object? sender, EventArgs e)
        {
            if (selectedMaHang == -1) return;

            if (!decimal.TryParse(txtGiaNhap.Text, out decimal giaNhap) || !decimal.TryParse(txtGiaXuat.Text, out decimal giaXuat))
            {
                MessageBox.Show("Đơn giá nhập/xUất phải là số!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HangHoaDTO hang = new HangHoaDTO
            {
                MaHang = selectedMaHang,
                TenHang = txtTenHang.Text.Trim(),
                DonViTinh = txtDVT.Text.Trim(),
                DonGiaNhap = giaNhap,
                DonGiaXuat = giaXuat
            };

            string? err = hangHoaBUS.ValidateAndUpdate(hang);
            if (err != null)
                MessageBox.Show(err, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                MessageBox.Show("Cập nhật hàng hóa thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataHangHoa();
            }
        }

        private void btnThucHienPhieu_Click(object? sender, EventArgs e)
        {
            if (cbHangHoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHang = Convert.ToInt32(cbHangHoa.SelectedValue);
            int soLuong = (int)nudSoLuong.Value;
            string loaiPhieu = rdoNhapKho.Checked ? "NHẬP" : "XUẤT";
            string ghiChu = txtGhiChu.Text.Trim();

            // Lấy giá mặc định theo loại phiếu
            DataRow[] rows = dtHangHoa.Select($"mahang = {maHang}");
            if (rows.Length == 0) return;
            decimal donGia = loaiPhieu == "NHẬP" ? Convert.ToDecimal(rows[0]["dongianhap"]) : Convert.ToDecimal(rows[0]["dongiaxuat"]);

            if (khoBUS.TaoPhieuKho(loaiPhieu, ghiChu, maHang, soLuong, donGia, out string err))
            {
                MessageBox.Show($"Lập phiếu {loaiPhieu} kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataHangHoa();
                LoadLichSu();
            }
            else
            {
                MessageBox.Show($"Thất bại: {err}", "Lỗi Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}