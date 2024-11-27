namespace KaraokeManager
{
    partial class ChiTietPhongForm
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

        private void InitializeComponent()
        {
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblThoiGianBatDau = new System.Windows.Forms.Label();
            this.lblThoiGianHienTai = new System.Windows.Forms.Label();
            this.cboLoaiSanPham = new System.Windows.Forms.ComboBox();
            this.cboSanPham = new System.Windows.Forms.ComboBox();
            this.numSoLuong = new System.Windows.Forms.NumericUpDown();
            this.btnThem = new System.Windows.Forms.Button();
            this.dgvChiTietHoaDon = new System.Windows.Forms.DataGridView();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPhong
            // 
            this.lblPhong.AutoSize = true;
            this.lblPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblPhong.Location = new System.Drawing.Point(328, 9);
            this.lblPhong.Name = "lblPhong";
            this.lblPhong.Size = new System.Drawing.Size(90, 24);
            this.lblPhong.TabIndex = 0;
            this.lblPhong.Text = "PHÒNG:";
            this.lblPhong.Click += new System.EventHandler(this.lblPhong_Click);
            // 
            // lblThoiGianBatDau
            // 
            this.lblThoiGianBatDau.AutoSize = true;
            this.lblThoiGianBatDau.Location = new System.Drawing.Point(12, 40);
            this.lblThoiGianBatDau.Name = "lblThoiGianBatDau";
            this.lblThoiGianBatDau.Size = new System.Drawing.Size(0, 13);
            this.lblThoiGianBatDau.TabIndex = 1;
            // 
            // lblThoiGianHienTai
            // 
            this.lblThoiGianHienTai.Location = new System.Drawing.Point(0, 0);
            this.lblThoiGianHienTai.Name = "lblThoiGianHienTai";
            this.lblThoiGianHienTai.Size = new System.Drawing.Size(100, 23);
            this.lblThoiGianHienTai.TabIndex = 2;
            // 
            // cboLoaiSanPham
            // 
            this.cboLoaiSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoaiSanPham.Location = new System.Drawing.Point(12, 80);
            this.cboLoaiSanPham.Name = "cboLoaiSanPham";
            this.cboLoaiSanPham.Size = new System.Drawing.Size(200, 21);
            this.cboLoaiSanPham.TabIndex = 3;
            // 
            // cboSanPham
            // 
            this.cboSanPham.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSanPham.Location = new System.Drawing.Point(218, 80);
            this.cboSanPham.Name = "cboSanPham";
            this.cboSanPham.Size = new System.Drawing.Size(200, 21);
            this.cboSanPham.TabIndex = 4;
            // 
            // numSoLuong
            // 
            this.numSoLuong.Location = new System.Drawing.Point(424, 80);
            this.numSoLuong.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuong.Name = "numSoLuong";
            this.numSoLuong.Size = new System.Drawing.Size(60, 20);
            this.numSoLuong.TabIndex = 5;
            this.numSoLuong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(490, 79);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 6;
            this.btnThem.Text = "Thêm";
            // 
            // dgvChiTietHoaDon
            // 
            this.dgvChiTietHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietHoaDon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChiTietHoaDon.Location = new System.Drawing.Point(12, 120);
            this.dgvChiTietHoaDon.Name = "dgvChiTietHoaDon";
            this.dgvChiTietHoaDon.ReadOnly = true;
            this.dgvChiTietHoaDon.Size = new System.Drawing.Size(760, 280);
            this.dgvChiTietHoaDon.TabIndex = 7;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(500, 410);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(0, 20);
            this.lblTongTien.TabIndex = 8;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.Location = new System.Drawing.Point(137, 410);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(75, 23);
            this.btnThanhToan.TabIndex = 9;
            this.btnThanhToan.Text = "Thanh toán";
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.Location = new System.Drawing.Point(15, 410);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 10;
            this.btnHuy.Text = "Hủy";
            // 
            // ChiTietPhongForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 441);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblThoiGianBatDau);
            this.Controls.Add(this.lblThoiGianHienTai);
            this.Controls.Add(this.cboLoaiSanPham);
            this.Controls.Add(this.cboSanPham);
            this.Controls.Add(this.numSoLuong);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.dgvChiTietHoaDon);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnHuy);
            this.MinimumSize = new System.Drawing.Size(800, 480);
            this.Name = "ChiTietPhongForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chi tiết phòng";
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietHoaDon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblThoiGianBatDau;
        private System.Windows.Forms.Label lblThoiGianHienTai;
        private System.Windows.Forms.ComboBox cboLoaiSanPham;
        private System.Windows.Forms.ComboBox cboSanPham;
        private System.Windows.Forms.NumericUpDown numSoLuong;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.DataGridView dgvChiTietHoaDon;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnHuy;
    }
}
