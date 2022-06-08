using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_App.Models
{
    internal class Dostawy
    {
        public int ID { get; set; }
        public int PiwoID { get; set; }
        public int DostawcaID { get; set; }
        public DateTime DataZamowienia { get; set; }
        public int Ilosc { get; set; }
        public int StatusID { get; set; }

    }
}
