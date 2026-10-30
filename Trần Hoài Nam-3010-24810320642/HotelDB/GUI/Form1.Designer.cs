using System.Windows.Forms;

namespace HotelDB
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
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.cbFilterLoaiPhong = new System.Windows.Forms.ComboBox();
            this.cbFilterTrangThai = new System.Windows.Forms.ComboBox();
            this.lblFilterLoai = new System.Windows.Forms.Label();
            this.lblFilterTT = new System.Windows.Forms.Label();
            this.lblSelectedPhong = new System.Windows.Forms.Label();
            this.txtCCCD = new System.Windows.Forms.TextBox();
            this.txtHoTen = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.btnTimCCCD = new System.Windows.Forms.Button();
            this.btnCheckIn = new System.Windows.Forms.Button();
            this.lblCCCD = new System.Windows.Forms.Label();
            this.lblHoTen = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.cbDichVu = new System.Windows.Forms.ComboBox();
            this.nudSoLuongDV = new System.Windows.Forms.NumericUpDown();
            this.btnGoiDichVu = new System.Windows.Forms.Button();
            this.dgvDichVuDaDung = new System.Windows.Forms.DataGridView();
            this.btnCheckOut = new System.Windows.Forms.Button();
            this.btnDonDepXong = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaDung)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPhong
            // 
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Location = new System.Drawing.Point(12, 45);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.ReadOnly = true;
            this.dgvPhong.Size = new System.Drawing.Size(380, 400);
            this.dgvPhong.TabIndex = 0;
            this.dgvPhong.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_CellClick);
            // 
            // cbFilterLoaiPhong
            // 
            this.cbFilterLoaiPhong.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterLoaiPhong.Location = new System.Drawing.Point(80, 12);
            this.cbFilterLoaiPhong.Name = "cbFilterLoaiPhong";
            this.cbFilterLoaiPhong.Size = new System.Drawing.Size(100, 21);
            this.cbFilterLoaiPhong.TabIndex = 1;
            this.cbFilterLoaiPhong.SelectedIndexChanged += new System.EventHandler(this.cbFilterLoaiPhong_SelectedIndexChanged);
            // 
            // cbFilterTrangThai
            // 
            this.cbFilterTrangThai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilterTrangThai.Location = new System.Drawing.Point(270, 12);
            this.cbFilterTrangThai.Name = "cbFilterTrangThai";
            this.cbFilterTrangThai.Size = new System.Drawing.Size(120, 21);
            this.cbFilterTrangThai.TabIndex = 2;
            this.cbFilterTrangThai.SelectedIndexChanged += new System.EventHandler(this.cbFilterTrangThai_SelectedIndexChanged);
            // 
            // lblFilterLoai
            // 
            this.lblFilterLoai.AutoSize = true;
            this.lblFilterLoai.Location = new System.Drawing.Point(12, 15);
            this.lblFilterLoai.Name = "lblFilterLoai";
            this.lblFilterLoai.Size = new System.Drawing.Size(63, 13);
            this.lblFilterLoai.TabIndex = 3;
            this.lblFilterLoai.Text = "Loại phòng:";
            // 
            // lblFilterTT
            // 
            this.lblFilterTT.AutoSize = true;
            this.lblFilterTT.Location = new System.Drawing.Point(205, 15);
            this.lblFilterTT.Name = "lblFilterTT";
            this.lblFilterTT.Size = new System.Drawing.Size(58, 13);
            this.lblFilterTT.TabIndex = 4;
            this.lblFilterTT.Text = "Trạng thái:";
            // 
            // lblSelectedPhong
            // 
            this.lblSelectedPhong.AutoSize = true;
            this.lblSelectedPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.lblSelectedPhong.Location = new System.Drawing.Point(410, 15);
            this.lblSelectedPhong.Name = "lblSelectedPhong";
            this.lblSelectedPhong.Size = new System.Drawing.Size(142, 16);
            this.lblSelectedPhong.TabIndex = 5;
            this.lblSelectedPhong.Text = "Chưa chọn phòng nào";
            // 
            // txtCCCD
            // 
            this.txtCCCD.Location = new System.Drawing.Point(460, 45);
            this.txtCCCD.Name = "txtCCCD";
            this.txtCCCD.Size = new System.Drawing.Size(140, 20);
            this.txtCCCD.TabIndex = 6;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(460, 75);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Size = new System.Drawing.Size(230, 20);
            this.txtHoTen.TabIndex = 7;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(460, 105);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(140, 20);
            this.txtSDT.TabIndex = 8;
            // 
            // btnTimCCCD
            // 
            this.btnTimCCCD.Location = new System.Drawing.Point(610, 43);
            this.btnTimCCCD.Name = "btnTimCCCD";
            this.btnTimCCCD.Size = new System.Drawing.Size(80, 23);
            this.btnTimCCCD.TabIndex = 9;
            this.btnTimCCCD.Text = "Tìm CCCD";
            this.btnTimCCCD.Click += new System.EventHandler(this.btnTimCCCD_Click);
            // 
            // btnCheckIn
            // 
            this.btnCheckIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCheckIn.Location = new System.Drawing.Point(610, 103);
            this.btnCheckIn.Name = "btnCheckIn";
            this.btnCheckIn.Size = new System.Drawing.Size(80, 25);
            this.btnCheckIn.TabIndex = 10;
            this.btnCheckIn.Text = "Check-in";
            this.btnCheckIn.Click += new System.EventHandler(this.btnCheckIn_Click);
            // 
            // lblCCCD
            // 
            this.lblCCCD.AutoSize = true;
            this.lblCCCD.Location = new System.Drawing.Point(410, 48);
            this.lblCCCD.Name = "lblCCCD";
            this.lblCCCD.Size = new System.Drawing.Size(39, 13);
            this.lblCCCD.TabIndex = 11;
            this.lblCCCD.Text = "CCCD:";
            // 
            // lblHoTen
            // 
            this.lblHoTen.AutoSize = true;
            this.lblHoTen.Location = new System.Drawing.Point(410, 78);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(42, 13);
            this.lblHoTen.TabIndex = 12;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Location = new System.Drawing.Point(410, 108);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(32, 13);
            this.lblSDT.TabIndex = 13;
            this.lblSDT.Text = "SĐT:";
            // 
            // cbDichVu
            // 
            this.cbDichVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDichVu.Location = new System.Drawing.Point(410, 145);
            this.cbDichVu.Name = "cbDichVu";
            this.cbDichVu.Size = new System.Drawing.Size(150, 21);
            this.cbDichVu.TabIndex = 14;
            // 
            // nudSoLuongDV
            // 
            this.nudSoLuongDV.Location = new System.Drawing.Point(570, 146);
            this.nudSoLuongDV.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSoLuongDV.Name = "nudSoLuongDV";
            this.nudSoLuongDV.Size = new System.Drawing.Size(50, 20);
            this.nudSoLuongDV.TabIndex = 15;
            this.nudSoLuongDV.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnGoiDichVu
            // 
            this.btnGoiDichVu.Location = new System.Drawing.Point(630, 143);
            this.btnGoiDichVu.Name = "btnGoiDichVu";
            this.btnGoiDichVu.Size = new System.Drawing.Size(80, 25);
            this.btnGoiDichVu.TabIndex = 16;
            this.btnGoiDichVu.Text = "+ Dịch vụ";
            this.btnGoiDichVu.Click += new System.EventHandler(this.btnGoiDichVu_Click);
            // 
            // dgvDichVuDaDung
            // 
            this.dgvDichVuDaDung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVuDaDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDichVuDaDung.Location = new System.Drawing.Point(410, 180);
            this.dgvDichVuDaDung.Name = "dgvDichVuDaDung";
            this.dgvDichVuDaDung.ReadOnly = true;
            this.dgvDichVuDaDung.Size = new System.Drawing.Size(300, 220);
            this.dgvDichVuDaDung.TabIndex = 17;
            // 
            // btnCheckOut
            // 
            this.btnCheckOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.btnCheckOut.Location = new System.Drawing.Point(410, 410);
            this.btnCheckOut.Name = "btnCheckOut";
            this.btnCheckOut.Size = new System.Drawing.Size(140, 35);
            this.btnCheckOut.TabIndex = 18;
            this.btnCheckOut.Text = "Check-out & Tính tiền";
            this.btnCheckOut.UseVisualStyleBackColor = true;
            this.btnCheckOut.Click += new System.EventHandler(this.btnCheckOut_Click);
            // 
            // btnDonDepXong
            // 
            this.btnDonDepXong.Location = new System.Drawing.Point(570, 410);
            this.btnDonDepXong.Name = "btnDonDepXong";
            this.btnDonDepXong.Size = new System.Drawing.Size(140, 35);
            this.btnDonDepXong.TabIndex = 19;
            this.btnDonDepXong.Text = "Đã dọn dẹp xong";
            this.btnDonDepXong.UseVisualStyleBackColor = true;
            this.btnDonDepXong.Click += new System.EventHandler(this.btnDonDepXong_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(724, 455);
            this.Controls.Add(this.btnDonDepXong);
            this.Controls.Add(this.btnCheckOut);
            this.Controls.Add(this.dgvDichVuDaDung);
            this.Controls.Add(this.btnGoiDichVu);
            this.Controls.Add(this.nudSoLuongDV);
            this.Controls.Add(this.cbDichVu);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblCCCD);
            this.Controls.Add(this.btnCheckIn);
            this.Controls.Add(this.btnTimCCCD);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.txtCCCD);
            this.Controls.Add(this.lblSelectedPhong);
            this.Controls.Add(this.lblFilterTT);
            this.Controls.Add(this.lblFilterLoai);
            this.Controls.Add(this.cbFilterTrangThai);
            this.Controls.Add(this.cbFilterLoaiPhong);
            this.Controls.Add(this.dgvPhong);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống Quản lý Khách sạn & Dịch vụ (Hotel System)";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSoLuongDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDichVuDaDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.ComboBox cbFilterLoaiPhong;
        private System.Windows.Forms.ComboBox cbFilterTrangThai;
        private System.Windows.Forms.Label lblFilterLoai;
        private System.Windows.Forms.Label lblFilterTT;
        private System.Windows.Forms.Label lblSelectedPhong;
        private System.Windows.Forms.TextBox txtCCCD;
        private System.Windows.Forms.TextBox txtHoTen;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Button btnTimCCCD;
        private System.Windows.Forms.Button btnCheckIn;
        private System.Windows.Forms.Label lblCCCD;
        private System.Windows.Forms.Label lblHoTen;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.ComboBox cbDichVu;
        private System.Windows.Forms.NumericUpDown nudSoLuongDV;
        private System.Windows.Forms.Button btnGoiDichVu;
        private System.Windows.Forms.DataGridView dgvDichVuDaDung;
        private System.Windows.Forms.Button btnCheckOut;
        private System.Windows.Forms.Button btnDonDepXong;
    }
}