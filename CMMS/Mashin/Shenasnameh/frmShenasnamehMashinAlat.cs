using CMMS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BehComponents;
using CMMS.Mashin.GhataatMasrafi;
using System.Data.Entity;
using CMMS.Dtos;
using CMMS.Helpers;

namespace CMMS
{
    public partial class frmShenasnamehMashinAlat :Form
    {
        SqlConnection conn;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        PersianCalendar pc = new PersianCalendar();

        //................PropForDataOfDgv.................
        #region 

        public long propID { get; set; }
        public string propNameDastgha { get; set; }
        public string propCodeDastghah { get; set; }
        public string propModelDastGhah { get; set; }
        public string propSize { get; set; }
        public string propVazn { get; set; }
        public string propZarfiyat { get; set; }
        public string propAmerMofid { get; set; }
        public string propSharkatSazandeh { get; set; }
        public string propKeshvarSazandeh { get; set; }
        public string propTaiedKonnadeh { get; set; }
        public string propAdressNamayandegi { get; set; }
        public string propTelphoneNamayandegi { get; set; }
        public bool propBargh { get; set; }
        public bool propAb { get; set; }
        public bool propHava { get; set; }
        public bool propGhaz { get; set; }
        public string propTarikhSakht { get; set; }
        public string propTarikhBahrehBardari { get; set; }
        public string propTarikhTahiyeEttelaat { get; set; }
        #endregion
        //...............................................

        public frmShenasnamehMashinAlat()
        {
            InitializeComponent();
        }

        private void frmShenasnamehMashinAlat_Load(object sender, EventArgs e)
        {


          
            PopulateDataGridView();
        }

