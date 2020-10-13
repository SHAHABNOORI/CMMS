using CMMS.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMMS
{
    public partial class frmEditShenasnamehMashinAlat : Form
    {
      
        public long  propID { get; set; }
        
        public frmEditShenasnamehMashinAlat()
        {

            InitializeComponent();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        //,,
        private void btnSave_Click(object sender, EventArgs e)
        {
           
           

            try
            {
                dbs_CMMSEntities1 obj = new dbs_CMMSEntities1();
                var EditeData = obj.tbl_ShenasnamehMoshinAlat.Where(x => x.ID == propID).First();
                EditeData.NameDastgha = txtNameDastghah.Text;
                EditeData.CodeDastghah = txtCodeDastghah.Text;
                EditeData.ModelDastGhah = txtModelDastghah.Text;
                EditeData.Size = txtSize.Text;
                EditeData.Vazn = txtVazn.Text;
                EditeData.Zarfiyat = txtZarfiyat.Text;
                EditeData.AmerMofid = txtOmrehMofid.Text;
                EditeData.SharkatSazandeh = txtSherkateSazandeh.Text;
                EditeData.KeshvarSazandeh = txtKeshvarSazandeh.Text;
                EditeData.TaiedKonnadeh = txtTaiedKonnandeh.Text;
                EditeData.AdressNamayandegi = txtAddressNamayandegi.Text;
                EditeData.TelphoneNamayandegi = txtTelphoneNamayandegi.Text;
                EditeData.Bargh = chkBargh.Checked;
                EditeData.Ab = chkAb.Checked;
                EditeData.Hava = chkHava.Checked;
                EditeData.Ghaz = chkGaz.Checked;
                EditeData.TarikhSakht = DateTime.Parse(txtTarikhSakht.Text);
                EditeData.TarikhBahrehBardari = DateTime.Parse(txtTarikhBahrehBardari.Text);
                EditeData.TarikhTahiyeEttelaat = DateTime.Parse(txtTarikhTahiyehAtelaat.Text);
                obj.SaveChanges();
                MessageBox.Show("اطلاعات با موفقیت ویرایش گردید", "ویرایش", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch(Exception ex)
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
