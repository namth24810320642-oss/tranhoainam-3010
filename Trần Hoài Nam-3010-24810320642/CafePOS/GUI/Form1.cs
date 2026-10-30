using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CafePOS.BUS;
using CafePOS.DTO;

namespace CafePOS
{
    public partial class Form1 : Form
    {
        private readonly BanAnBUS banAnBUS = new BanAnBUS();
        private readonly MonAnBUS monAnBUS = new MonAnBUS();
        private readonly HoaDonBUS hoaDonBUS = new HoaDonBUS();
        private BanAnDTO? selectedTable = null;

        public Form1()
        {
            InitializeComponent();
            LoadTableLayout();
            LoadCategories();
        }

        private void LoadTableLayout()
        {
            flpTableLayout.Controls.Clear();
            DataTable dtBan = banAnBUS.GetAllBanAn();

            foreach (DataRow row in dtBan.Rows)
            {
                Button btn = new Button
                {
                    Width = 90,
                    Height = 80,
                    Margin = new Padding(5)
                };

                int maBan = Convert.ToInt32(row["maban"]);
                string tenBan = row["tenban"]?.ToString() ?? "";
                string trangThai = row["trangthai"]?.ToString() ?? "";

                btn.Text = $"{tenBan}\n({trangThai})";
                btn.Tag = new BanAnDTO { MaBan = maBan, TenBan = tenBan, TrangThai = trangThai };

                if (trangThai == "Trống")
                    btn.BackColor = Color.LightGreen;
                else
                    btn.BackColor = Color.LightCoral;

                btn.Click += BtnTable_Click;
                flpTableLayout.Controls.Add(btn);
            }
        }

        private void BtnTable_Click(object? sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is BanAnDTO table)
            {
                selectedTable = table;
                lblSelectedTable.Text = $"Bàn đang chọn: {selectedTable.TenBan}";
                ShowBill(selectedTable.MaBan);
            }
        }

        private void ShowBill(int maBan)
        {
            int maHD = hoaDonBUS.GetUnpaidBillIdByTable(maBan);
            if (maHD != -1)
            {
                DataTable dtCTHD = hoaDonBUS.GetBillDetails(maHD);
                dgvBill.DataSource = dtCTHD;

                decimal tongTien = 0;
                foreach (DataRow row in dtCTHD.Rows)
                {
                    tongTien += Convert.ToDecimal(row["ThanhTien"]);
                }
                lblTotalPrice.Text = string.Format("{0:N0} VNĐ", tongTien);
            }
            else
            {
                dgvBill.DataSource = null;
                lblTotalPrice.Text = "0 VNĐ";
            }
        }

        private void LoadCategories()
        {
            cbCategory.DataSource = monAnBUS.GetAllDanhMuc();
            cbCategory.DisplayMember = "tendanhmuc";
            cbCategory.ValueMember = "madanhmuc";
        }

        // Khớp chính xác tên phương thức sự kiện với Designer
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCategory.SelectedValue != null && int.TryParse(cbCategory.SelectedValue.ToString(), out int maDanhMuc))
            {
                cbFood.DataSource = monAnBUS.GetMonAnByDanhMuc(maDanhMuc);
                cbFood.DisplayMember = "tenmon";
                cbFood.ValueMember = "mamon";
            }
        }

        // Khớp chính xác tên phương thức sự kiện với Designer
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi gọi món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbFood.SelectedValue == null) return;

            int maMon = Convert.ToInt32(cbFood.SelectedValue);
            int soLuong = (int)nudQuantity.Value;

            DataTable dtMon = monAnBUS.GetMonAnByDanhMuc(Convert.ToInt32(cbCategory.SelectedValue));
            DataRow[] rows = dtMon.Select($"mamon = {maMon}");
            if (rows.Length == 0) return;

            decimal donGia = Convert.ToDecimal(rows[0]["dongia"]);

            if (hoaDonBUS.AddOrder(selectedTable.MaBan, maMon, soLuong, donGia))
            {
                LoadTableLayout();
                ShowBill(selectedTable.MaBan);
            }
            else
            {
                MessageBox.Show("Thêm món thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khớp chính xác tên phương thức sự kiện với Designer
        private void btnCheckout_Click(object sender, EventArgs e)
        {
            if (selectedTable == null)
            {
                MessageBox.Show("Vui lòng chọn bàn cần thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maHD = hoaDonBUS.GetUnpaidBillIdByTable(selectedTable.MaBan);
            if (maHD == -1)
            {
                MessageBox.Show("Bàn này hiện tại chưa có hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable dt = hoaDonBUS.GetBillDetails(maHD);
            decimal tongTien = 0;
            foreach (DataRow row in dt.Rows)
            {
                tongTien += Convert.ToDecimal(row["ThanhTien"]);
            }

            DialogResult result = MessageBox.Show($"Xác nhận thanh toán cho {selectedTable.TenBan}?\nTổng tiền: {tongTien:N0} VNĐ",
                                                "Thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (hoaDonBUS.Checkout(maHD, selectedTable.MaBan, tongTien))
                {
                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTableLayout();
                    ShowBill(selectedTable.MaBan);
                }
                else
                {
                    MessageBox.Show("Thanh toán thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}