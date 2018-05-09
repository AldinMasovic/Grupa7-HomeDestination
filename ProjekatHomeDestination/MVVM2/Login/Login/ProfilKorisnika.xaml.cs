using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class ProfilKorisnika : Page
    {
        private Osoba korisnik;
        public ProfilKorisnika()
        {
            this.InitializeComponent();
        }
        //Metoda u kojoj se procesira ono što je došlo sa stranice koja je pozvala ovu stranicu
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            korisnik = null;
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (e.Parameter != null)
            {
                korisnik = (Osoba)e.Parameter;
            }
            textBox.Text = korisnik.Ime;
            textBox1.Text = korisnik.Prezime;
            textBox2.Text = korisnik.Mail;
            textBox3.Text = korisnik.Spol.ToString();
            textBox4.Text = korisnik.Datum.ToString();
            textBox5.Text = korisnik.Username;



           /* 
        private void PrikaziMeni_Click(object sender, RoutedEventArgs e)
        {
            MojSplitView.IsPaneOpen = !MojSplitView.IsPaneOpen;
        }
        //Metoda koja na osnovu odabranog menija, poziva podstranicu koja je definisana u meniju
        private void MeniStavkeListView_SelectionChanged(object sender, SelectionChangedEventArgs
       e)
        {
            if (e.AddedItems.Count > 0)
            {
                var menuPodstranica = (e.AddedItems[0] as MeniStavkeViewModel).Podstranica;
                if (menuPodstranica != null) sadrzajPodstranice.Navigate(menuPodstranica, null);
            }
        }*/
        }

        private void textBox3_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(RegistracijaSmjestaja),korisnik);
        }
    }
}

