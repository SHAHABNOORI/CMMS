using CMMS.Dtos;
using CMMS.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMMS
{
    public partial class FrmGhaleb : Form
    {
        public FrmGhaleb()
        {
            InitializeComponent();
        }

        private void FrmGhaleb_Load(object sender, EventArgs e)
        {

            PopulateDataGridView();
        }
        
        //string VaziyatGhalebToString(bool Vaziyat)
        //{
        //    if(Vaziyat)
        //    return "";
        //    else ""
        //}
        void PopulateDataGridView()
        {
            try
            {
                List<ShenasNamehGalebDto> fillData = new List<ShenasNamehGalebDto>();

                using (var db = new dbs_CMMSEntities1())
                {
                    var result = db.tbl_Ghaleb.ToList();
                    foreach (var item in result)
                    {
                        fillData.Add(new ShenasNamehGalebDto()
                        {
                            ID = item.ID,
                            Code = item.Code,
                            NameGhaleb = item.NameGhaleb,
                            GensGhaleb = item.GensGhaleb,
                            Ertefa = item.Ertefa,
                            Arz = item.Arz,
                            Address = item.Address,
                            sharayetneghahdari = item.sharayetneghahdari,
                            SystemKhoonakKonnadeh = item.SystemKhoonakKonnadeh,
                            Tool = item.Tool,
                            TypeGhaleb=item.TypeGhaleb,
                            TypeGiris=item.TypeGiris,
                            UsableMaterials=item.UsableMaterials,
                            VaziyatGhaleb=item.VaziyatGhaleb,
                            VaziyatKharid=item.VaziyatKharid,
                            OmreMofid=item.OmreMofid,
                            Sazandeh=item.Sazandeh,
                            Vazn=item.Vazn,
                            TarikhSakht= PersianDateTimeHelper.FaDate(item.TarikhSakht),
                            tarikhShorooBeKar=PersianDateTimeHelper.FaDate(item.tarikhShorooBeKar)
                        }) ;
                       
                    }
                }
                dgvShenasnamehMashinAlat.DataSource = fillData;

            }
            catch (Exception ex)
            {
               
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmAddGhaleb frm = new FrmAddGhaleb();
            frm.ShowDialog();
            PopulateDataGridView();
        }
        tbl_Ghaleb model = new tbl_Ghaleb();
        private void dgvShenasnamehMashinAlat_Click(object sender, EventArgs e)
        {
            if (dgvShenasnamehMashinAlat.CurrentRow != null)
            {
                if (dgvShenasnamehMashinAlat.CurrentRow.Index != -1)
                {

                    model.ID = Convert.ToInt64(dgvShenasnamehMashinAlat.CurrentRow.Cells["ID"].Value);
                    dbs_CMMSEntities1 _db = new dbs_CMMSEntities1();
                    model = _db.tbl_Ghaleb.Where(x => x.ID == model.ID).FirstOrDefault();

                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditGhaleb frm = new frmEditGhaleb();
            frm.PropID = model.ID;
            frm.txtName.Text = model.NameGhaleb;
            frm.txtCode.Text = model.Code;
            frm.cmbType.Text = model.TypeGhaleb;    
            frm.txtVazn.Text = model.Vazn;
            frm.txtUsableMaterials.Text = model.UsableMaterials;
            frm.txtAddress.Text = model.Address;

            frm.txtTool.Text = model.Tool;
            frm.txtArz.Text = model.Arz;
            frm.txtErtefa.Text = model.Ertefa;
            frm.txtOmerMofid.Text = model.OmreMofid;
            frm.txtSazandeh.Text = model.Sazandeh;
            frm.txtSharayetNegahdari.Text = model.sharayetneghahdari;
            frm.txtSystemKhoonakKonnadeh.Text = model.SystemKhoonakKonnadeh;
            frm.txtTarikhSakht.Text = PersianDateTimeHelper.FaDate(model.TarikhSakht);
            frm.txtTarikhShorooBeKar.Text = PersianDateTimeHelper.FaDate(model.tarikhShorooBeKar); 
            frm.txtTypeGiris.Text = model.TypeGiris;
            frm.txtVaziyatKharid.Text = model.VaziyatKharid;
            if (model.VaziyatGhaleb != null)
            {
                if (model.VaziyatGhaleb == true)
                {
                    frm.rdbFelezi.Checked = true;
                    frm.txtFelezi.Text = model.GensGhaleb;

                }
                else
                {
                    frm.rdbPelastic.Checked = true;
                    frm.txtPelastic.Text = model.GensGhaleb;
                }
            }

           
            frm.ShowDialog();
            PopulateDataGridView();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("آیا مطمن از حذف این محصول هستید ؟ ", "عملیات حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    using (dbs_CMMSEntities1 obj = new dbs_CMMSEntities1())
                    {
                        obj.tbl_Ghaleb.Where(x => x.ID == model.ID).Load();
                        obj.tbl_Ghaleb.Local.Clear();
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {


                using (dbs_CMMSEntities1 _db = new dbs_CMMSEntities1())
                {
                    dgvShenasnamehMashinAlat.DataSource = _db.tbl_Ghaleb.Where(x=>x.Code.Contains(txtSearch.Text) && x.NameGhaleb.Contains(txtSearch.Text)).ToList();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            FrmViewGhaleb frm = new FrmViewGhaleb();
            frm.txtName.Text = model.NameGhaleb;
            frm.txtCode.Text = model.Code;
            frm.txtUsableMaterials.Text = model.UsableMaterials;
            frm.txtType.Text = model.TypeGhaleb;
            frm.txtAddress.Text = model.Address;
            frm.txtVazn.Text = model.Vazn;
            frm.PropIDGhaleb = model.ID;
            frm.txtTool.Text = model.Tool;
            frm.txtArz.Text = model.Arz;
            frm.txtErtefa.Text = model.Ertefa;
            frm.txtTarikhSakht.Text = PersianDateTimeHelper.FaDate(model.TarikhSakht);
            frm.txtTarikhShorooBeKar.Text = PersianDateTimeHelper.FaDate(model.tarikhShorooBeKar);
            frm.txtSharayetNegahdari.Text = model.sharayetneghahdari;
            frm.txtTypeGiris.Text = model.TypeGiris;
            frm.txtVaziyatKharid.Text = model.VaziyatKharid;
            frm.txtSystemKhoonakKonnadeh.Text = model.SystemKhoonakKonnadeh;
            frm.txtOmreMofid.Text = model.OmreMofid;
            frm.txtSazandeh.Text = model.Sazandeh;
            frm.PropIDGhaleb = model.ID;
            if(model.VaziyatGhaleb!=null)
            {
                if(model.VaziyatGhaleb==true)
                {
                    frm.rdbFelezi.Checked = true;
                    frm.txtFelezi.Text = model.GensGhaleb;

                }
                else
                {
                    frm.rdbPelastic.Checked = true;
                    frm.txtPelastic.Text = model.GensGhaleb;
                }
            }
           
            frm.ShowDialog();
        }
    }
}
