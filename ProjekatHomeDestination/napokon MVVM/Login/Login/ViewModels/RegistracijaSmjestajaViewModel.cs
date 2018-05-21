using Login;
using Login.AzureDatebase;
using Login.Helper;
using Login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace Login.ViewModels
{
    public    class RegistracijaSmjestajaViewModel:BaseViewModel
    {
        private Osoba osoba;
        private NavigationService ns;
        private string cijena, kvadratura, brojCimera, opis;
        private string lokacija, vrstasmjestaja;

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
        public string Cijena { get { return cijena; } set { cijena = value; OnPropertyChanged("Cijena"); } }
        public string Kvadratura { get { return kvadratura; } set { kvadratura = value; OnPropertyChanged("Kvadratura"); } }
        public string BrojCimera { get { return brojCimera; } set { brojCimera = value; OnPropertyChanged("BrojCimera"); } }
        public string Opis { get { return opis; } set { opis = value; OnPropertyChanged("Opis"); } }
        public string Vrstasmjestaja { get { return vrstasmjestaja; }set { vrstasmjestaja = value; OnPropertyChanged("VrstaSmjestaja"); } }
        public ICommand Registruj { get; set; }
        public ICommand Nazad { get; set; }
        public RegistracijaSmjestajaViewModel(NavigationService n)
        {
            this.ns = n;
            
        }
        public RegistracijaSmjestajaViewModel(ObjectKorisnikNavigationService obj)
        {
            this.osoba = obj.Osoba;
            this.ns = obj.Ns;
            Registruj= new RelayCommand<object>(otvoriRegistrujSmjestajView);
            Nazad = new RelayCommand<object>(zatvoriRegistracijaView, returnTrue);
        }
        private string dajMiLokaciju(string s)
        {
            if (s == "0") return "Sarajevo";
            else if (s == "1") return "Mostar";
            else if (s == "2") return "Bihac";
            else if (s == "3") return "Tuzla";
            else if (s == "4") return "Zenica";
            else return "Gorazde";

            
        }

        private string validirajPodatke()
        {
            String greske = "";
            if (!Validacija.validirajCijenu(cijena)) greske += "Cijena, ";
            if (!Validacija.validirajKvadraturu(kvadratura)) greske += "Kvadratura, ";
            if (!Validacija.validirajBroj(brojCimera)) greske += "Broj cimera, ";
            return greske;


        }
        #region Registruj
        public async void otvoriRegistrujSmjestajView(object o)
        {
            MessageDialog poruka;
            
            String x = validirajPodatke();
            if (x != "")
            {
                poruka = new MessageDialog("Pogresno uneseni podaci: " + x);
                await poruka.ShowAsync();
            }
            else
            {
                int broj = 0;
                Int32.TryParse(brojCimera, out broj);
                int xxx = 0;
                String Ax = RegistracijaSmjestaja.VRSTA_SMJESTAJA;
                Int32.TryParse(Ax, out xxx);
                VrstaSmejstaja vrsta = (VrstaSmejstaja)xxx;
                vrstasmjestaja = vrsta.ToString();
                lokacija = dajMiLokaciju(RegistracijaSmjestaja.LOKACIJA);


                Baza.dodajSmjestaj(cijena, vrstasmjestaja, kvadratura, lokacija, broj, opis, osoba.ID);
                poruka = new MessageDialog("Uspješno ste obavili registraciju!");
                await poruka.ShowAsync();
                ns.Navigate(typeof(ProfilKorisnika), new ObjectKorisnikNavigationService(ns, osoba));
            }

            return;
        }
        #endregion Registruj

        #region Nazad
        public void zatvoriRegistracijaView(object o)
        {
            Ns.GoBack();
        }

        #endregion Nazad
        private bool returnTrue(object o) { return true; }

    }
}
