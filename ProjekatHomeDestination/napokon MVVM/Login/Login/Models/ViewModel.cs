using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class ViewModel
    {
        private String user;
        private String pas;
        Osoba Korisnik { get; set; }

        public ViewModel()
        {
           // Korisnik = Helper.GetOsoba();
        }
        public ViewModel(String user,String pas)
        {
            this.user = user;
            this.pas = pas;
            
        }
        public void RegistrujKorisnika(Osoba korisnik)
        {
            HomeDestionation.Korisnici.Add(korisnik);
        }
        public bool potojiLiLoginKorisnika(String user,String pass)
        {
            int max = HomeDestionation.Korisnici.Count;
            for(int i = 0; i < max; i++)
            {
                
                if(user== HomeDestionation.Korisnici[i].Username && 
                    pass== HomeDestionation.Korisnici[i].Password)
                {
                    return true;
                    //otvoriti novi prozor
                }
            }
            return false;
        }

    }
    public class Helper1
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
