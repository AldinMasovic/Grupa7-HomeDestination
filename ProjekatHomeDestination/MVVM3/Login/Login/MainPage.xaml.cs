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
using Windows.UI.Notifications;
//using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Popups;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Login
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// public static ViewModel model = new ViewModel();
    public sealed partial class MainPage : Page
    {
        private ViewModel model;
        public MainPage()
        {
            HomeDestionation glavna = new HomeDestionation();
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            model = new ViewModel();
            String username = textBox.Text;
            String pass = textBox_Copy.Password;
            //bool postojiKorisnik = model.potojiLiLoginKorisnika(username, pass);
            Osoba a = DataSource.DataSourceMenuMD.ProvjeraKorisnika(username, pass);
            bool postojiKorisnik = false;
            if (a.Username != null) { postojiKorisnik = true; }
            if (postojiKorisnik)
            {
                this.Frame.Navigate(typeof(ProfilKorisnika),a);
                //todo: pokrenuti novu aplikaciju ili obavijestiti 
                //var dialog = new MessageDialog("Uskoro se pokreće novi prozor!", "Uspješna prijava");
                //await dialog.ShowAsync();
            }
            else
            {
                var dialog = new MessageDialog("Pogrešno korisničko ime/šifra!", "Neuspješna prijava");
                await dialog.ShowAsync();
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(Registracija));

        }
    }
}
