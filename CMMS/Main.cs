using CMMS.SabtMashin;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMMS
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //new SplashScreen().Close();
          

        }

        private void ribbonPanel1_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem14_Click(object sender, EventArgs e)
        {

        }

        private void btnShenasnamehMashinAlat_Click(object sender, EventArgs e)
        {
           
        }

        private void mbtnMashinAlat_Click(object sender, EventArgs e)
        {
            frmShenasnamehMashinAlat frm = new frmShenasnamehMashinAlat();
            frm.MdiParent = this;
            frm.Show();

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void mbtnGhataatYadaki_Click(object sender, EventArgs e)
        {
            frmAnbarGhtaatYadaki frm = new frmAnbarGhtaatYadaki();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mbtnGhalebha_Click(object sender, EventArgs e)
        {
            FrmGhaleb frm = new FrmGhaleb();
            frm.MdiParent = this;
            frm.Show();
        }

        private void mbtnSavabeghMaShin_Click(object sender, EventArgs e)
        {
            FrmSabtSavabeghMashin frm = new FrmSabtSavabeghMashin();
            frm.ShowDialog();
        }
    }
}
