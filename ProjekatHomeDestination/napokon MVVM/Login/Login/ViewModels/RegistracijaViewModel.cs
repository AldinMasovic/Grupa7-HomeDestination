using Login.AzureDatebase;
using Login.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;
using System.Text.RegularExpressions;
using System.IO;
using System.ComponentModel;
using Login.Models;

namespace Login.ViewModels
{
    public class RegistracijaViewModel : BaseViewModel
    {
        private NavigationService ns;
        private String ime = "", prezime = "", mail = "", datum = "", username = "", spol = "", broj = "", adresa = "";
        private string password = "", password2 = "";
        private bool kvadraticCekiranMusko;
        private bool kvadraticCekiranZensko;
        private DateTime datumRodjenja;

        public ICommand Registruj { get; set; }
        public ICommand Nazad { get; set; }

        public string Ime { get { return ime; } set { ime = value; OnPropertyChanged("Ime"); } }
        public string Prezime { get { return prezime; } set { prezime = value; OnPropertyChanged("Prezime"); } }
        public string Adresa { get { return adresa; }set { adresa = value; OnPropertyChanged("Adresa"); } }
        public string Broj { get { return broj; } set { broj = value; OnPropertyChanged("Broj"); } }
        public string Password2 { get { return password2; }set { password2 = value; OnPropertyChanged("Password2"); } }
        public string Mail
        {
            get { return mail; } set { mail = value; OnPropertyChanged("Mail"); } }
        
        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        public bool KvadraticCekiranMusko
        {
            get { return kvadraticCekiranMusko; }
            set { kvadraticCekiranMusko = value; OnPropertyChanged("KvadraticCekiranMusko"); } }
        public bool KvadraticCekiranZensko
        {
            get { return kvadraticCekiranZensko; }
            set { kvadraticCekiranZensko = value; OnPropertyChanged("KvadraticCekiranZensko"); }
        }
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set { datumRodjenja = value; OnPropertyChanged("DatumRodjenja"); }
        }
            
        public string Username { get {return username; } set { username = value; OnPropertyChanged("Username"); } }
        
        public NavigationService Ns
        {
            get { return ns; }
            set { ns = value; }
        }

        public RegistracijaViewModel(NavigationService ns)
        {
            this.Ns = ns;
            Registruj = new RelayCommand<object>(registrujKorisnika);
            Nazad = new RelayCommand<object>(zatvoriRegistracijaView, returnTrue);
            kvadraticCekiranMusko=kvadraticCekiranZensko  = false;
        }
        private bool validirajRadioButton()
        {
           
            if (kvadraticCekiranZensko || KvadraticCekiranMusko) return true;
            return false;
        }
        private string validirajPodatke()
        {
            String greske = "";
            if (!Validacija.validirajNaziv(ime)) greske += "Ime, ";
            if (!Validacija.validirajNaziv(prezime)) greske += "Prezime, ";
            if (!Validacija.validirajUsername(username)) greske += "Username, ";
            if (!Validacija.validirajPassword(password)) greske += "Password, ";
            //DateTimeOffset day;
            //if (date.Date != null)
            //{
            //    day = (DateTimeOffset)date.Date;
            //}
            DateTime datum = datumRodjenja.Date;

            
            Pol pol = Pol.Musko;
            if (validirajRadioButton())
            {
                if (kvadraticCekiranMusko) pol = Pol.Musko;
                else if (kvadraticCekiranZensko) pol = Pol.Zensko;
            }
            else
            {
                greske += "Spol, ";
            }
            spol = pol.ToString();
            
            return greske;
        }
        #region Registruj
        public async void registrujKorisnika(object o)
        {
            MessageDialog poruka;
            //milion validacija odradit na fazon da li je popunjeno, ovo ono...
                            //if (kvadraticCekiran == false)
                            //{
                            //
                            //    poruka = new MessageDialog("Kvadratic mora biti cekiran!");
                            //    await poruka.ShowAsync();
                            //    return;
                            //}
            /*
            else if (!sifra.Equals(PonoviteSifru))
            {
                poruka = new MessageDialog("Sifre moraju biti jednake!");
                await poruka.ShowAsync();
                return;
            }
            */
            DateTimeOffset day;
            String x=validirajPodatke();
            if (x != "")
            {
                poruka = new MessageDialog("Pogresno uneseni podaci: " + x);
                await poruka.ShowAsync();
            }
            else if (!password2.Equals(password))
            {
                poruka = new MessageDialog("Sifre se ne poklapaju!");
                await poruka.ShowAsync();
            }
            else
            {
                //ako postoji username onda se ne moze registrovati
                if (await Baza.provjeriPostojiLiUsername(username) == true)
                {
                    poruka = new MessageDialog("Vec postoji korisnik sa istim korisnickim imenom");
                    await poruka.ShowAsync();
                }
                else
                {
                    //TODO: datum prepraviti
                    Baza.dodajKorisnika(ime, prezime, mail, spol, new DateTime(2015, 2, 20), username, password,broj,adresa);
                    poruka = new MessageDialog("Uspješno ste obavili registraciju!");
                    await poruka.ShowAsync();
                    ns.Navigate(typeof(MainPage));
                    //, new ObjectKorisnikNavigationService(ns, await Baza.dajKorisnika(username, password)));
                }
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
