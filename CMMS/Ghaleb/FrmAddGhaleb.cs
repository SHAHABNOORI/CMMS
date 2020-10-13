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
    public partial class FrmAddGhaleb : Form
    {
        public FrmAddGhaleb()
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
                tbl_Ghaleb tbl = new tbl_Ghaleb();
                tbl.Code = txtCode.Text;
                tbl.NameGhaleb = txtName.Text;
                tbl.TypeGhaleb = cmbType.Text;
                tbl.Tool = txtTool.Text;
                tbl.Arz = txtArz.Text;
                tbl.Ertefa = txtErtefa.Text;
                tbl.Vazn = txtVazn.Text;
                tbl.VaziyatKharid = txtVaziyatKharid.Text;
                tbl.SystemKhoonakKonnadeh = txtSystemKhoonakKonnadeh.Text;
                tbl.TypeGiris = txtTypeGiris.Text;
                tbl.OmreMofid = txtOmerMofid.Text;
                tbl.Sazandeh = txtSazandeh.Text;
                tbl.TarikhSakht= PersianDateTimeHelper.ConvertToDate(txtTarikhSakht.Text);
                tbl.tarikhShorooBeKar = PersianDateTimeHelper.ConvertToDate(txtTarikhShorooBeKar.Text);
                if (rdbFelezi.Checked)
                {
                    tbl.VaziyatGhaleb = true;
                    tbl.GensGhaleb = txtFelezi.Text;
                }
                else
                {
                    tbl.VaziyatGhaleb = false;
                    tbl.GensGhaleb = txtPelastic.Text;
                }

                tbl.UsableMaterials = txtUsableMaterials.Text;
                tbl.Address = txtAddress.Text;
                tbl.sharayetneghahdari = txtSharayetNegahdari.Text;
                obj.tbl_Ghaleb.Add(tbl);
                obj.SaveChanges();
                MessageBox.Show("اطلاعات با موفقیت ذخیره گردید", "ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطای رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        private void FrmAddGhaleb_Load(object sender, EventArgs e)
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
