// FrmSoDoPhong.cs
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace KaraokeManager
{
    public partial class FrmSoDoPhong : Form
    {
        private readonly DbHelper db = new DbHelper();

        public FrmSoDoPhong()
        {
            InitializeComponent();
            LoadDanhSachPhong();
        }

        private void LoadDanhSachPhong()
        {
            flpDanhSachPhong.Controls.Clear();

            using (var conn = db.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM phong ORDER BY ten_phong";
                using (var cmd = new SqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var btn = new Button
                            {
                                Width = 150,
                                Height = 100,
                                Text = $"{reader["ten_phong"]}\n{reader["trang_thai"]}",
                                Tag = reader["ma_phong"],
                                BackColor = reader["trang_thai"].ToString() == "Trống" ? Color.LightGreen : Color.LightPink
                            };
                            btn.Click += Btn_Click;
                            flpDanhSachPhong.Controls.Add(btn);
                        }
                    }
                }
            }
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            int maPhong = (int)btn.Tag;
            var frmDatPhong = new FrmDatPhong(maPhong);
            frmDatPhong.ShowDialog();
            LoadDanhSachPhong(); // Reload sau khi đặt phòng
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
        }
    }
}