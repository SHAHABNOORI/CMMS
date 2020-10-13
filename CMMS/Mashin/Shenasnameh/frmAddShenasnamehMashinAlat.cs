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
using CMMS.Helpers;
using CMMS.Properties;

namespace CMMS
{
    public partial class frmAddShenasnamehMashinAlat : Form
    {
      
        public frmAddShenasnamehMashinAlat()
        {
            InitializeComponent();
        }

        private void frmAddShenasnamehMashinAlat_Load(object sender, EventArgs e)
        {
           
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dt;
                if (DateTime.TryParse(txtTarikhSakht.Text, out dt) && DateTime.TryParse(txtTarikhBahrehBardari.Text, out dt) && DateTime.TryParse(txtTarikhTahiyehAtelaat.Text, out dt))
                {
                    dbs_CMMSEntities1 obj = new dbs_CMMSEntities1();
                    tbl_ShenasnamehMoshinAlat tbl = new tbl_ShenasnamehMoshinAlat();
                    tbl.NameDastgha = txtNameDastghah.Text;
                    tbl.CodeDastghah = txtCodeDastghah.Text;
                    tbl.ModelDastGhah = txtModelDastghah.Text;
                    tbl.Size = txtSize.Text;
                    tbl.Vazn = txtVazn.Text;
                    tbl.Zarfiyat = txtZarfiyat.Text;
                    tbl.AmerMofid = txtOmrehMofid.Text;
                    tbl.SharkatSazandeh = txtSherkateSazandeh.Text;
                    tbl.KeshvarSazandeh = txtKeshvarSazandeh.Text;
                    tbl.TaiedKonnadeh = txtTaiedKonnandeh.Text;
                    tbl.AdressNamayandegi = txtAddressNamayandegi.Text;
                    tbl.TelphoneNamayandegi = txtTelphoneNamayandegi.Text;
                    tbl.Bargh = chkBargh.Checked;
                    tbl.Ab = chkAb.Checked;
                    tbl.Hava = chkHava.Checked;
                    tbl.Ghaz = chkGaz.Checked;
                    tbl.TarikhSakht = PersianDateTimeHelper.ConvertToDate(txtTarikhSakht.Text);
                    tbl.TarikhBahrehBardari = PersianDateTimeHelper.ConvertToDate(txtTarikhBahrehBardari.Text);
                    tbl.TarikhTahiyeEttelaat = PersianDateTimeHelper.ConvertToDate(txtTarikhTahiyehAtelaat.Text);
                    obj.tbl_ShenasnamehMoshinAlat.Add(tbl);
                    obj.SaveChanges();
                    MessageBox.Show("اطلاعات با موفقیت ذخیره گردید", "ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("لطفا تاریخ را درست وارد نمایید", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطای رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               
            }
        }      
    }
}
