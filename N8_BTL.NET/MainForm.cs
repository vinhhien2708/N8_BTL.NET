// MainForm.cs
using System;
using System.Windows.Forms;

namespace KaraokeManager
{
    public partial class MainForm : Form
    {
        private SoDoPhongForm soDoPhongForm;
        private QuanLyHoaDonForm quanLyHoaDonForm;

        public MainForm()
        {
            InitializeComponent();
            soDoPhongForm = new SoDoPhongForm();
            quanLyHoaDonForm = new QuanLyHoaDonForm();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Mặc định hiển thị form sơ đồ phòng
            LoadForm(soDoPhongForm);
        }

        private void LoadForm(Form form)
        {
            panelMain.Controls.Clear();
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            panelMain.Controls.Add(form);
            form.Show();
        }

        private void sơĐồPhòngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(soDoPhongForm);
        }

        private void quảnLýHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadForm(quanLyHoaDonForm);
        }
    }
}
