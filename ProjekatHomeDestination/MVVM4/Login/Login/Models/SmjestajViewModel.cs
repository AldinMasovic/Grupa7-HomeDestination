using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Login
{
    public class SmjestajViewModel
    {
        Smjestaj Kucica;
        public SmjestajViewModel()
        {
            Kucica = HelperSmjestaj.GetSmjestaj();
        }
        public void RegistrujSmjestaj()
        {
            HomeDestionation.Smjestaji.Add(Kucica);
        }
    }
    public class HelperSmjestaj
    {
        public static Smjestaj GetSmjestaj()
        {
            return new Smjestaj
            {

                Vrsta = VrstaSmejstaja.Kuca,
                Cijena = 50,
                Kvadratura = 50,
                Lokacija = "Sarajevo",
                PogododnoStudentima = true,
                SlikeSmjestaja = new StackPanel(),
                Opis = "hehee",
                Filteri = new Filter(),
                BrojCimera = 2,
                Datum = DateTime.Now,
                Rezervacije = new List<Rezervacija>(),
                Dojmovi = new List<Dojam>()
            };
        }
    }

}
