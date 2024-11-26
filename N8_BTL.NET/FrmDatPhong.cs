// FrmDatPhong.cs
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace KaraokeManager
{
    public partial class FrmDatPhong : Form
    {
        private readonly int maPhong;
        private readonly DbHelper db = new DbHelper();

        public FrmDatPhong(int maPhong)
        {
            InitializeComponent();
            this.maPhong = maPhong;
            LoadThongTinPhong();
        }

        private void LoadThongTinPhong()
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM phong WHERE ma_phong = @MaPhong";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["trang_thai"].ToString() != "Trống")
                            {
                                btnDatPhong.Enabled = false;
                                btnDatPhong.Text = "Phòng đang được sử dụng";
                            }

                            lblPhong.Text = reader["ten_phong"].ToString();
                        }
                    }
                }
            }
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "UPDATE phong SET trang_thai = N'Đang sử dụng' WHERE ma_phong = @MaPhong";
                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MaPhong", maPhong);
                    cmd.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}