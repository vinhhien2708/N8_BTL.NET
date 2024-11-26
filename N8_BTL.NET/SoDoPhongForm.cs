using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace KaraokeManager
{
    public partial class SoDoPhongForm : Form
    {
        private string connectionString = @"Data Source= HAI412\SQLEXPRESS;Initial Catalog=KaraokeDb;Integrated Security=True";

        public SoDoPhongForm()
        {
            InitializeComponent();
            LoadPhong();
        }

        private void LoadPhong()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ma_phong, ten_phong, trang_thai FROM phong";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Button btnPhong = new Button();
                        btnPhong.Width = 150;
                        btnPhong.Height = 100;
                        btnPhong.Text = reader["ten_phong"].ToString() + "\n" +
                                      reader["trang_thai"].ToString();
                        btnPhong.Tag = reader["ma_phong"].ToString();

                        if (reader["trang_thai"].ToString() == "Trống")
                            btnPhong.BackColor = Color.LightGreen;
                        else
                            btnPhong.BackColor = Color.Red;

                        btnPhong.Click += BtnPhong_Click;
                        flowLayoutPanel1.Controls.Add(btnPhong);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message);
                }
            }
        }

        private void BtnPhong_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int maPhong = int.Parse(btn.Tag.ToString());
            ChiTietPhongForm chiTietPhong = new ChiTietPhongForm(maPhong);
            chiTietPhong.ShowDialog();

            // Sau khi đóng form chi tiết, cập nhật lại trạng thái phòng
            flowLayoutPanel1.Controls.Clear();
            LoadPhong();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}