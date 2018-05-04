using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class ViewModel
    {
        Osoba Korisnik { get; set; }

        public ViewModel()
        {
            Korisnik = Helper.GetOsoba();
        }
        public void RegistrujKorisnika()
        {
            HomeDestionation.Korisnici.Add(Korisnik);
        }
        public bool LoginKorisnika()
        {
            int max = HomeDestionation.Korisnici.Count;
            for(int i = 0; i < max; i++)
            {
                if(Korisnik.Username== HomeDestionation.Korisnici[i].Username && 
                    Korisnik.Password== HomeDestionation.Korisnici[i].Password)
                {
                    return true;
                    //otvoriti novi prozor
                }
            }
            return false;
        }

    }
    public class Helper
    {
        public static Osoba GetOsoba()
        {
            return new Osoba
            {
                Ime = "Ime",
                Prezime = "Prezime",
                Telefon = "12341234",
                Mail = "ahaha@hotmail.com",
                Username = "rokiii",
                Password = "kikiii",
                Spol = Pol.Musko,
                Datum = DateTime.Now,
                Slika = null,
                RegistrovaniSmjestaji = new List<Smjestaj>(),
                Rezervacije = new List<Rezervacija>()
            };
        }
    }
}
