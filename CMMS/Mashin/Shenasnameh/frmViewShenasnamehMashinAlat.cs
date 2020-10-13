//using Stimulsoft.Report;
using Stimulsoft.Report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CMMS
{
    public partial class frmViewShenasnamehMashinAlat : Form
    {
        public frmViewShenasnamehMashinAlat()
        {
            InitializeComponent();
        }
        PersianCalendar pc = new PersianCalendar();
        private void btnPrint_Click(object sender, EventArgs e)
        {
            StiReport sti = new StiReport();
            sti.Load("Machine ID.mrt");
            //sti.RegData(ds.Tables[0]);
            //sti.Design();
            sti.Dictionary.Variables.Add("vbl_Date", pc.GetYear(DateTime.Now).ToString() + "/" + pc.GetMonth(DateTime.Now).ToString() + "/" + pc.GetDayOfMonth(DateTime.Now).ToString());

            sti.Dictionary.Variables.Add("vblNameDastgha", txtNameDastghah.Text);
            sti.Dictionary.Variables.Add("vblCodeDastghah", txtCodeDastghah.Text);
            sti.Dictionary.Variables.Add("vblModelDastGhah", txtModelDastghah.Text);
            sti.Dictionary.Variables.Add("vblSize", txtSize.Text);
            sti.Dictionary.Variables.Add("vblVazn", txtVazn.Text);
            sti.Dictionary.Variables.Add("vblZarfiyat", txtZarfiyat.Text);
            sti.Dictionary.Variables.Add("vblAmerMofid", txtOmrehMofid.Text);
            sti.Dictionary.Variables.Add("vblSharkatSazandeh", txtSherkateSazandeh.Text);
            sti.Dictionary.Variables.Add("vblKeshvarSazandeh", txtKeshvarSazandeh.Text);
            sti.Dictionary.Variables.Add("vblTaiedKonnadeh", txtTaiedKonnandeh.Text);
            sti.Dictionary.Variables.Add("vblAdressNamayandegi", txtAddressNamayandegi.Text);
            sti.Dictionary.Variables.Add("vblTelphoneNamayandegi", txtTelphoneNamayandegi.Text);
            sti.Dictionary.Variables.Add("vblTarikhSakht", txtTarikhSakht.Text);
            sti.Dictionary.Variables.Add("vblTarikhBahrehBardari", txtTarikhBahrehBardari.Text);
            sti.Dictionary.Variables.Add("vblTarikhTahiyeEttelaat", txtTarikhTahiyehAtelaat.Text);
            sti.Dictionary.Variables.Add("vblAb", chkAb.Checked);
            sti.Dictionary.Variables.Add("vblBarg", chkBargh.Checked);
            sti.Dictionary.Variables.Add("vblGaz", chkGaz.Checked);
            sti.Dictionary.Variables.Add("vblHava", chkHava.Checked);
            sti.Compile();
            sti.Show();
        }
    }
}
