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
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

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
        private StackPanel slika = new StackPanel();
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
            String pass = textBox_Copy4.Password;
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
                Mail = mail,
                RegistrovaniSmjestaji = new List<Smjestaj>(),
                Rezervacije = new List<Rezervacija>(),
                Slika=slika

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
        IMobileServiceTable<tabela> userTableObj = App.MobileService.GetTable<tabela>();
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            String s=validirajPodatke();
            if (s.Equals(bezGreske) && ImagePreview.Children.Count!=0)
            {
                try
                {
                    tabela obj = new tabela();
                    obj.ime = textBox_Copy2.Text;
                    obj.prezime = textBox_Copy.Text;
                    obj.email = textBox_Copy1.Text;
                    obj.spol = radioButton.IsChecked.ToString();
                    DateTimeOffset day;
                    if (calendarDatePicker.Date != null)
                    {
                        day = (DateTimeOffset)calendarDatePicker.Date;
                    }
                    obj.datumrodjenja = day.DateTime.ToString();
                    obj.korisnickoime = textBox_Copy3.Text;
                    obj.sifra = textBox_Copy4.Password;
                    await userTableObj.InsertAsync(obj);
                    MessageDialog msgDialog = new MessageDialog("Uspješno unijet novi korisnik.");
                    await msgDialog.ShowAsync();

                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                    await msgDialogError.ShowAsync();
                }
                DataSource.DataSourceMenuMD.dodajKorisnika(korisnik);
                //model.RegistrujKorisnika(korisnik);
                this.Frame.Navigate(typeof(MainPage));
            }
            else
            {
                korisnik = null;
                var dialog = new MessageDialog(s, "Neuspješna registracija, provjerite da li ste unijeli sve podatke");
                await dialog.ShowAsync();
            }

        }

        private async void button1_Click(System.Object sender, RoutedEventArgs e)
        {
            if (ImagePreview.Children.Count() == 1)
            {
                ImagePreview.Children.Clear();

            }
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");

            StorageFile file = await openPicker.PickSingleFileAsync();

            if (file != null)
            {
                var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var image = new BitmapImage();
                image.SetSource(stream);
                ImagePreview.Children.Add(new Image() { Source = image, Width = 110, Height = 79 });
                slika.Children.Add(new Image() { Source = image });

            }

        }
    }
}
