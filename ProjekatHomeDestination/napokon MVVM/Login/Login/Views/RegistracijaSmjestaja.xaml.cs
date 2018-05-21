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
using Login.Helper;
using Login.ViewModels;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Login
{

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaSmjestaja : Page
    {
        public static string LOKACIJA;
        public static string VRSTA_SMJESTAJA;
        private String bezGreske= "Pogresno ste unijeli: ";
        private Smjestaj smjestaj;
        private StackPanel Slike = new StackPanel();
        
        
        public RegistracijaSmjestaja()
        {
            this.InitializeComponent();


            //model = new ViewModelRegistracijaSmjestaja();
            
            /*
            //ubaciti u viewmodel
            for(int i = 0; i < model.dajGradove().Count; i++)
            {
                comboBox_Copy.Items.Add(model.dajGradove()[i]);
            }
            comboBox_Copy.SelectedIndex = 0;//ili nula
            for(int i = 0; i < model.dajVrsteSmjestaja().Count; i++)
            {
                comboBox.Items.Add(model.dajVrsteSmjestaja()[i].ToString());
            }
            comboBox.SelectedIndex = 0;
            listBox_Copy.Visibility = Visibility.Collapsed;
            */
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            DataContext = new RegistracijaSmjestajaViewModel((ObjectKorisnikNavigationService)e.Parameter);

            /*  PRIJEEE
            base.OnNavigatedTo(e);
            korisnik = null;
            //Dobavljanje korisnika iz parametra budući da je isti sa logina poslan kao parametar
            if (e.Parameter != null)
            {
                korisnik = (Osoba)e.Parameter;
            }*/
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
            String lokacija = comboBox_Copy.SelectedItem.ToString();
            String dodatniOpis = textBox1.Text;
            Filter filter = new Filter();//doraditi mozda klasu filter i ovo
            smjestaj = new Smjestaj()
            {
                Cijena = cijena.ToString(),
                BrojCimera = brCimera,
                Filteri = filter,
                Kvadratura = kvadrat.ToString(),
                Lokacija = lokacija,
                Vrsta = vrstaSmjestaja,
                Opis = dodatniOpis,
                Dojmovi = new List<Dojam>(),
                Datum = DateTime.Now,
                Rezervacije = new List<Rezervacija>(),
                PogododnoStudentima = (bool)checkBox.IsChecked,
                SlikeSmjestaja = Slike
            };



        }
        IMobileServiceTable<tabela1> userTableObj = App.MobileService.GetTable<tabela1>();
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            string s = validirajPodatke();
            if (s != bezGreske ||  ImagePreview.Children.Count()==0)
            {
                var dialog = new MessageDialog(s, "Neuspješna registracija");
                await dialog.ShowAsync();
            }
            else
            {
                try
                {
                    tabela1 obj1 = new tabela1();
                    obj1.vrstasmjestaja = comboBox.SelectedItem.ToString();
                    //obj1.cijena = textBox.Text;
                    //obj1.kvadratura = textBox_Copy.Text;
                    obj1.lokacija = comboBox_Copy.SelectedItem.ToString();
                    obj1.dodatniopis = textBox1.Text;
                    //obj1.brojcimera = textBox2.Text;
                    await(userTableObj.InsertAsync(obj1));
                   

                }
                catch (Exception ex)
                {
                    MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                    msgDialogError.ShowAsync();
                }
                unesiSmjestaj();
                //pozovi funkciju iz datasourncemenu dodaj smjestaj
                DataSource.DataSourceMenuMD.dodajSmjestaj(smjestaj);
                //korisnik.RegistrovaniSmjestaji.Add(smjestaj);
                var dialog = new MessageDialog("Uspješno ste dodali smještaj", "Uspješna registracija");
                await dialog.ShowAsync();
                //this.Frame.Navigate(typeof(ProfilKorisnika),korisnik);
            }
        }

        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker openPicker = new FileOpenPicker();
            openPicker.ViewMode = PickerViewMode.Thumbnail;
            openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            openPicker.FileTypeFilter.Add(".jpg");
            openPicker.FileTypeFilter.Add(".png");

           
            var files = await openPicker.PickMultipleFilesAsync();
            foreach (var singleImage in files)
            {
                var stream = await singleImage.OpenAsync(Windows.Storage.FileAccessMode.Read);
                var image = new BitmapImage();
                image.SetSource(stream);
                ImagePreview.Children.Add(new Image() { Source = image, Width = 15, Height = 15 });
                Slike.Children.Add(new Image() { Source = image});
            }
        }

        private void comboBox_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            VRSTA_SMJESTAJA = comboBox.SelectedItem.ToString();
            
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            VRSTA_SMJESTAJA = comboBox.SelectedIndex.ToString();
            if (comboBox.SelectedIndex == 2)
            {
                listBox_Copy.Visibility = Visibility.Visible;
            }
            else
            {
                if (listBox_Copy == null) return;
                listBox_Copy.Visibility = Visibility.Collapsed;
            }
        }

        private void comboBox_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            LOKACIJA = comboBox_Copy.SelectedIndex.ToString();
        }

        private void checkBox_Click(object sender, RoutedEventArgs e)
        {
            
            if (checkBox.IsChecked == true)
            {
                listBox_Copy.Visibility = Visibility.Visible;
            }
            else
            {
                listBox_Copy.Visibility = Visibility.Collapsed;
            }
            if (listBox_Copy.SelectedIndex == 2)
            {
                listBox_Copy.Visibility = Visibility.Visible;
            }
        }
    }
}
