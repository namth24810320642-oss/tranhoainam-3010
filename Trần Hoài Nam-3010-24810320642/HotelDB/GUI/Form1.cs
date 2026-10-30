using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using HotelDB.BUS;
using HotelDB.DTO;

namespace HotelDB
{
    public partial class Form1 : Form
    {
        private readonly PhongBUS phongBUS = new PhongBUS();
        private readonly KhachHangBUS khachHangBUS = new KhachHangBUS();
        private readonly DichVuBUS dichVuBUS = new DichVuBUS();
        private readonly PhieuDatPhongBUS phieuBUS = new PhieuDatPhongBUS();

        private DataTable dtPhong = new DataTable();
        private DataView dataViewPhong = new DataView();

        private string selectedSoPhong = "";
        private decimal selectedGiaTheoGio = 0;
        private string selectedTrangThai = "";
        private int currentMaKH = -1;

        public Form1()
        {
            InitializeComponent();
            LoadDataPhong();
            LoadDichVu();
            InitFilters();
        }

        private void LoadDataPhong()
        {
            dtPhong = phongBUS.GetAllPhong();
            dataViewPhong = new DataView(dtPhong);
            dgvPhong.DataSource = dataViewPhong;
        }

        private void LoadDichVu()
        {
            cbDichVu.DataSource = dichVuBUS.GetAllDichVu();
            cbDichVu.DisplayMember = "tendv";
            cbDichVu.ValueMember = "madv";
        }

        private void InitFilters()
        {
            cbFilterLoaiPhong.Items.Clear();
            cbFilterLoaiPhong.Items.Add("Tất cả");
            cbFilterLoaiPhong.Items.Add("Đơn");
            cbFilterLoaiPhong.Items.Add("Đôi");
            cbFilterLoaiPhong.Items.Add("VIP");
            cbFilterLoaiPhong.SelectedIndex = 0;

            cbFilterTrangThai.Items.Clear();
            cbFilterTrangThai.Items.Add("Tất cả");
            cbFilterTrangThai.Items.Add("Trống");
            cbFilterTrangThai.Items.Add("Đang ở");
            cbFilterTrangThai.Items.Add("Đang dọn dẹp");
            cbFilterTrangThai.SelectedIndex = 0;
        }

        private void ApplyFilter()
        {
            string filterLoai = cbFilterLoaiPhong.SelectedItem?.ToString() ?? "Tất cả";
            string filterTrangThai = cbFilterTrangThai.SelectedItem?.ToString() ?? "Tất cả";

            string queryFilter = "";

            if (filterLoai != "Tất cả")
                queryFilter += $"loaiphong = '{filterLoai}'";

            if (filterTrangThai != "Tất cả")
            {
                if (queryFilter != "") queryFilter += " AND ";
                queryFilter += $"trangthai = '{filterTrangThai}'";
            }

            dataViewPhong.RowFilter = queryFilter;
        }

        private void cbFilterLoaiPhong_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();
        private void cbFilterTrangThai_SelectedIndexChanged(object sender, EventArgs e) => ApplyFilter();

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhong.Rows[e.RowIndex];
                selectedSoPhong = row.Cells["sophong"].Value?.ToString() ?? "";
                selectedGiaTheoGio = row.Cells["giatheogio"].Value != null ? Convert.ToDecimal(row.Cells["giatheogio"].Value) : 0;
                selectedTrangThai = row.Cells["trangthai"].Value?.ToString() ?? "";

                lblSelectedPhong.Text = $"Phòng đang chọn: {selectedSoPhong} ({selectedTrangThai})";
                LoadDichVuDaDung();
            }
        }

        private void LoadDichVuDaDung()
        {
            if (string.IsNullOrEmpty(selectedSoPhong)) return;

            int maPhieu = phieuBUS.GetActivePhieuByRoom(selectedSoPhong);
            if (maPhieu != -1)
            {
                dgvDichVuDaDung.DataSource = phieuBUS.GetSuDungDichVuByPhieu(maPhieu);
            }
            else
            {
                dgvDichVuDaDung.DataSource = null;
            }
        }

        private void btnTimCCCD_Click(object sender, EventArgs e)
        {
            string cccd = txtCCCD.Text.Trim();
            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập CCCD!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            KhachHangDTO? kh = khachHangBUS.GetKhachHangByCCCD(cccd);
            if (kh != null)
            {
                currentMaKH = kh.MaKH;
                txtHoTen.Text = kh.HoTen;
                txtSDT.Text = kh.SoDienThoai;
                MessageBox.Show("Đã tìm thấy thông tin khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                currentMaKH = -1;
                txtHoTen.Text = "";
                txtSDT.Text = "";
                MessageBox.Show("Khách hàng mới! Vui lòng nhập Họ tên và SĐT để tạo thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoPhong))
            {
                MessageBox.Show("Vui lòng chọn phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedTrangThai != "Trống")
            {
                MessageBox.Show("Chỉ được nhận phòng khi trạng thái phòng là 'Trống'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentMaKH == -1)
            {
                string hoTen = txtHoTen.Text.Trim();
                string cccd = txtCCCD.Text.Trim();
                string sdt = txtSDT.Text.Trim();

                if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(cccd))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin Khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                KhachHangDTO newKH = new KhachHangDTO { HoTen = hoTen, CCCD = cccd, SoDienThoai = sdt };
                currentMaKH = khachHangBUS.InsertKhachHang(newKH);
            }

            if (phieuBUS.CheckIn(selectedSoPhong, currentMaKH))
            {
                MessageBox.Show($"Nhận phòng {selectedSoPhong} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataPhong();
                LoadDichVuDaDung();
            }
            else
            {
                MessageBox.Show("Nhận phòng thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGoiDichVu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoPhong) || selectedTrangThai != "Đang ở")
            {
                MessageBox.Show("Phòng phải đang ở trạng thái 'Đang ở' mới có thể gọi dịch vụ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieu = phieuBUS.GetActivePhieuByRoom(selectedSoPhong);
            if (maPhieu == -1) return;

            if (cbDichVu.SelectedValue == null) return;

            int maDV = Convert.ToInt32(cbDichVu.SelectedValue);
            int soLuong = (int)nudSoLuongDV.Value;

            if (phieuBUS.AddService(maPhieu, maDV, soLuong))
            {
                MessageBox.Show("Thêm dịch vụ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDichVuDaDung();
            }
            else
            {
                MessageBox.Show("Thêm dịch vụ thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoPhong) || selectedTrangThai != "Đang ở")
            {
                MessageBox.Show("Vui lòng chọn phòng 'Đang ở' để Check-out!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maPhieu = phieuBUS.GetActivePhieuByRoom(selectedSoPhong);
            if (maPhieu == -1) return;

            if (MessageBox.Show($"Xác nhận thanh toán & Check-out phòng {selectedSoPhong}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (phieuBUS.CheckOut(maPhieu, selectedSoPhong, selectedGiaTheoGio, out decimal tongTien))
                {
                    MessageBox.Show($"Check-out thành công!\nTổng tiền thanh toán: {tongTien:N0} VNĐ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPhong();
                    LoadDichVuDaDung();
                }
                else
                {
                    MessageBox.Show("Check-out thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDonDepXong_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedSoPhong) || selectedTrangThai != "Đang dọn dẹp")
            {
                MessageBox.Show("Chỉ đổi trạng thái cho phòng 'Đang dọn dẹp'!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (phongBUS.UpdateTrangThai(selectedSoPhong, "Trống"))
            {
                MessageBox.Show($"Phòng {selectedSoPhong} đã sẵn sàng đón khách mới!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataPhong();
            }
        }
    }
}