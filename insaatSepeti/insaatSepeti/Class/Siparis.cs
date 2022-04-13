using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insaatSepeti.Class
{
    public class Siparis
    {
        public int SatisID { get; set; }
        public int MusteriID { get; set; }
        public int FirmaID { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public int UrunID { get; set; }
        public string BetonCesidi { get; set; }
        public string CimentoCesidi { get; set; }
        public string KatkiCesidi { get; set; }
        public string KivamCesidi { get; set; }
        public double BirimFiyati { get; set; }
        public double Miktar { get; set; }
        public string FirmaAdi { get; set; }
        public string SiparisDurumu { get; set; }
    }
}
