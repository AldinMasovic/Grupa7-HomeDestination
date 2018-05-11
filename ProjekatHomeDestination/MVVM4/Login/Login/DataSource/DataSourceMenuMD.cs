using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.DataSource
{
    public class DataSourceMenuMD
    {
        #region Osoba
        private static List<Osoba> korisnici = new List<Osoba>()
        {
            new Osoba()
            {
                Ime="Ajla",
                Prezime="Mesic",
                Username="amesic",
                Password="123456",
                Spol=Pol.Zensko,
                Mail="",
                Datum=new DateTime(1996,4,20),
                RegistrovaniSmjestaji=new List<Smjestaj>(),
                Rezervacije=new List<Rezervacija>()
            },
            new Osoba
            {
                Ime="Emina",
                Prezime="Mehic",
                Username="emehic",
                Password="123456",
                Spol=Pol.Zensko,
                Mail="",
                Datum=new DateTime(1997,2,21),
                RegistrovaniSmjestaji=new List<Smjestaj>(),
                Rezervacije=new List<Rezervacija>()
            },
            new Osoba
            {
                Ime="Aldin",
                Prezime="Masovic",
                Username="amasovic",
                Password="123456",
                Spol=Pol.Musko,
                Mail="",
                Datum=new DateTime(1996,2,29),
                RegistrovaniSmjestaji=new List<Smjestaj>(),
                Rezervacije=new List<Rezervacija>()
            }
        };
        public static IList<Osoba> DajSveKorisnike()
        {
            return korisnici;
        }
        public static Osoba ProvjeraKorisnika(string korisnickoIme, string sifra)
        {
            Osoba rezultat = new Osoba();
            foreach (var k in DajSveKorisnike())
            {
                if (k.Username == korisnickoIme && k.Password == sifra) rezultat = k;
            }
            return rezultat;
        }
        public static void dodajKorisnika(Osoba o)
        {
            korisnici.Add(o);
        }








        #endregion

        #region Smjestaji
        private static List<Smjestaj> smjestaji = new List<Smjestaj>();

        /*
         * 
         * 
         * 
         * 
         * 
         * */
        public static IList<Smjestaj> DajSveSmjestaje()
        {
            return smjestaji;
        }
        public static void dodajSmjestaj(Smjestaj s)
        {
            smjestaji.Add(s);
        }


        #endregion

    }
}