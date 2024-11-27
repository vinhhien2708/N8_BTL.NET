namespace KaraokeManager
{
    partial class ChiTietHoaDonForm
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
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.lblPhong = new System.Windows.Forms.Label();
            this.lblThoiGianBatDau = new System.Windows.Forms.Label();
            this.lblThoiGianKetThuc = new System.Windows.Forms.Label();
            this.lblThoiGianSuDung = new System.Windows.Forms.Label();
            this.lblTienPhong = new System.Windows.Forms.Label();
            this.dgvDichVu = new System.Windows.Forms.DataGridView();
            this.lblTienDichVu = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();

            // 
            // lblMaHoaDon
            //
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblMaHoaDon.Location = new System.Drawing.Point(12, 9);
            this.lblMaHoaDon.Size = new System.Drawing.Size(200, 20);

            // 
            // lblPhong
            //  
            this.lblPhong.AutoSize = true;
            this.lblPhong.Location = new System.Drawing.Point(12, 40);
            this.lblPhong.Size = new System.Drawing.Size(150, 13);

            //
            // lblThoiGianBatDau
            //
            this.lblThoiGianBatDau.AutoSize = true;
            this.lblThoiGianBatDau.Location = new System.Drawing.Point(12, 65);
            this.lblThoiGianBatDau.Size = new System.Drawing.Size(200, 13);

            //
            // lblThoiGianKetThuc
            //
            this.lblThoiGianKetThuc.AutoSize = true;
            this.lblThoiGianKetThuc.Location = new System.Drawing.Point(12, 90);
            this.lblThoiGianKetThuc.Size = new System.Drawing.Size(200, 13);

            //
            // lblThoiGianSuDung
            //
            this.lblThoiGianSuDung.AutoSize = true;
            this.lblThoiGianSuDung.Location = new System.Drawing.Point(12, 115);
            this.lblThoiGianSuDung.Size = new System.Drawing.Size(200, 13);

            //
            // lblTienPhong
            //
            this.lblTienPhong.AutoSize = true;
            this.lblTienPhong.Location = new System.Drawing.Point(12, 140);
            this.lblTienPhong.Size = new System.Drawing.Size(200, 13);

            //
            // dgvDichVu
            //
            this.dgvDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDichVu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDichVu.Location = new System.Drawing.Point(12, 170);
            this.dgvDichVu.Name = "dgvDichVu";
            this.dgvDichVu.Size = new System.Drawing.Size(560, 200);
            this.dgvDichVu.ReadOnly = true;

            //
            // lblTienDichVu
            //
            this.lblTienDichVu.AutoSize = true;
            this.lblTienDichVu.Location = new System.Drawing.Point(12, 380);
            this.lblTienDichVu.Size = new System.Drawing.Size(200, 13);

            //
            // lblTongTien
            //
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Location = new System.Drawing.Point(12, 405);
            this.lblTongTien.Size = new System.Drawing.Size(200, 20);

            //
            // btnDong
            //
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Location = new System.Drawing.Point(497, 405);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(75, 23);
            this.btnDong.Text = "Đóng";

            //
            // ChiTietHoaDonForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 441);
            this.Controls.Add(this.lblMaHoaDon);
            this.Controls.Add(this.lblPhong);
            this.Controls.Add(this.lblThoiGianBatDau);
            this.Controls.Add(this.lblThoiGianKetThuc);
            this.Controls.Add(this.lblThoiGianSuDung);
            this.Controls.Add(this.lblTienPhong);
            this.Controls.Add(this.dgvDichVu);
            this.Controls.Add(this.lblTienDichVu);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.btnDong);
            this.MinimumSize = new System.Drawing.Size(600, 480);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiết hóa đơn";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.Label lblThoiGianBatDau;
        private System.Windows.Forms.Label lblThoiGianKetThuc;
        private System.Windows.Forms.Label lblThoiGianSuDung;
        private System.Windows.Forms.Label lblTienPhong;
        private System.Windows.Forms.DataGridView dgvDichVu;
        private System.Windows.Forms.Label lblTienDichVu;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnDong;
    }
}