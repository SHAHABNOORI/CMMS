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
    public partial class frmEditAnbarGhtaatYadaki : Form
    {
       
        public long propID { get; set; }
        public frmEditAnbarGhtaatYadaki()
        {
            InitializeComponent();
        }

      
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                dbs_CMMSEntities1 obj = new dbs_CMMSEntities1();
                var EditeData = obj.tbl_AnbarGhataatYadaki.Where(x => x.ID == propID).First();
                EditeData.Code = txtCode.Text;
                EditeData.NameGheteh = txtName.Text;
                EditeData.ShomarehFani = txtShomarehFani.Text;
                EditeData.Mojoodi =long.Parse( txtMojoodi.Text);
                EditeData.NoghtehSefaresh = long.Parse(txtNoghtehSefaresh.Text);
                EditeData.Discription = txtDiscription.Text;
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
