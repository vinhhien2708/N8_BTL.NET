using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KaraokeManager
{
    public partial class ChiTietHoaDonForm : Form
    {
        private string connectionString = "your_connection_string_here";
        private int maHoaDon;

        public ChiTietHoaDonForm(int maHoaDon)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;

            btnDong.Click += BtnDong_Click;

            LoadChiTietHoaDon();
        }

        private void LoadChiTietHoaDon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Lấy thông tin hóa đơn
                string queryHoaDon = @"SELECT hd.ma_hoa_don, p.ten_phong, p.gia_phong,
                                    hd.thoi_gian_bat_dau, hd.thoi_gian_ket_thuc,
                                    DATEDIFF(MINUTE, hd.thoi_gian_bat_dau, hd.thoi_gian_ket_thuc) as thoi_gian_su_dung,
                                    hd.tong_tien
                                    FROM hoa_don hd
                                    JOIN phong p ON hd.ma_phong = p.ma_phong
                                    WHERE hd.ma_hoa_don = @MaHoaDon";

                SqlCommand cmd = new SqlCommand(queryHoaDon, conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        lblMaHoaDon.Text = "Hóa đơn #" + reader["ma_hoa_don"].ToString();
                        lblPhong.Text = "Phòng: " + reader["ten_phong"].ToString();
                        lblThoiGianBatDau.Text = "Thời gian bắt đầu: " + Convert.ToDateTime(reader["thoi_gian_bat_dau"]).ToString("dd/MM/yyyy HH:mm:ss");
                        lblThoiGianKetThuc.Text = "Thời gian kết thúc: " + Convert.ToDateTime(reader["thoi_gian_ket_thuc"]).ToString("dd/MM/yyyy HH:mm:ss");

                        int thoiGianSuDung = Convert.ToInt32(reader["thoi_gian_su_dung"]);
                        decimal giaPhong = Convert.ToDecimal(reader["gia_phong"]);
                        decimal tienPhong = Math.Ceiling((decimal)thoiGianSuDung / 60) * giaPhong;

                        lblThoiGianSuDung.Text = "Thời gian sử dụng: " + thoiGianSuDung + " phút";
                        lblTienPhong.Text = "Tiền phòng: " + tienPhong.ToString("#,##0") + " VNĐ";
                    }
                }

                // Lấy chi tiết dịch vụ
                string queryDichVu = @"SELECT dv.ten_dich_vu, cthd.so_luong, dv.don_gia,
                                     (cthd.so_luong * dv.don_gia) as thanh_tien
                                     FROM chi_tiet_hoa_don cthd
                                     JOIN dich_vu dv ON cthd.ma_dich_vu = dv.ma_dich_vu
                                     WHERE cthd.ma_hoa_don = @MaHoaDon";

                SqlDataAdapter da = new SqlDataAdapter(queryDichVu, conn);
                da.SelectCommand.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                DataTable dtDichVu = new DataTable();
                da.Fill(dtDichVu);

                dgvDichVu.DataSource = dtDichVu;

                // Định dạng các cột
                dgvDichVu.Columns["ten_dich_vu"].HeaderText = "Dịch vụ";
                dgvDichVu.Columns["so_luong"].HeaderText = "Số lượng";
                dgvDichVu.Columns["don_gia"].HeaderText = "Đơn giá";
                dgvDichVu.Columns["thanh_tien"].HeaderText = "Thành tiền";

                // Định dạng số tiền
                dgvDichVu.Columns["don_gia"].DefaultCellStyle.Format = "#,##0";
                dgvDichVu.Columns["thanh_tien"].DefaultCellStyle.Format = "#,##0";

                // Tính tổng tiền dịch vụ
                decimal tongTienDichVu = 0;
                foreach (DataRow row in dtDichVu.Rows)
                {
                    tongTienDichVu += Convert.ToDecimal(row["thanh_tien"]);
                }
                lblTienDichVu.Text = "Tiền dịch vụ: " + tongTienDichVu.ToString("#,##0") + " VNĐ";

                // Lấy tổng tiền hóa đơn
                cmd = new SqlCommand("SELECT tong_tien FROM hoa_don WHERE ma_hoa_don = @MaHoaDon", conn);
                cmd.Parameters.AddWithValue("@MaHoaDon", maHoaDon);

                object tongTien = cmd.ExecuteScalar();
                if (tongTien != null && tongTien != DBNull.Value)
                {
                    lblTongTien.Text = "TỔNG CỘNG: " + Convert.ToDecimal(tongTien).ToString("#,##0") + " VNĐ";
                }
            }
        }

        private void BtnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}