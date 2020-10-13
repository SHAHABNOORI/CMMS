using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMMS.Dtos
{
   public class ShenasNamehGalebDto
    {
        public long ID { get; set; }
        public string NameGhaleb { get; set; }
        public string Code { get; set; }
        public string TypeGhaleb { get; set; }
        public string Vazn { get; set; }
        public string UsableMaterials { get; set; }
        public string Address { get; set; }
        public string Tool { get; set; }
        public string Arz { get; set; }
        public string Ertefa { get; set; }
        public string TarikhSakht { get; set; }
        public string tarikhShorooBeKar { get; set; }
        public string sharayetneghahdari { get; set; }
        public string GensGhaleb { get; set; }
        public Nullable<bool> VaziyatGhaleb { get; set; }
        public string VaziyatKharid { get; set; }
        public string SystemKhoonakKonnadeh { get; set; }
        public string TypeGiris { get; set; }
        public string OmreMofid { get; set; }
        public string Sazandeh { get; set; }
    }
}