        void PopulateDataGridView()
        {
           
            try
            {
                List<ShenasNamehDto> fillData = new List<ShenasNamehDto>();
               
                using (var db =new dbs_CMMSEntities1())
                {
                    var result = db.tbl_ShenasnamehMoshinAlat.ToList();
                    foreach (var item in result)
                    {
                        fillData.Add(new ShenasNamehDto()
                        {
                            ID = item.ID,
                            NameDastgha = item.NameDastgha,
                            CodeDastghah = item.CodeDastghah,
                            ModelDastGhah = item.ModelDastGhah,
                            Size = item.Size,
                            Vazn = item.Vazn,
                            Zarfiyat = item.Zarfiyat,
                            AmerMofid = item.AmerMofid,
                            SharkatSazandeh = item.SharkatSazandeh,
                            KeshvarSazandeh = item.KeshvarSazandeh,
                            TaiedKonnadeh = item.TaiedKonnadeh,
                            AdressNamayandegi = item.AdressNamayandegi,
                            TelphoneNamayandegi = item.TelphoneNamayandegi,
                            Bargh = item.Bargh,
                            Ab = item.Ab,
                            Hava = item.Hava,
                            Ghaz = item.Ghaz,
                            TarikhSakht = PersianDateTimeHelper.FaDate(item.TarikhSakht),
                            TarikhBahrehBardari = PersianDateTimeHelper.FaDate(item.TarikhBahrehBardari),
                            TarikhTahiyeEttelaat = PersianDateTimeHelper.FaDate(item.TarikhTahiyeEttelaat),


                        });
                    }
                }
                dgvShenasnamehMashinAlat.DataSource = fillData;
                    
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            new frmAddShenasnamehMashinAlat().ShowDialog();

            PopulateDataGridView();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            frmEditShenasnamehMashinAlat frm = new frmEditShenasnamehMashinAlat();
            frm.propID = propID;
            frm.txtNameDastghah.Text = propNameDastgha;
            frm.txtCodeDastghah.Text = propCodeDastghah;
            frm.txtModelDastghah.Text = propModelDastGhah;
            frm.txtSize.Text = propSize;
            frm.txtVazn.Text = propVazn;
            frm.txtZarfiyat.Text = propZarfiyat;
            frm.txtOmrehMofid.Text = propAmerMofid;
            frm.txtSherkateSazandeh.Text = propSharkatSazandeh;
            frm.txtKeshvarSazandeh.Text = propKeshvarSazandeh;
            frm.txtTaiedKonnandeh.Text = propTaiedKonnadeh;
            frm.txtAddressNamayandegi.Text = propAdressNamayandegi;
            frm.txtTelphoneNamayandegi.Text = propTelphoneNamayandegi;
            frm.chkBargh.Checked = propBargh;
            frm.chkAb.Checked = propAb;
            frm.chkHava.Checked = propHava;
            frm.chkGaz.Checked = propGhaz;
            frm.txtTarikhSakht.Text = propTarikhSakht;
            frm.txtTarikhBahrehBardari.Text = propTarikhBahrehBardari;
            frm.txtTarikhTahiyehAtelaat.Text = propTarikhTahiyeEttelaat;
            frm.ShowDialog();
            PopulateDataGridView();

        }
      
        private void dgvShenasnamehMashinAlat_Click(object sender, EventArgs e)
        {


            if (dgvShenasnamehMashinAlat.Rows.Count != 0)
            {
                GetDataDgvToProp();

                //btnEdit.Enabled = true;
                //btnDelete.Enabled = true;
            }
        }

        private void GetDataDgvToProp()
        {
            if (dgvShenasnamehMashinAlat.Rows.Count > 1)
            {
                propID = long.Parse(dgvShenasnamehMashinAlat.CurrentRow.Cells["ID"].Value.ToString());
                propNameDastgha = dgvShenasnamehMashinAlat.CurrentRow.Cells["NameDastgha"].Value.ToString();
                propCodeDastghah = dgvShenasnamehMashinAlat.CurrentRow.Cells["CodeDastghah"].Value.ToString();
                propModelDastGhah = dgvShenasnamehMashinAlat.CurrentRow.Cells["ModelDastGhah"].Value.ToString();
                propSize = dgvShenasnamehMashinAlat.CurrentRow.Cells["Size"].Value.ToString();
                propVazn = dgvShenasnamehMashinAlat.CurrentRow.Cells["Vazn"].Value.ToString();
                propZarfiyat = dgvShenasnamehMashinAlat.CurrentRow.Cells["Zarfiyat"].Value.ToString();
                propAmerMofid = dgvShenasnamehMashinAlat.CurrentRow.Cells["AmerMofid"].Value.ToString();
                propSharkatSazandeh = dgvShenasnamehMashinAlat.CurrentRow.Cells["SharkatSazandeh"].Value.ToString();
                propKeshvarSazandeh = dgvShenasnamehMashinAlat.CurrentRow.Cells["KeshvarSazandeh"].Value.ToString();
                propTaiedKonnadeh = dgvShenasnamehMashinAlat.CurrentRow.Cells["TaiedKonnadeh"].Value.ToString();
                propAdressNamayandegi = dgvShenasnamehMashinAlat.CurrentRow.Cells["AdressNamayandegi"].Value.ToString();
                propTelphoneNamayandegi = dgvShenasnamehMashinAlat.CurrentRow.Cells["TelphoneNamayandegi"].Value.ToString();
                propTarikhSakht = dgvShenasnamehMashinAlat.CurrentRow.Cells["TarikhSakht"].Value.ToString();
                propTarikhBahrehBardari = dgvShenasnamehMashinAlat.CurrentRow.Cells["TarikhBahrehBardari"].Value.ToString();
                propTarikhTahiyeEttelaat = dgvShenasnamehMashinAlat.CurrentRow.Cells["TarikhTahiyeEttelaat"].Value.ToString();

                if (dgvShenasnamehMashinAlat.CurrentRow.Cells["Bargh"].Value.ToString() == "True")
                {
                    propBargh = true;
                }
                else
                {
                    propBargh = false;
                }

                if (dgvShenasnamehMashinAlat.CurrentRow.Cells["Ab"].Value.ToString() == "True")
                {
                    propAb = true;
                }
                else
                {
                    propAb = false;
                }

                if (dgvShenasnamehMashinAlat.CurrentRow.Cells["Hava"].Value.ToString() == "True")
                {
                    propHava = true;
                }
                else
                {
                    propHava = false;
                }

                if (dgvShenasnamehMashinAlat.CurrentRow.Cells["Ghaz"].Value.ToString() == "True")
                {
                    propGhaz = true;
                }
                else
                {
                    propGhaz = false;
                }
            }
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("آیا مطمن از حذف این محصول هستید ؟ ", "عملیات حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    dbs_CMMSEntities1 obj = new dbs_CMMSEntities1();
                    obj.tbl_ShenasnamehMoshinAlat.Where(x => x.ID == propID).Load();
                    obj.tbl_ShenasnamehMoshinAlat.Local.Clear();
                    obj.SaveChanges();
                    MessageBox.Show("اطلاعات با موفقیت حذف گردید", "عملیات حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateDataGridView();
                }
            }
            catch(Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                List<ShenasNamehDto> fillData = new List<ShenasNamehDto>();

                using (var db = new dbs_CMMSEntities1())
                {
                    var result = db.tbl_ShenasnamehMoshinAlat.Where(x => x.CodeDastghah.Contains(txtSearch.Text) || x.NameDastgha.Contains(txtSearch.Text) || x.ModelDastGhah.Contains(txtSearch.Text)).ToList();
                    foreach (var item in result)
                    {
                        fillData.Add(new ShenasNamehDto()
                        {
                            ID = item.ID,
                            NameDastgha = item.NameDastgha,
                            CodeDastghah = item.CodeDastghah,
                            ModelDastGhah = item.ModelDastGhah,
                            Size = item.Size,
                            Vazn = item.Vazn,
                            Zarfiyat = item.Zarfiyat,
                            AmerMofid = item.AmerMofid,
                            SharkatSazandeh = item.SharkatSazandeh,
                            KeshvarSazandeh = item.KeshvarSazandeh,
                            TaiedKonnadeh = item.TaiedKonnadeh,
                            AdressNamayandegi = item.AdressNamayandegi,
                            TelphoneNamayandegi = item.TelphoneNamayandegi,
                            Bargh = item.Bargh,
                            Ab = item.Ab,
                            Hava = item.Hava,
                            Ghaz = item.Ghaz,
                            TarikhSakht = PersianDateTimeHelper.FaDate(item.TarikhSakht),
                            TarikhBahrehBardari = PersianDateTimeHelper.FaDate(item.TarikhBahrehBardari),
                            TarikhTahiyeEttelaat = PersianDateTimeHelper.FaDate(item.TarikhTahiyeEttelaat),


                        });
                    }
                }
                dgvShenasnamehMashinAlat.DataSource = fillData;

            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



           
        }

        private void dgvShenasnamehMashinAlat_DoubleClick(object sender, EventArgs e)
        {
        
            FrmGhataatMasrafi frm = new FrmGhataatMasrafi();
            
            frm.txtCodeDastghah.Text = propCodeDastghah;
            frm.PropIDShenasnamehMoshinAlat = propID;
            frm.txtNameDastgha.Text = propNameDastgha;
            frm.ShowDialog();
        }

      

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmViewShenasnamehMashinAlat frm = new frmViewShenasnamehMashinAlat(); 
            frm.txtNameDastghah.Text = propNameDastgha;
            frm.txtCodeDastghah.Text = propCodeDastghah;
            frm.txtModelDastghah.Text = propModelDastGhah;
            frm.txtSize.Text = propSize;
            frm.txtVazn.Text = propVazn;
            frm.txtZarfiyat.Text = propZarfiyat;
            frm.txtOmrehMofid.Text = propAmerMofid;
            frm.txtSherkateSazandeh.Text = propSharkatSazandeh;
            frm.txtKeshvarSazandeh.Text = propKeshvarSazandeh;
            frm.txtTaiedKonnandeh.Text = propTaiedKonnadeh;
            frm.txtAddressNamayandegi.Text = propAdressNamayandegi;
            frm.txtTelphoneNamayandegi.Text = propTelphoneNamayandegi;
            frm.chkBargh.Checked = propBargh;
            frm.chkAb.Checked = propAb;
            frm.chkHava.Checked = propHava;
            frm.chkGaz.Checked = propGhaz;
            frm.txtTarikhSakht.Text = propTarikhSakht;
            frm.txtTarikhBahrehBardari.Text =DateTime.Parse( propTarikhBahrehBardari).ToShortDateString();
            frm.txtTarikhTahiyehAtelaat.Text = DateTime.Parse(propTarikhTahiyeEttelaat).ToShortDateString();
            frm.ShowDialog();
        }

        private void dgvShenasnamehMashinAlat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }
    }
}
