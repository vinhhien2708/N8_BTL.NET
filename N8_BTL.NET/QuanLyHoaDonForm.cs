
// QuanLyHoaDonForm.cs
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using ClosedXML.Excel;
using N8_BTL.NET;

namespace KaraokeManager
{
    public partial class QuanLyHoaDonForm : Form
    {
        private string connectionString = @"Data Source= HAI412\SQLEXPRESS;Initial Catalog=KaraokeDb;Integrated Security=True";
        private DataTable dtHoaDon;

        public QuanLyHoaDonForm()
        {
            InitializeComponent();

            // Khởi tạo giá trị mặc định cho DateTimePicker
            dtpTuNgay.Value = DateTime.Today;
            dtpDenNgay.Value = DateTime.Today;

            btnTimKiem.Click += BtnTimKiem_Click;
            btnXemChiTiet.Click += BtnXemChiTiet_Click;
            btnXuatExcel.Click += BtnXuatExcel_Click;

            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT hd.ma_hoa_don, p.ten_phong, 
                               hd.thoi_gian_bat_dau, hd.thoi_gian_ket_thuc,
                               DATEDIFF(MINUTE, hd.thoi_gian_bat_dau, hd.thoi_gian_ket_thuc) as thoi_gian_su_dung,
                               hd.tong_tien
                               FROM hoa_don hd
                               JOIN phong p ON hd.ma_phong = p.ma_phong
                               WHERE hd.trang_thai = N'Đã thanh toán'
                               AND CONVERT(date, hd.thoi_gian_bat_dau) BETWEEN @TuNgay AND @DenNgay
                               ORDER BY hd.thoi_gian_bat_dau DESC";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@TuNgay", dtpTuNgay.Value.Date);
                cmd.Parameters.AddWithValue("@DenNgay", dtpDenNgay.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dtHoaDon = new DataTable();
                da.Fill(dtHoaDon);

                dgvHoaDon.DataSource = dtHoaDon;

                // Định dạng các cột
                dgvHoaDon.Columns["ma_hoa_don"].HeaderText = "Mã HĐ";
                dgvHoaDon.Columns["ten_phong"].HeaderText = "Phòng";
                dgvHoaDon.Columns["thoi_gian_bat_dau"].HeaderText = "Thời gian bắt đầu";
                dgvHoaDon.Columns["thoi_gian_ket_thuc"].HeaderText = "Thời gian kết thúc";
                dgvHoaDon.Columns["thoi_gian_su_dung"].HeaderText = "Thời gian sử dụng (phút)";
                dgvHoaDon.Columns["tong_tien"].HeaderText = "Tổng tiền";

                // Tính tổng doanh thu
                decimal tongDoanhThu = 0;
                foreach (DataRow row in dtHoaDon.Rows)
                {
                    tongDoanhThu += Convert.ToDecimal(row["tong_tien"]);
                }
                lblTongDoanhThu.Text = "Tổng doanh thu: " + tongDoanhThu.ToString("#,##0") + " VNĐ";
            }
        }

        private void BtnTimKiem_Click(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void BtnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (dgvHoaDon.CurrentRow != null)
            {
                int maHoaDon = Convert.ToInt32(dgvHoaDon.CurrentRow.Cells["ma_hoa_don"].Value);
                ChiTietHoaDonForm chiTietForm = new ChiTietHoaDonForm(maHoaDon);
                chiTietForm.ShowDialog();
            }
        }

        private void BtnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel Files|*.xlsx";
                sfd.FileName = "BaoCaoDoanhThu_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (XLWorkbook wb = new XLWorkbook())
                        {
                            var ws = wb.Worksheets.Add("Báo cáo doanh thu");

                            // Thêm tiêu đề
                            ws.Cell(1, 1).Value = "BÁO CÁO DOANH THU";
                            ws.Range(1, 1, 1, 6).Merge();
                            ws.Cell(1, 1).Style.Font.Bold = true;
                            ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                            ws.Cell(2, 1).Value = "Từ ngày: " + dtpTuNgay.Value.ToString("dd/MM/yyyy");
                            ws.Cell(2, 4).Value = "Đến ngày: " + dtpDenNgay.Value.ToString("dd/MM/yyyy");

                            // Thêm header
                            ws.Cell(4, 1).Value = "Mã HĐ";
                            ws.Cell(4, 2).Value = "Phòng";
                            ws.Cell(4, 3).Value = "Thời gian bắt đầu";
                            ws.Cell(4, 4).Value = "Thời gian kết thúc";
                            ws.Cell(4, 5).Value = "Thời gian sử dụng (phút)";
                            ws.Cell(4, 6).Value = "Tổng tiền";

                            // Định dạng header
                            var headerRange = ws.Range(4, 1, 4, 6);
                            headerRange.Style.Font.Bold = true;
                            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;

                            // Thêm dữ liệu
                            for (int i = 0; i < dtHoaDon.Rows.Count; i++)
                            {
                                ws.Cell(i + 5, 1).Value = (XLCellValue)dtHoaDon.Rows[i]["ma_hoa_don"];
                                ws.Cell(i + 5, 2).Value = (XLCellValue)dtHoaDon.Rows[i]["ten_phong"];
                                ws.Cell(i + 5, 3).Value = Convert.ToDateTime(dtHoaDon.Rows[i]["thoi_gian_bat_dau"]);
                                ws.Cell(i + 5, 4).Value = Convert.ToDateTime(dtHoaDon.Rows[i]["thoi_gian_ket_thuc"]);
                                ws.Cell(i + 5, 5).Value = (XLCellValue)dtHoaDon.Rows[i]["thoi_gian_su_dung"];
                                ws.Cell(i + 5, 6).Value = Convert.ToDecimal(dtHoaDon.Rows[i]["tong_tien"]);
                            }

                            // Định dạng cột ngày tháng
                            ws.Column(3).Style.DateFormat.Format = "dd/MM/yyyy HH:mm:ss";
                            ws.Column(4).Style.DateFormat.Format = "dd/MM/yyyy HH:mm:ss";

                            // Định dạng cột tiền
                            ws.Column(6).Style.NumberFormat.Format = "#,##0";

                            // Tổng doanh thu
                            int lastRow = dtHoaDon.Rows.Count + 5;
                            ws.Cell(lastRow, 5).Value = "Tổng doanh thu:";
                            ws.Cell(lastRow, 5).Style.Font.Bold = true;
                            ws.Cell(lastRow, 6).FormulaA1 = $"SUM(F5:F{lastRow - 1})";
                            ws.Cell(lastRow, 6).Style.Font.Bold = true;
                            ws.Cell(lastRow, 6).Style.NumberFormat.Format = "#,##0";

                            // Tự động điều chỉnh độ rộng cột
                            ws.Columns().AdjustToContents();

                            wb.SaveAs(sfd.FileName);
                            MessageBox.Show("Xuất file Excel thành công!", "Thông báo");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Có lỗi khi xuất file: " + ex.Message, "Lỗi");
                    }
                }
            }
        }
    }
}