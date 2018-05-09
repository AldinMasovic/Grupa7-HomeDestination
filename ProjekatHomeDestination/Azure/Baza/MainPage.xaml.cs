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
using Microsoft.WindowsAzure.MobileServices;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Baza
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        IMobileServiceTable<tabela> userTableObj = App.MobileService.GetTable<tabela>();

        private void btnSpasi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tabela obj = new tabela();
                obj.ime = txtIme.Text;
                obj.prezime = txtPrezime.Text;
                obj.email = txtEmail.Text;
                obj.spol = txtSpol.Text;
                obj.datumrodjenja = txtDatum.Text;
                obj.korisnickoime = txtKorisnicko.Text;
                obj.sifra = txtSifra.Text;
                userTableObj.InsertAsync(obj);
                MessageDialog msgDialog = new MessageDialog("Uspješno unijet novi korisnik.");
                msgDialog.ShowAsync();
            }
            catch (Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                msgDialogError.ShowAsync();
            }

        }
    }
}
