using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.AzureDatebase
{
    public class Baza
    {
        public Baza() { }

        public static async Task<bool> postojiLiUsernamePassword(String Username, String Password)
        {
            //ako u bazi ne postoji ova kombinacija username-a i password-a, daj mi false
            IMobileServiceTable<tabela> Korisnici = App.MobileService.GetTable<tabela>();

            IEnumerable<tabela> tabela = await Korisnici.ReadAsync();

            foreach (var element in tabela)
            {
                if (element.korisnickoime.Equals(Username) && element.sifra.Equals(Password))
                    return true;
            }

            return false;
        }
        public static async Task<bool> provjeriPostojiLiUsername(String username)
        {
            IMobileServiceTable<tabela> Korisnici = App.MobileService.GetTable<tabela>();

            IEnumerable<tabela> tabela = await Korisnici.ReadAsync();

            foreach (var element in tabela)
            {
                if (element.korisnickoime.Equals(username))
                    return true;
            }

            return false;

        }
        private static Pol dajMiSpol(string spol)
        {
            if(spol.Equals("Musko") || spol.Equals("musko"))return Pol.Musko;
            return Pol.Zensko;
        }
        private static  VrstaSmejstaja kojaVrstaSmjestaja(string pomocna)
        {
            if (pomocna.Equals("Kuca") || pomocna.Equals("kuca")) return VrstaSmejstaja.Kuca;
            else if (pomocna.Equals("StudentskiDom") || pomocna.Equals("studentskidom")) return VrstaSmejstaja.StudentskiDom;
            else return VrstaSmejstaja.Stan;
        }
        public static async Task<Osoba> dajKorisnika(string username, string password)
        {
            try
            {
                IMobileServiceTable<tabela> Korisnici = App.MobileService.GetTable<tabela>();

                IEnumerable<tabela> tabela = await Korisnici.ReadAsync();

                foreach (var element in tabela)
                {
                    if (element.korisnickoime.Equals(username) && element.sifra.Equals(password))
                    {
                        //List<Smjestaj> smjestaji = new List<Smjestaj>();
                        Smjestaj smjestaj = new Smjestaj();
                        IMobileServiceTable<tabela1> Smjestaji= App.MobileService.GetTable<tabela1>();

                        IEnumerable<tabela1> tabelaR = await Smjestaji.ReadAsync();

                        foreach (var elementR in tabelaR)
                            if (elementR.idvlasnika.Equals(element.id))
                            {
                                smjestaj.BrojCimera = elementR.brojcimera;
                                smjestaj.Cijena = elementR.cijena;
                                //fali datum smjestaj.datum
                                smjestaj.Kvadratura = elementR.kvadratura;
                                smjestaj.Lokacija = elementR.lokacija;
                                smjestaj.Opis = elementR.dodatniopis;
                                String pomocna = elementR.vrstasmjestaja;
                                VrstaSmejstaja vrsta = kojaVrstaSmjestaja(pomocna);
                                smjestaj.Vrsta = vrsta;
                                break;//ne treba kada bude lista
                                //TODO: dodati jos
                            }
                        List<Smjestaj> regSmjestaji = new List<Smjestaj>();
                        regSmjestaji.Add(smjestaj);
                        Osoba o = new Osoba()
                        {
                            Ime = element.ime,
                            Prezime = element.prezime,
                            Username = element.korisnickoime,
                            Spol = dajMiSpol(element.spol),
                            ID = element.id,
                            Mail = element.email,
                            Password = element.sifra,
                            Telefon=element.broj,
                            Adresa=element.adresa,
                            //datumrodjenja
                            //TODO: ostatak ctrl space
                            RegistrovaniSmjestaji = regSmjestaji
                            //registorvanerezervacije?
                        };
                        return o;
                    }

                }
            }
            catch (Exception e)
            {
                throw;
            }


            return new Osoba(); // nece se nikada izvrsiti


        }


        public static async void dodajKorisnika(string ime, string prezime,string email,string spol,DateTime datumRodjenja,
            string username, string password,string broj,string adresa)
        {
            IMobileServiceTable<tabela> Korisnici = App.MobileService.GetTable<tabela>();

            tabela korisnik = new tabela();
            korisnik.ime = ime;
            korisnik.prezime = prezime;
            korisnik.email = email;
            korisnik.spol = spol;
            korisnik.datumrodjenja = datumRodjenja;
            korisnik.korisnickoime = username;
            korisnik.sifra = password;
            korisnik.adresa = adresa;
            korisnik.broj = broj;
            

            try
            {
                await Korisnici.InsertAsync(korisnik);
            }
            catch (Exception e)
            {
                throw;
            }
        }
        public static async void dodajSmjestaj(string cijena, string vrstasmjestaja, string kvadratura, string lokacija,int brojcimera,string opis, string idvlasnika)
        {
            IMobileServiceTable<tabela1> Smjestaji = App.MobileService.GetTable<tabela1>();

            tabela1 smjestaj= new tabela1();
            smjestaj.brojcimera = brojcimera;
            smjestaj.cijena = cijena;
            smjestaj.vrstasmjestaja = vrstasmjestaja;
            smjestaj.kvadratura = kvadratura;
            smjestaj.lokacija = lokacija;
            smjestaj.dodatniopis = opis;
            smjestaj.idvlasnika = idvlasnika;

            try
            {
                await Smjestaji.InsertAsync(smjestaj);
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
