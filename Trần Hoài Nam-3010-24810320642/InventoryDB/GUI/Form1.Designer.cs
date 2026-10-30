using System.Windows.Forms;

namespace InventoryDB
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.dgvHangHoa = new System.Windows.Forms.DataGridView();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.grpHangHoa = new System.Windows.Forms.GroupBox();
            this.btnSuaHang = new System.Windows.Forms.Button();
            this.btnThemHang = new System.Windows.Forms.Button();
            this.txtGiaXuat = new System.Windows.Forms.TextBox();
            this.txtGiaNhap = new System.Windows.Forms.TextBox();
            this.txtDVT = new System.Windows.Forms.TextBox();
            this.txtTenHang = new System.Windows.Forms.TextBox();
            this.lblGiaXuat = new System.Windows.Forms.Label();
            this.lblGiaNhap = new System.Windows.Forms.Label();
            this.lblDVT = new System.Windows.Forms.Label();
            this.lblTenHang = new System.Windows.Forms.Label();
            this.grpPhieuKho = new System.Windows.Forms.GroupBox();
            this.btnThucHienPhieu = new System.Windows.Forms.Button();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.lblGhiChu = new System.Windows.Forms.Label();
            this.nudSoLuong = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.cbHangHoa = new System.Windows.Forms.ComboBox();
            this.lblChonHang = new System.Windows.Forms.Label();
            this.rdoXuatKho = new System.Windows.Forms.RadioButton();
            this.rdoNhapKho = new System.Windows.Forms.RadioButton();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.lblLichSu = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).BeginInit();
            this.grpHangHoa.SuspendLayout();
            this.grpPhieuKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHangHoa
            // 
            this.dgvHangHoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHangHoa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHangHoa.Location = new System.Drawing.Point(12, 40);
            this.dgvHangHoa.Name = "dgvHangHoa";
            this.dgvHangHoa.ReadOnly = true;
            this.dgvHangHoa.Size = new System.Drawing.Size(420, 220);
            this.dgvHangHoa.TabIndex = 0;
            this.dgvHangHoa.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHangHoa_CellClick);
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Location = new System.Drawing.Point(12, 15);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(102, 13);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tìm kiếm hàng hóa:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(120, 12);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(312, 20);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
            // 
            // grpHangHoa
            // 
            this.grpHangHoa.Controls.Add(this.btnSuaHang);
            this.grpHangHoa.Controls.Add(this.btnThemHang);
            this.grpHangHoa.Controls.Add(this.txtGiaXuat);
            this.grpHangHoa.Controls.Add(this.txtGiaNhap);
            this.grpHangHoa.Controls.Add(this.txtDVT);
            this.grpHangHoa.Controls.Add(this.txtTenHang);
            this.grpHangHoa.Controls.Add(this.lblGiaXuat);
            this.grpHangHoa.Controls.Add(this.lblGiaNhap);
            this.grpHangHoa.Controls.Add(this.lblDVT);
            this.grpHangHoa.Controls.Add(this.lblTenHang);
            this.grpHangHoa.Location = new System.Drawing.Point(445, 12);
            this.grpHangHoa.Name = "grpHangHoa";
            this.grpHangHoa.Size = new System.Drawing.Size(315, 248);
            this.grpHangHoa.TabIndex = 3;
            this.grpHangHoa.TabStop = false;
            this.grpHangHoa.Text = "Thông tin Hàng hóa";
            // 
            // btnSuaHang
            // 
            this.btnSuaHang.Location = new System.Drawing.Point(180, 195);
            this.btnSuaHang.Name = "btnSuaHang";
            this.btnSuaHang.Size = new System.Drawing.Size(90, 30);
            this.btnSuaHang.TabIndex = 9;
            this.btnSuaHang.Text = "Sửa thông tin";
            this.btnSuaHang.Click += new System.EventHandler(this.btnSuaHang_Click);
            // 
            // btnThemHang
            // 
            this.btnThemHang.Location = new System.Drawing.Point(80, 195);
            this.btnThemHang.Name = "btnThemHang";
            this.btnThemHang.Size = new System.Drawing.Size(90, 30);
            this.btnThemHang.TabIndex = 8;
            this.btnThemHang.Text = "Thêm mới";
            this.btnThemHang.Click += new System.EventHandler(this.btnThemHang_Click);
            // 
            // txtGiaXuat
            // 
            this.txtGiaXuat.Location = new System.Drawing.Point(90, 150);
            this.txtGiaXuat.Name = "txtGiaXuat";
            this.txtGiaXuat.Size = new System.Drawing.Size(180, 20);
            this.txtGiaXuat.TabIndex = 7;
            // 
            // txtGiaNhap
            // 
            this.txtGiaNhap.Location = new System.Drawing.Point(90, 110);
            this.txtGiaNhap.Name = "txtGiaNhap";
            this.txtGiaNhap.Size = new System.Drawing.Size(180, 20);
            this.txtGiaNhap.TabIndex = 6;
            // 
            // txtDVT
            // 
            this.txtDVT.Location = new System.Drawing.Point(90, 70);
            this.txtDVT.Name = "txtDVT";
            this.txtDVT.Size = new System.Drawing.Size(180, 20);
            this.txtDVT.TabIndex = 5;
            // 
            // txtTenHang
            // 
            this.txtTenHang.Location = new System.Drawing.Point(90, 30);
            this.txtTenHang.Name = "txtTenHang";
            this.txtTenHang.Size = new System.Drawing.Size(180, 20);
            this.txtTenHang.TabIndex = 4;
            // 
            // lblGiaXuat
            // 
            this.lblGiaXuat.AutoSize = true;
            this.lblGiaXuat.Location = new System.Drawing.Point(15, 153);
            this.lblGiaXuat.Name = "lblGiaXuat";
            this.lblGiaXuat.Size = new System.Drawing.Size(71, 13);
            this.lblGiaXuat.TabIndex = 3;
            this.lblGiaXuat.Text = "Đơn giá xuất:";
            // 
            // lblGiaNhap
            // 
            this.lblGiaNhap.AutoSize = true;
            this.lblGiaNhap.Location = new System.Drawing.Point(15, 113);
            this.lblGiaNhap.Name = "lblGiaNhap";
            this.lblGiaNhap.Size = new System.Drawing.Size(75, 13);
            this.lblGiaNhap.TabIndex = 2;
            this.lblGiaNhap.Text = "Đơn giá nhập:";
            // 
            // lblDVT
            // 
            this.lblDVT.AutoSize = true;
            this.lblDVT.Location = new System.Drawing.Point(15, 73);
            this.lblDVT.Name = "lblDVT";
            this.lblDVT.Size = new System.Drawing.Size(63, 13);
            this.lblDVT.TabIndex = 1;
            this.lblDVT.Text = "Đơn vị tính:";
            // 
            // lblTenHang
            // 
            this.lblTenHang.AutoSize = true;
            this.lblTenHang.Location = new System.Drawing.Point(15, 33);
            this.lblTenHang.Name = "lblTenHang";
            this.lblTenHang.Size = new System.Drawing.Size(56, 13);
            this.lblTenHang.TabIndex = 0;
            this.lblTenHang.Text = "Tên hàng:";
            // 
            // grpPhieuKho
            // 
            this.grpPhieuKho.Controls.Add(this.btnThucHienPhieu);
            this.grpPhieuKho.Controls.Add(this.txtGhiChu);
            this.grpPhieuKho.Controls.Add(this.lblGhiChu);
            this.grpPhieuKho.Controls.Add(this.nudSoLuong);
            this.grpPhieuKho.Controls.Add(this.lblSoLuong);
            this.grpPhieuKho.Controls.Add(this.cbHangHoa);
            this.grpPhieuKho.Controls.Add(this.lblChonHang);
            this.grpPhieuKho.Controls.Add(this.rdoXuatKho);
            this.grpPhieuKho.Controls.Add(this.rdoNhapKho);
            this.grpPhieuKho.Location = new System.Drawing.Point(12, 270);
            this.grpPhieuKho.Name = "grpPhieuKho";
            this.grpPhieuKho.Size = new System.Drawing.Size(748, 110);
            this.grpPhieuKho.TabIndex = 4;
            this.grpPhieuKho.TabStop = false;
            this.grpPhieuKho.Text = "Lập Phiếu Nhập / Xuất Kho";
            // 
            // btnThucHienPhieu
            // 
            this.btnThucHienPhieu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnThucHienPhieu.Location = new System.Drawing.Point(600, 25);
            this.btnThucHienPhieu.Name = "btnThucHienPhieu";
            this.btnThucHienPhieu.Size = new System.Drawing.Size(130, 65);
            this.btnThucHienPhieu.TabIndex = 8;
            this.btnThucHienPhieu.Text = "TẠO PHIẾU";
            this.btnThucHienPhieu.Click += new System.EventHandler(this.btnThucHienPhieu_Click);
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(340, 65);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(240, 20);
            this.txtGhiChu.TabIndex = 7;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.Location = new System.Drawing.Point(280, 68);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(47, 13);
            this.lblGhiChu.TabIndex = 6;
            this.lblGhiChu.Text = "Ghi chú:";
            // 
            // nudSoLuong
            // 
            this.nudSoLuong.Location = new System.Drawing.Point(340, 27);
            this.nudSoLuong.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuong.Name = "nudSoLuong";
            this.nudSoLuong.Size = new System.Drawing.Size(80, 20);
            this.nudSoLuong.TabIndex = 5;
            this.nudSoLuong.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Location = new System.Drawing.Point(280, 30);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(52, 13);
            this.lblSoLuong.TabIndex = 4;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // cbHangHoa
            // 
            this.cbHangHoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHangHoa.Location = new System.Drawing.Point(90, 65);
            this.cbHangHoa.Name = "cbHangHoa";
            this.cbHangHoa.Size = new System.Drawing.Size(160, 21);
            this.cbHangHoa.TabIndex = 3;
            // 
            // lblChonHang
            // 
            this.lblChonHang.AutoSize = true;
            this.lblChonHang.Location = new System.Drawing.Point(20, 68);
            this.lblChonHang.Name = "lblChonHang";
            this.lblChonHang.Size = new System.Drawing.Size(62, 13);
            this.lblChonHang.TabIndex = 2;
            this.lblChonHang.Text = "Chọn hàng:";
            // 
            // rdoXuatKho
            // 
            this.rdoXuatKho.AutoSize = true;
            this.rdoXuatKho.Location = new System.Drawing.Point(140, 28);
            this.rdoXuatKho.Name = "rdoXuatKho";
            this.rdoXuatKho.Size = new System.Drawing.Size(78, 17);
            this.rdoXuatKho.TabIndex = 1;
            this.rdoXuatKho.Text = "XUẤT KHO";
            // 
            // rdoNhapKho
            // 
            this.rdoNhapKho.AutoSize = true;
            this.rdoNhapKho.Checked = true;
            this.rdoNhapKho.Location = new System.Drawing.Point(20, 28);
            this.rdoNhapKho.Name = "rdoNhapKho";
            this.rdoNhapKho.Size = new System.Drawing.Size(81, 17);
            this.rdoNhapKho.TabIndex = 0;
            this.rdoNhapKho.TabStop = true;
            this.rdoNhapKho.Text = "NHẬP KHO";
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLichSu.Location = new System.Drawing.Point(12, 410);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.Size = new System.Drawing.Size(748, 180);
            this.dgvLichSu.TabIndex = 5;
            // 
            // lblLichSu
            // 
            this.lblLichSu.AutoSize = true;
            this.lblLichSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblLichSu.Location = new System.Drawing.Point(12, 390);
            this.lblLichSu.Name = "lblLichSu";
            this.lblLichSu.Size = new System.Drawing.Size(189, 15);
            this.lblLichSu.TabIndex = 6;
            this.lblLichSu.Text = "Lịch sử Xuất - Nhập Kho gần đây";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(772, 602);
            this.Controls.Add(this.lblLichSu);
            this.Controls.Add(this.dgvLichSu);
            this.Controls.Add(this.grpPhieuKho);
            this.Controls.Add(this.grpHangHoa);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.lblTimKiem);
            this.Controls.Add(this.dgvHangHoa);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Kho hàng & Nhập xuất (Inventory System)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHangHoa)).EndInit();
            this.grpHangHoa.ResumeLayout(false);
            this.grpHangHoa.PerformLayout();
            this.grpPhieuKho.ResumeLayout(false);
            this.grpPhieuKho.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLichSu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHangHoa;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.GroupBox grpHangHoa;
        private System.Windows.Forms.Label lblGiaXuat;
        private System.Windows.Forms.Label lblGiaNhap;
        private System.Windows.Forms.Label lblDVT;
        private System.Windows.Forms.Label lblTenHang;
        private System.Windows.Forms.TextBox txtGiaXuat;
        private System.Windows.Forms.TextBox txtGiaNhap;
        private System.Windows.Forms.TextBox txtDVT;
        private System.Windows.Forms.TextBox txtTenHang;
        private System.Windows.Forms.Button btnSuaHang;
        private System.Windows.Forms.Button btnThemHang;
        private System.Windows.Forms.GroupBox grpPhieuKho;
        private System.Windows.Forms.RadioButton rdoXuatKho;
        private System.Windows.Forms.RadioButton rdoNhapKho;
        private System.Windows.Forms.Label lblChonHang;
        private System.Windows.Forms.ComboBox cbHangHoa;
        private System.Windows.Forms.NumericUpDown nudSoLuong;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label lblGhiChu;
        private System.Windows.Forms.Button btnThucHienPhieu;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.Label lblLichSu;
    }
}