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
    public partial class FrmEditViewGhaleb : Form
    {
        public long PropID { get; set; }
        public FrmEditViewGhaleb()
        {
            InitializeComponent();
        }

        private void FrmEditViewGhaleb_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dbs_CMMSEntities1 obj = new dbs_CMMSEntities1();
                var EditeData = obj.tbl_UsableMaterialsGhaleb.Where(x => x.ID == PropID).First();
                EditeData.Caption = txtCaption.Text;
                EditeData.Type = cmbType.Text;
                EditeData.TimeServices = txtTimeServices.Text;
                EditeData.UsableGhataatYadaki = txtUsableGhataatYadaki.Text;
                EditeData.Peryod = txtperyod.Text;
                EditeData.UsableMaterials = txtUsableMaterials.Text;
                

                obj.SaveChanges();
                MessageBox.Show("اطلاعات با موفقیت ویرایش گردید", "ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
