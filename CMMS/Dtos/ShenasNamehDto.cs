using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMMS.Dtos
{
   public class ShenasNamehDto
    {
        public long ID { get; set; }
        public string NameDastgha { get; set; }
        public string CodeDastghah { get; set; }
        public string ModelDastGhah { get; set; }
        public string Size { get; set; }
        public string Vazn { get; set; }
        public string Zarfiyat { get; set; }
        public string AmerMofid { get; set; }
        public string SharkatSazandeh { get; set; }
        public string KeshvarSazandeh { get; set; }
        public string TaiedKonnadeh { get; set; }
        public string AdressNamayandegi { get; set; }
        public string TelphoneNamayandegi { get; set; }
        public Nullable<bool> Bargh { get; set; }
        public Nullable<bool> Ab { get; set; }
        public Nullable<bool> Hava { get; set; }
        public Nullable<bool> Ghaz { get; set; }
        public string TarikhSakht { get; set; }
        public string TarikhBahrehBardari { get; set; }
        public string TarikhTahiyeEttelaat { get; set; }
    }
}
