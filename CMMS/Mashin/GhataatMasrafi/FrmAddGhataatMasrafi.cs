using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMMS.Mashin.GhataatMasrafi
{
    public partial class FrmAddGhataatMasrafi : Form
    {
        public long PropIDAnbarGhataatYadaki { get; set; }
        public long PropIDShenasnamehMoshinAlat { get; set; }
        public FrmAddGhataatMasrafi()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FrmSearchAnbarGhataatYadaki frm = new FrmSearchAnbarGhataatYadaki(this);
            frm.ShowDialog();
        }

        private void FrmAddGhataatMasrafi_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                dbs_CMMSEntities1 obj = new dbs_CMMSEntities1();
                tbl_GhataatMasrafiMashinAlat tbl = new tbl_GhataatMasrafiMashinAlat();
                tbl.IDShenasnamehMoshinAlat = PropIDShenasnamehMoshinAlat;
                tbl.IDAnbarGhataatYadaki = PropIDAnbarGhataatYadaki;
                tbl.Tedad =int.Parse( txtTedad.Text);
                obj.tbl_GhataatMasrafiMashinAlat.Add(tbl);
                obj.SaveChanges();
                MessageBox.Show("اطلاعات با موفقیت ذخیره گردید", "ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطای رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

        }
    }
}
