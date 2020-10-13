using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMMS.Mashin.GhataatMasrafi
{
    public partial class FrmSearchAnbarGhataatYadaki : Form
    {
        FrmAddGhataatMasrafi frmAddGhataatMasrafi;
        List<tbl_AnbarGhataatYadaki> _List_tbl_AnbarGhataatYadaki = new List<tbl_AnbarGhataatYadaki>();
        public FrmSearchAnbarGhataatYadaki(FrmAddGhataatMasrafi frm)
        {
            frmAddGhataatMasrafi = frm;
            InitializeComponent();

        }
        void PopulateDataGridView()
        {
            try
            {


                using (dbs_CMMSEntities1 _db = new dbs_CMMSEntities1())
                {
                    dgvShenasnamehMashinAlat.DataSource = _db.tbl_AnbarGhataatYadaki.ToList();
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void FrmSearchAnbarGhataatYadaki_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }

        private void dgvShenasnamehMashinAlat_Click(object sender, EventArgs e)
        {
            if (dgvShenasnamehMashinAlat.Rows.Count >= 1)
            {
                frmAddGhataatMasrafi.PropIDAnbarGhataatYadaki = long.Parse(dgvShenasnamehMashinAlat.CurrentRow.Cells["ID"].Value.ToString());
                frmAddGhataatMasrafi.txtCode.Text = dgvShenasnamehMashinAlat.CurrentRow.Cells["Code"].Value.ToString();
                frmAddGhataatMasrafi.txtName.Text = dgvShenasnamehMashinAlat.CurrentRow.Cells["NameGheteh"].Value.ToString();
            }
            else
            {
                MessageBox.Show("سطری انتخاب نشده است", "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void dgvShenasnamehMashinAlat_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {

                using (dbs_CMMSEntities1 _db = new dbs_CMMSEntities1())
                {
                    _List_tbl_AnbarGhataatYadaki = _db.tbl_AnbarGhataatYadaki.Where(x => x.Code.Contains(txtSearch.Text) || x.NameGheteh.Contains(txtSearch.Text) || x.ShomarehFani.Contains(txtSearch.Text)).ToList<tbl_AnbarGhataatYadaki>();
                    dgvShenasnamehMashinAlat.DataSource = _List_tbl_AnbarGhataatYadaki;
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
