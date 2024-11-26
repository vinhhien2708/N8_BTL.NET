// ChiTietPhongForm.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KaraokeManager
{
    public partial class ChiTietPhongForm : Form
    {
        private string connectionString = @"Data Source= HAI412\SQLEXPRESS;Initial Catalog=KaraokeDb;Integrated Security=True";
        private int maPhong;
        private int maHoaDon;
        private DateTime thoiGianBatDau;
        private Timer timer;

        public ChiTietPhongForm(int maPhong)
        {
            InitializeComponent();
            this.maPhong = maPhong;

            // Khởi tạo timer để cập nhật thời gian
            timer = new Timer();
            timer.Interval = 1000; // 1 giây
            timer.Tick += Timer_Tick;

            LoadPhongInfo();
            LoadLoaiSanPham();

            cboLoaiSanPham.SelectedIndexChanged += CboLoaiSanPham_SelectedIndexChanged;
            btnThem.Click += BtnThem_Click;
            btnThanhToan.Click += BtnThanhToan_Click;
            btnHuy.Click += BtnHuy_Click;
        }

        private void LoadPhongInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy thông tin phòng
                string queryPhong = "SELECT ten_phong FROM phong WHERE ma_phong = @MaPhong";
                SqlCommand cmdPhong = new SqlCommand(queryPhong, conn);
                cmdPhong.Parameters.AddWithValue("@MaPhong", maPhong);
                string tenPhong = cmdPhong.ExecuteScalar().ToString();
                lblPhong.Text = "PHÒNG: " + tenPhong;

                // Kiểm tra và tạo hóa đơn mới nếu chưa có
                string queryHoaDon = @"SELECT ma_hoa_don, thoi_gian_bat_dau 
                                     FROM hoa_don 
                                     WHERE ma_phong = @MaPhong AND trang_thai = 'Đang phục vụ'";
                SqlCommand cmdHoaDon = new SqlCommand(queryHoaDon, conn);
                cmdHoaDon.Parameters.AddWithValue("@MaPhong", maPhong);

                using (SqlDataReader reader = cmdHoaDon.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        maHoaDon = reader.GetInt32(0);
                        thoiGianBatDau = reader.GetDateTime(1);
                    }
                    else
                    {
                        reader.Close();
                        // Tạo hóa đơn mới
                        thoiGianBatDau = DateTime.Now;
                        string queryInsert = @"INSERT INTO hoa_don (ma_phong, thoi_gian_bat_dau, trang_thai) 
                                            VALUES (@MaPhong, @ThoiGianBatDau, 'Đang phục vụ');
                                            SELECT SCOPE_IDENTITY();";
                        SqlCommand cmdInsert = new SqlCommand(queryInsert, conn);
                        cmdInsert.Parameters.AddWithValue("@MaPhong", maPhong);
                        cmdInsert.Parameters.AddWithValue("@ThoiGianBatDau", thoiGianBatDau);
                        maHoaDon = Convert.ToInt32(cmdInsert.ExecuteScalar());
                    }
                }
            }

            lblThoiGianBatDau.Text = "Thời gian bắt đầu: " + thoiGianBatDau.ToString("dd/MM/yyyy HH:mm:ss");
            timer.Start();
            LoadChiTietHoaDon();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan thoiGianSuDung = DateTime.Now - thoiGianBatDau;
            lblThoiGianHienTai.Text = string.Format("Thời gian sử dụng: {0:00}:{1:00}:{2:00}",
                (int)thoiGianSuDung.TotalHours,
                thoiGianSuDung.Minutes,
                thoiGianSuDung.Seconds);
        }

        private void LoadLoaiSanPham()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT ma_loai, ten_loai FROM loai_san_pham";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cboLoaiSanPham.DisplayMember = "ten_loai";
                cboLoaiSanPham.ValueMember = "ma_loai";
                cboLoaiSanPham.DataSource = dt;
            }
        }

        private void CboLoaiSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLoaiSanPham.SelectedValue != null)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT ma_san_pham, ten_san_pham FROM san_pham WHERE ma_loai = @MaLoai";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaLoai", cboLoaiSanPham.SelectedValue);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cboSanPham.DisplayMember = "ten_san_pham";
                    cboSanPham.ValueMember = "ma_san_pham";
                    cboSanPham.DataSource = dt;
                }
            }
        }

        private void LoadChiTietHoaDon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT sp.ten_san_pham, ct.so_luong, sp.gia, (ct.so_luong * sp.gia) as thanh_tien
                               FROM chi_tiet_hoa_don ct
                               JOIN san_pham sp ON ct.ma_san_pham = sp.ma_san_pham
                               WHERE ct.ma_hoa_don = @MaHoaDon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvChiTietHoaDon.DataSource = dt;

                // Tính tổng tiền
                decimal tongTien = 0;
                foreach (DataRow row in dt.Rows)
                {
                    tongTien += Convert.ToDecimal(row["thanh_tien"]);
                }
                lblTongTien.Text = "Tổng tiền: " + tongTien.ToString("#,##0") + " VNĐ";
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            if (cboSanPham.SelectedValue != null)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO chi_tiet_hoa_don (ma_hoa_don, ma_san_pham, so_luong, gia)
                                   VALUES (@MaHoaDon, @MaSanPham, @SoLuong, 
                                   (SELECT gia FROM san_pham WHERE ma_san_pham = @MaSanPham))";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmd.Parameters.AddWithValue("@MaSanPham", cboSanPham.SelectedValue);
                    cmd.Parameters.AddWithValue("@SoLuong", numSoLuong.Value);
                    cmd.ExecuteNonQuery();
                }
                LoadChiTietHoaDon();
            }
        }

        private void BtnThanhToan_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE hoa_don 
                               SET thoi_gian_ket_thuc = GETDATE(),
                                   trang_thai = 'Đã thanh toán',
                                   tong_tien = (SELECT SUM(so_luong * gia) 
                                              FROM chi_tiet_hoa_don 
                                              WHERE ma_hoa_don = @MaHoaDon)
                               WHERE ma_hoa_don = @MaHoaDon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                cmd.ExecuteNonQuery();

                // Cập nhật trạng thái phòng
                query = "UPDATE phong SET trang_thai = N'Trống' WHERE ma_phong = @MaPhong";
                cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                cmd.ExecuteNonQuery();
            }
            this.Close();
        }

        private void BtnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc muốn hủy?", "Xác nhận",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Xóa chi tiết hóa đơn
                    string query = "DELETE FROM chi_tiet_hoa_don WHERE ma_hoa_don = @MaHoaDon";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmd.ExecuteNonQuery();

                    // Xóa hóa đơn
                    query = "DELETE FROM hoa_don WHERE ma_hoa_don = @MaHoaDon";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);
                    cmd.ExecuteNonQuery();

                    // Cập nhật trạng thái phòng
                    query = "UPDATE phong SET trang_thai = N'Trống' WHERE ma_phong = @MaPhong";
                    cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmd.ExecuteNonQuery();
                }
                this.Close();
            }
        }
    }
}