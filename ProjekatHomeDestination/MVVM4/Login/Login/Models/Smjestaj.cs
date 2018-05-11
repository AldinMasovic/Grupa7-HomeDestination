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
        public int ID { get; set; }
        public VrstaSmejstaja Vrsta { get; set; }
        public double Cijena { get; set; }
        public double Kvadratura { get; set; }
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
