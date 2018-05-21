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
        public string ID { get; set; }
        public VrstaSmejstaja Vrsta { get; set; }
        public string Cijena { get; set; }
        public string Kvadratura { get; set; }
        public String Lokacija { get; set; }
        public bool PogododnoStudentima { get; set; }
        public StackPanel SlikeSmjestaja { get; set; }
        public String Opis { get; set; }
        public Filter Filteri { get; set; }
        public int BrojCimera { get; set; }
        public DateTime Datum { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }
        public List<Dojam> Dojmovi { get; set; }
    }
}
