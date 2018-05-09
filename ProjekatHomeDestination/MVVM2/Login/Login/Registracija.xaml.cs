using Login.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Registracija : Page
    {
        private ViewModel model;
        private String bezGreske = "Pogresno uneseni podaci: ";
        private Osoba korisnik;
        public Registracija()
        {
            this.InitializeComponent();
            model = new ViewModel();
        }
        
      
        private bool validirajRadioButton()
        {
            bool musko = (bool)radioButton.IsChecked;
            bool zensko = (bool)radioButton_Copy.IsChecked;
            if (musko || zensko) return true;
            return false;
        }
        private string validirajPodatke()
        {
            String greske = "Pogresno uneseni podaci: ";
            String ime = textBox_Copy2.Text;
            
            if (!Validacija.validirajNaziv(ime)) greske += "Ime, ";
            String prezime = textBox_Copy.Text;
            if (!Validacija.validirajNaziv(prezime)) greske += "Prezime, ";
            String user = textBox_Copy3.Text;
            String pass = textBox_Copy4.Text;
            if (!Validacija.validirajUsername(user)) greske += "Username, ";
            if (!Validacija.validirajPassword(pass)) greske += "Password, ";
            DateTimeOffset day;
            if (calendarDatePicker.Date != null)
            {
                day= (DateTimeOffset)calendarDatePicker.Date;
            }
                DateTime datum = day.DateTime;
            
            bool musko = (bool)radioButton.IsChecked;
            bool zensko = (bool)radioButton_Copy.IsChecked;
            Pol pol = Pol.Musko;
            if (validirajRadioButton())
            {
                if (musko) pol = Pol.Musko;
                else if (zensko) pol = Pol.Zensko;
            }
            else
            {
                greske += "Spol, ";
            }
            String mail = textBox_Copy1.Text;

            //Osoba korisnik = new Osoba(ime, prezime, user, pass,pol, datum);
            korisnik = new Osoba
            {
                Ime = ime,
                Prezime = prezime,
                Username = user,
                Password = pass,
                Spol = pol,
                Datum = datum,
                Mail=mail,
                RegistrovaniSmjestaji = new List<Smjestaj>(),
                Rezervacije = new List<Rezervacija>()
        };
            return greske;
        }
        private void textBlock_Copy4_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBlock_Copy5_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_Copy4_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            String s=validirajPodatke();
            if (s.Equals(bezGreske))
            {
                DataSource.DataSourceMenuMD.dodajKorisnika(korisnik);
                //model.RegistrujKorisnika(korisnik);
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                korisnik = null;
                var dialog = new MessageDialog(s, "Neuspješna registracija");
                await dialog.ShowAsync();
            }

        }
    }
}
