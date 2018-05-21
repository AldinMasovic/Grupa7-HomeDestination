using Login.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;

namespace Login.ViewModels
{
    public class ProfilKorisnikaViewModel : BaseViewModel
    {
        private Osoba osoba;
        private NavigationService ns;
        private string ime, prezime, mail, spol, datum, username, broj, adresa;
        public Osoba Osoba
        {
            get
            {
                return osoba;
            }

            set
            {
                osoba = value;
            }
        }

        public NavigationService Ns
        {
            get
            {
                return ns;
            }

            set
            {
                ns = value;
            }
        }
        public ICommand RegistrujSmjestaj { get; set; }
        public ICommand Nazad { get; set; }
        public string Ime { get { OnPropertyChanged("Ime"); return ime; } set { ime = value; } }
        public string Prezime { get { OnPropertyChanged("Prezime"); return prezime; } set { prezime = value; } }
        public string Mail { get { OnPropertyChanged("Mail"); return mail; } set { mail = value; } }
        public string Spol { get { OnPropertyChanged("Spol"); return spol; } set { spol = value; } }
        public string Datum { get { OnPropertyChanged("Datum"); return datum; } set { datum = value; } }
        public string Username { get { OnPropertyChanged("Username"); return username; } set { username = value; } } 
        public string Broj { get { OnPropertyChanged("Broj"); return broj; } set { broj = value; } }
        public string Adresa { get { OnPropertyChanged("Adresa"); return adresa; } set { adresa = value; } }

        public ProfilKorisnikaViewModel (ObjectKorisnikNavigationService obj)
        {
            
            this.osoba = obj.Osoba;
            this.ns = obj.Ns;
            RegistrujSmjestaj= new RelayCommand<object>(otvoriRegistrujSmjestajView);
            Nazad = new RelayCommand<object>(zatvoriRegistracijaView, returnTrue);
            Ime = osoba.Ime;
            Prezime = osoba.Prezime;
            Mail = osoba.Mail;
            Spol = osoba.Spol.ToString();
            Datum = osoba.Datum.ToString("dd/MM/yyyy");
            Username = osoba.Username;
            Adresa = osoba.Adresa;
            Broj = osoba.Telefon;
            
        }

        #region RegistrujSmjestaj
        public  void otvoriRegistrujSmjestajView(object o)
        {
            ns.Navigate(typeof(RegistracijaSmjestaja), new ObjectKorisnikNavigationService(ns, osoba));
        }

        #endregion RegistrujSmjestaj

        #region Nazad
        public void zatvoriRegistracijaView(object o)
        {
            Ns.GoBack();
        }

        #endregion Nazad
        private bool returnTrue(object o) { return true; }

    }
}
