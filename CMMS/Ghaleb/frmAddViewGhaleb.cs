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
    public partial class frmAddViewGhaleb : Form
    {
        public long PropIDGhaleb { get; set; }
        public frmAddViewGhaleb()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                dbs_CMMSEntities1 obj = new dbs_CMMSEntities1();
                tbl_UsableMaterialsGhaleb tbl = new tbl_UsableMaterialsGhaleb();
                tbl.IDGhaleb = PropIDGhaleb;
                tbl.Caption = txtCaption.Text;
                tbl.Type = cmbType.Text;
                tbl.TimeServices = txtTimeServices.Text;
                tbl.UsableGhataatYadaki = txtUsableGhataatYadaki.Text;
                tbl.UsableMaterials = txtUsableMaterials.Text;
                tbl.Peryod = txtperyod.Text;
                obj.tbl_UsableMaterialsGhaleb.Add(tbl);
                obj.SaveChanges();
                MessageBox.Show("اطلاعات با موفقیت ذخیره گردید", "ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطای رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddViewGhaleb_Load(object sender, EventArgs e)
        {

        }
    }
}
