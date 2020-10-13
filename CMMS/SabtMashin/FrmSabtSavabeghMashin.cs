using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMMS.SabtMashin
{
    public partial class FrmSabtSavabeghMashin : Form
    {
        public FrmSabtSavabeghMashin()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAddSabtSavabeghMashin frm = new frmAddSabtSavabeghMashin();
            frm.ShowDialog();
        }
    }
}
