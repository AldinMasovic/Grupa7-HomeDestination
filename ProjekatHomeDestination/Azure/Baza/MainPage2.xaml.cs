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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Baza
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage2 : Page
    {
        public MainPage2()
        {
            this.InitializeComponent();
        }
        IMobileServiceTable<tabela1> userTableObj = App.MobileService.GetTable<tabela1>();

        private void btnSpasi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tabela1 obj1 = new tabela1();
                obj1.vrstasmjestaja = txtVrsta.Text;
                obj1.cijena = txtCijena.Text;
                obj1.kvadratura = txtKvadratura.Text;
                obj1.lokacija = txtLokacija.Text;
                obj1.dodatniopis = txtDodati.Text;
                obj1.brojcimera = txtBroj.Text;
                userTableObj.InsertAsync(obj1);
                MessageDialog msgDialog = new MessageDialog("Uspješno ste unijeli novog studenta.");
                msgDialog.ShowAsync();
            }
            catch(Exception ex)
            {
                MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                msgDialogError.ShowAsync();
            }
            }
    }
}
