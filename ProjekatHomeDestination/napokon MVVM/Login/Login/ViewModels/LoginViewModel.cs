using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.IO;
using Windows.UI.Popups;
using Login.Helper;
using Login.AzureDatebase;

namespace Login.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private String username = "";
        private String password = "";
        private NavigationService ns;


        public ICommand PrijaviSe { get; set; }
        public ICommand Nazad { get; set; }

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }

        public NavigationService Ns { get { return ns; } set { ns = value; } }
        public LoginViewModel(NavigationService navigationService)
        {
            PrijaviSe = new RelayCommand<object>(otvoriProfilKorisnikaView);
            Nazad = new RelayCommand<object>(zatvoriLoginViewModel, returnTrue);
            Ns = navigationService;
          
        }
        
        #region PrijaviSe
        public async void otvoriProfilKorisnikaView(object o)
        {
            //TODO: prepraviti ovo
            
            if (await Baza.postojiLiUsernamePassword(username, password)== false)
            {
                MessageDialog poruka = new MessageDialog("Pogrešni pristupni podaci!");
                await poruka.ShowAsync();
                return;
            }

            ns.Navigate(typeof(ProfilKorisnika), new ObjectKorisnikNavigationService(ns, await Baza.dajKorisnika(username, password)));
        }

        #endregion PrijaviSe

        #region Nazad
        public void zatvoriLoginViewModel(object o)
        {
            ns.Navigate(typeof(Registracija));
            //Ns.GoBack();
        }

        #endregion Nazad

        public bool returnTrue(object o)
        {
            return true;
        }
    }
}
