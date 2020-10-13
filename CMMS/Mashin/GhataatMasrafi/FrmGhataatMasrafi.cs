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
    public partial class FrmGhataatMasrafi : Form
    {
        public long PropIDShenasnamehMoshinAlat { get; set; }
        public FrmGhataatMasrafi()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            FrmAddGhataatMasrafi frm = new FrmAddGhataatMasrafi();
            frm.PropIDShenasnamehMoshinAlat = PropIDShenasnamehMoshinAlat;
            frm.ShowDialog();
            PopulateDataGridView();
        }
        void PopulateDataGridView()
        {

            try
            {
                dbs_CMMSEntities1 obj = new dbs_CMMSEntities1();
                //var FillData = obj.tbl_ShenasnamehMoshinAlat.ToList();
                

                var result = (from b in obj.tbl_GhataatMasrafiMashinAlat
                              join p in obj.tbl_AnbarGhataatYadaki
                              on b.IDAnbarGhataatYadaki equals p.ID where b.IDShenasnamehMoshinAlat== PropIDShenasnamehMoshinAlat
                              select new
                              {
                                  IDShenasnamehMoshinAlat= p.ID,
                                  Tedad = b.Tedad,
                                  NameGheteh = p.NameGheteh,
                                  Mojoodi = p.Mojoodi
                              }).ToList();
                dgvShenasnamehMashinAlat.DataSource = result;

            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message, "خطایی رخ داده است", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }
        private void FrmGhataatMasrafi_Load(object sender, EventArgs e)
        {
            PopulateDataGridView();
        }
    }
}
