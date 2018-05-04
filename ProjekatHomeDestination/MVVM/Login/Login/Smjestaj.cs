using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Login
{
    public enum VrstaSmejstaja { Stan, Kuca, StudentskiDom };
    public class Smjestaj
    {
        private static int brojac = 0;
        public int ID { get { return brojac; } set { ID = brojac++; } }
        public VrstaSmejstaja Vrsta { get; set; }
        public double Cijena { get; set; }
        public double Kvadratura { get; set; }
        public String Lokacija { get; set; }
        public bool PogododnoStudentima { get; set; }
        public List<Image> SlikeSmjestaja { get; set; }
        public String Opis { get; set; }
        public Filter Filteri { get; set; }
        public int BrojCimera { get; set; }
        public DateTime Datum { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }
        public List<Dojam> Dojmovi { get; set; }
    }
}
