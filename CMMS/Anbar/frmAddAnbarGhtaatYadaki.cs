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
    public partial class frmAddAnbarGhtaatYadaki : Form
    {
        SqlConnection conn;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        public frmAddAnbarGhtaatYadaki()
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
                    tbl_AnbarGhataatYadaki tbl = new tbl_AnbarGhataatYadaki();
                    tbl.Code = txtCode.Text;
                    tbl.NameGheteh = txtName.Text;
                    tbl.ShomarehFani = txtShomarehFani.Text;
                    tbl.Mojoodi =long.Parse( txtMojoodi.Text);
                    tbl.NoghtehSefaresh =long.Parse( txtNoghtehSefaresh.Text);
                    tbl.Discription = txtDiscription.Text;   
                    obj.tbl_AnbarGhataatYadaki.Add(tbl);
                    obj.SaveChanges();
                    MessageBox.Show("اطلاعات با موفقیت ذخیره گردید", "ثبت اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطای رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }




          
        
    }

        private void frmAddAnbarGhtaatYadaki_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(Settings.Default["ConnStr"].ToString());
        }
    }
}
