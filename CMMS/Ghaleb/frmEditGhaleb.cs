using CMMS.Helpers;
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
    public partial class frmEditGhaleb : Form
    {
        public long PropID { get; set; }
        public frmEditGhaleb()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dbs_CMMSEntities1 obj = new dbs_CMMSEntities1();
                var EditeData = obj.tbl_Ghaleb.Where(x => x.ID == PropID).First();
                EditeData.NameGhaleb = txtName.Text;
                EditeData.Code = txtCode.Text;
                EditeData.Vazn = txtVazn.Text;
                EditeData.Address = txtAddress.Text;
                EditeData.UsableMaterials = txtUsableMaterials.Text;
                EditeData.TypeGhaleb = cmbType.Text;
                EditeData.Tool = txtTool.Text;
                EditeData.Arz = txtArz.Text;
                EditeData.Ertefa = txtErtefa.Text;
                EditeData.OmreMofid = txtOmerMofid.Text;
                EditeData.Sazandeh = txtSazandeh.Text;
                EditeData.sharayetneghahdari = txtSharayetNegahdari.Text;
                EditeData.TarikhSakht = PersianDateTimeHelper.ConvertToDate(txtTarikhSakht.Text); 
                EditeData.tarikhShorooBeKar = PersianDateTimeHelper.ConvertToDate(txtTarikhShorooBeKar.Text);
                EditeData.TypeGiris = txtTypeGiris.Text;
                EditeData.VaziyatKharid = txtVaziyatKharid.Text;
                if(rdbFelezi.Checked)
                {
                    EditeData.VaziyatGhaleb = true;
                    EditeData.GensGhaleb = txtFelezi.Text;
                }
                else
                {
                    EditeData.VaziyatGhaleb = false;
                    EditeData.GensGhaleb = txtPelastic.Text;
                }

                obj.SaveChanges();
                MessageBox.Show("اطلاعات با موفقیت ویرایش گردید", "ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void frmEditGhaleb_Load(object sender, EventArgs e)
        {

        }

        private void rdbPelastic_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFelezi.Checked)
            {
                txtPelastic.Text = "";
                txtPelastic.Enabled = false;
                txtFelezi.Enabled = true;
            }
            else
            {
                txtFelezi.Text = "";
                txtFelezi.Enabled = false;
                txtPelastic.Enabled = true;
            }

        }
    }
}
