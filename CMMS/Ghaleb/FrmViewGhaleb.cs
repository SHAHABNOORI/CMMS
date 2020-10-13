using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMMS
{
    public partial class FrmViewGhaleb : Form
    {
        public FrmViewGhaleb()
        {
            InitializeComponent();
        }

        PersianCalendar pc = new PersianCalendar();
        public long PropIDGhaleb { get; set; }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport sti = new StiReport();
            sti.Load("Ghaleb ID.mrt");
            sti.RegData("tbl_UsableMaterialsGhaleb", dgvShenasnamehMashinAlat.DataSource);
            sti.Design();
            sti.Dictionary.Variables.Add("vbl_Date", pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString());
            sti.Dictionary.Variables.Add("vblNameGhaleb", txtName.Text);
            sti.Dictionary.Variables.Add("vblCode", txtCode.Text);
            sti.Dictionary.Variables.Add("vblTypeGhaleb", txtType.Text);
           
            sti.Dictionary.Variables.Add("vblVazn", txtVazn.Text);
            sti.Dictionary.Variables.Add("vblUsableMaterials", txtUsableMaterials.Text);
            sti.Dictionary.Variables.Add("vblAdress", txtAddress.Text);
            sti.Dictionary.Variables.Add("VblTool", txtTool.Text);
            sti.Dictionary.Variables.Add("VblArz", txtArz.Text);
            sti.Dictionary.Variables.Add("VblErtefa", txtErtefa.Text);
            sti.Dictionary.Variables.Add("VblTarikhSakht", txtTarikhSakht.Text);
            sti.Dictionary.Variables.Add("VbltarikhShorooBeKar", txtTarikhShorooBeKar.Text);
            sti.Dictionary.Variables.Add("Vblsharayetneghahdari", txtSharayetNegahdari.Text);
            sti.Dictionary.Variables.Add("VblVaziyatGhaleb", rdbFelezi.Checked);
            sti.Dictionary.Variables.Add("VblVaziyatKharid", txtVaziyatKharid.Text);
            sti.Dictionary.Variables.Add("VblSystemKhoonakKonnadeh", txtSystemKhoonakKonnadeh.Text);
            sti.Dictionary.Variables.Add("VblOmreMofid",txtOmreMofid.Text);
            sti.Dictionary.Variables.Add("VblSazandeh", txtSazandeh.Text);
            sti.Dictionary.Variables.Add("VblTypeGiris", txtTypeGiris.Text);
            if(rdbFelezi.Checked)
            {
                sti.Dictionary.Variables.Add("VblFelezi", txtFelezi.Text);
               
            }
            else
            {
                sti.Dictionary.Variables.Add("VblPelastic", txtPelastic.Text);
            }
            //sti.Compile();
            sti.Show();

            
        }


        void PopulateDataGridView()
        {
            try
            {


                using (dbs_CMMSEntities1 _db = new dbs_CMMSEntities1())
                {
                    dgvShenasnamehMashinAlat.DataSource = _db.tbl_UsableMaterialsGhaleb.Where(x=>x.IDGhaleb== PropIDGhaleb).ToList();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void FrmViewGhaleb_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAddViewGhaleb frm = new frmAddViewGhaleb();
            frm.PropIDGhaleb = this.PropIDGhaleb;
            frm.ShowDialog();
            PopulateDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            FrmEditViewGhaleb frm = new FrmEditViewGhaleb();
            frm.txtCaption.Text=model.Caption;
            frm.txtperyod.Text = model.Peryod;
            frm.txtTimeServices.Text = model.TimeServices;
            frm.txtUsableGhataatYadaki.Text = model.UsableGhataatYadaki;
            frm.cmbType.Text = model.Type;
            frm.txtUsableMaterials.Text = model.UsableMaterials;
            frm.PropID = model.ID;
            frm.ShowDialog();
            PopulateDataGridView();
        }
        tbl_UsableMaterialsGhaleb model = new tbl_UsableMaterialsGhaleb();
        private void dgvShenasnamehMashinAlat_Click(object sender, EventArgs e)
        {
            if (dgvShenasnamehMashinAlat.CurrentRow != null)
            {
                if (dgvShenasnamehMashinAlat.CurrentRow.Index != -1)
                {

                    model.ID = Convert.ToInt64(dgvShenasnamehMashinAlat.CurrentRow.Cells["ID"].Value);
                    dbs_CMMSEntities1 _db = new dbs_CMMSEntities1();
                    model = _db.tbl_UsableMaterialsGhaleb.Where(x => x.ID == model.ID).FirstOrDefault();

                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("آیا مطمن از حذف این محصول هستید ؟ ", "عملیات حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (dbs_CMMSEntities1 obj = new dbs_CMMSEntities1())
                    {
                        obj.tbl_UsableMaterialsGhaleb.Where(x => x.ID == model.ID).Load();
                        obj.tbl_UsableMaterialsGhaleb.Local.Clear();
                        obj.SaveChanges();
                    }
                    MessageBox.Show("اطلاعات با موفقیت حذف گردید", "عملیات حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateDataGridView();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
