// FrmMain.cs
using System;
using System.Windows.Forms;

namespace KaraokeManager
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void mnuSoDoPhong_Click(object sender, EventArgs e)
        {
            var frmSoDoPhong = new FrmSoDoPhong();
            frmSoDoPhong.ShowDialog();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
