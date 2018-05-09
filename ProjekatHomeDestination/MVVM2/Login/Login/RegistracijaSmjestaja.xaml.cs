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
    public sealed partial class RegistracijaSmjestaja : Page
    {
        private Osoba korisnik;
        private String bezGreske= "Pogresno ste unijeli: ";
        private Smjestaj smjestaj;
        private ViewModelRegistracijaSmjestaja model;
        public RegistracijaSmjestaja()
        {
            this.InitializeComponent();
            model = new ViewModelRegistracijaSmjestaja();
            //ubaciti u viewmodel
            for(int i = 0; i < model.dajGradove().Count; i++)
            {
                comboBox_Copy.Items.Add(model.dajGradove()[i]);
            }
            //comboBox.Items.Add(VrstaSmejstaja.Kuca.ToString());
            //comboBox.Items.Add(VrstaSmejstaja.Stan.ToString());
            //comboBox.Items.Add(VrstaSmejstaja.StudentskiDom.ToString());
            comboBox_Copy.SelectedIndex = 0;//ili nula
            for(int i = 0; i < model.dajVrsteSmjestaja().Count; i++)
            {
                comboBox.Items.Add(model.dajVrsteSmjestaja()[i].ToString());
            }
            //comboBox_Copy.Items.Add("Sarajevo");
            //comboBox_Copy.Items.Add("Mostar");
            //comboBox_Copy.Items.Add("Zenica");
            //comboBox_Copy.Items.Add("Bihac");
            //comboBox_Copy.Items.Add("Tuzla");
            //comboBox_Copy.Items.Add("Bugojno");
            comboBox.SelectedIndex = 0;//ili nula
            listBox_Copy.Visibility = Visibility.Collapsed;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            korisnik = null;
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (e.Parameter != null)
            {
                korisnik = (Osoba)e.Parameter;
            }
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBlock1_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox1_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBlock1_Copy_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void checkBox15_Checked(object sender, RoutedEventArgs e)
        {

        }
        private string validirajPodatke()
        {
            String greske = "Pogresno ste unijeli: ";
            String cijena = textBox.Text;
            String kvadratura = textBox_Copy.Text;
            String brojCimera = textBox2.Text;
            if (!Validacija.validirajCijenu(cijena)) greske += "Cijena, ";
            if (!Validacija.validirajKvadraturu(kvadratura)) greske += "Kvadratura, ";
            if (!Validacija.validirajBroj(brojCimera)) greske += "Broj cimera, ";
            return greske;


        }
        private void unesiSmjestaj()
        {
            String pomocna= textBox.Text;
            int cijena = 0;
            Int32.TryParse(pomocna, out cijena);

            String kvadratura = textBox_Copy.Text;
            int kvadrat = 0;
            Int32.TryParse(kvadratura, out kvadrat);
            String brojCimera = textBox2.Text;
            int brCimera = 0;
            Int32.TryParse(brojCimera,out  brCimera);
            VrstaSmejstaja vrstaSmjestaja = (VrstaSmejstaja)comboBox.SelectedIndex;
            String lokacija = comboBox_Copy.SelectedIndex.ToString();
            String dodatniOpis = textBox1.Text;
            Filter filter = new Filter();//doraditi mozda klasu filter i ovo
            smjestaj = new Smjestaj()
            {
                Cijena = cijena,
                BrojCimera = brCimera,
                Filteri=filter,
                Kvadratura=kvadrat,
                Lokacija=lokacija,
                Vrsta=vrstaSmjestaja,
                Opis=dodatniOpis,
                Dojmovi=new List<Dojam>(),
                Datum=DateTime.Now,
                Rezervacije=new List<Rezervacija>(),
                PogododnoStudentima= (bool)checkBox.IsChecked
            };



        }
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string s = validirajPodatke();
            if (s != bezGreske)
            {
                var dialog = new MessageDialog(s, "Neuspješna registracija");
                await dialog.ShowAsync();
            }
            else
            {
                unesiSmjestaj();
                //pozovi funkciju iz datasourncemenu dodaj smjestaj
                DataSource.DataSourceMenuMD.dodajSmjestaj(smjestaj);
                korisnik.RegistrovaniSmjestaji.Add(smjestaj);
                var dialog = new MessageDialog("Uspješno ste dodali smještaj", "Uspješna registracija");
                await dialog.ShowAsync();
                this.Frame.Navigate(typeof(ProfilKorisnika),korisnik);
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            if (checkBox.IsChecked == true) {
                listBox_Copy.Visibility = Visibility.Visible;
            }
            else
            {
                listBox_Copy.Visibility = Visibility.Collapsed;
            }
        }
    }
}
