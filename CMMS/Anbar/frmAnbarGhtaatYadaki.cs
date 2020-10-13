using CMMS.Properties;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace CMMS
{
    public partial class frmAnbarGhtaatYadaki : Form
    {
        SqlConnection conn;
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
       List< tbl_AnbarGhataatYadaki> _List_tbl_AnbarGhataatYadaki = new List< tbl_AnbarGhataatYadaki>();
        
        #region 

        public long propID { get; set; }
        public string propCode { get; set; }
        public string propNameGheteh { get; set; }
        public string propShomarehFani { get; set; }
        public long propMojoodi { get; set; }
        public long propNoghtehSefaresh { get; set; }
        public string propDiscription { get; set; }
      
        #endregion
        public frmAnbarGhtaatYadaki()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmAddAnbarGhtaatYadaki frm = new frmAddAnbarGhtaatYadaki();
            frm.ShowDialog();
            PopulateDataGridView();
        }
       
        private void frmAnbarGhtaatYadaki_Load(object sender, EventArgs e)
        {
           
         
            PopulateDataGridView();
        }
       
        void PopulateDataGridView()
        {
             try
                {
                   

                using(dbs_CMMSEntities1 _db=new dbs_CMMSEntities1())
                {
                    dgvShenasnamehMashinAlat.DataSource = _db.tbl_AnbarGhataatYadaki.ToList();
                }

                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

        }

        private void GetDataDgvToProp()
        {
            if (dgvShenasnamehMashinAlat.Rows.Count >= 1)
            {
                propID = long.Parse(dgvShenasnamehMashinAlat.CurrentRow.Cells["ID"].Value.ToString());
                propCode = dgvShenasnamehMashinAlat.CurrentRow.Cells["Code"].Value.ToString();
                propNameGheteh = dgvShenasnamehMashinAlat.CurrentRow.Cells["NameGheteh"].Value.ToString();
                propShomarehFani = dgvShenasnamehMashinAlat.CurrentRow.Cells["ShomarehFani"].Value.ToString();
                propMojoodi =long.Parse( dgvShenasnamehMashinAlat.CurrentRow.Cells["Mojoodi"].Value.ToString());
                propNoghtehSefaresh =long.Parse( dgvShenasnamehMashinAlat.CurrentRow.Cells["NoghtehSefaresh"].Value.ToString());
                propDiscription = dgvShenasnamehMashinAlat.CurrentRow.Cells["Discription"].Value.ToString(); 
            }
        }

        private void dgvShenasnamehMashinAlat_Click(object sender, EventArgs e)
        {
          
                GetDataDgvToProp();

               
           
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            frmEditAnbarGhtaatYadaki frm = new frmEditAnbarGhtaatYadaki();
            frm.propID = propID;
            frm.txtCode.Text = propCode;
            frm.txtName.Text = propNameGheteh;
            frm.txtShomarehFani.Text = propShomarehFani;
            frm.txtMojoodi.Text = propMojoodi.ToString();
            frm.txtNoghtehSefaresh.Text = propNoghtehSefaresh.ToString();
            frm.txtDiscription.Text = propDiscription;
            frm.ShowDialog();
            PopulateDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dgvShenasnamehMashinAlat.Rows[0].DefaultCellStyle.SelectionBackColor = Color.AliceBlue;            // dgvShenasnamehMashinAlat.RefreshEdit();
        //    MessageBox.Show(dgvShenasnamehMashinAlat.Rows[0].DefaultCellStyle.SelectionBackColor.ToArgb().ToString());
        }

        private void dgvShenasnamehMashinAlat_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dgvShenasnamehMashinAlat.Rows)
            {           
                if (long.Parse(Myrow.Cells["Mojoodi"].Value.ToString()) < long.Parse(Myrow.Cells["NoghtehSefaresh"].Value.ToString()))
                {
                    Myrow.DefaultCellStyle.BackColor = Color.Red;
                    Myrow.DefaultCellStyle.SelectionForeColor = Color.Red;
                }
                else
                {
                    Myrow.DefaultCellStyle.BackColor = Color.White;
                    Myrow.DefaultCellStyle.SelectionForeColor = Color.Black;
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
                        obj.tbl_AnbarGhataatYadaki.Where(x => x.ID == propID).Load();
                        obj.tbl_AnbarGhataatYadaki.Local.Clear();
                        obj.SaveChanges();
                    }
                    MessageBox.Show("اطلاعات با موفقیت حذف گردید", "عملیات حذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PopulateDataGridView();
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           
        }
       
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
               
                using(dbs_CMMSEntities1 _db = new dbs_CMMSEntities1())
                {
                    _List_tbl_AnbarGhataatYadaki= _db.tbl_AnbarGhataatYadaki.Where(x => x.Code.Contains(txtSearch.Text) || x.NameGheteh.Contains(txtSearch.Text) || x.ShomarehFani.Contains(txtSearch.Text)).ToList<tbl_AnbarGhataatYadaki>();
                    dgvShenasnamehMashinAlat.DataSource = _List_tbl_AnbarGhataatYadaki;
                }
            
          

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        PersianCalendar pc = new PersianCalendar();
        private void btnPrint_Click(object sender, EventArgs e)
        {
            
               
                StiReport sti = new StiReport();
                sti.Load("AnbarGhataat.mrt");
                sti.RegData("tbl_AnbarGhataatYadaki", dgvShenasnamehMashinAlat.DataSource);
               // sti.Design();
                sti.Dictionary.Variables.Add("vbl_Date", pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString());
                //sti.Compile();
                sti.Show();
            
           
            
           
           
        }
    }
}
