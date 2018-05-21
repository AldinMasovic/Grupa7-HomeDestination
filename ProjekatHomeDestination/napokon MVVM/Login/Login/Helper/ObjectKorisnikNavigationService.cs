using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Helper
{
    public class ObjectKorisnikNavigationService
    {
        private NavigationService ns;
        private Osoba osoba;
        public ObjectKorisnikNavigationService(NavigationService n, Osoba o)
        {
            ns = n;
            osoba = o;
        }

        public NavigationService Ns
        {
            get
            {
                return ns;
            }

            set
            {
                ns = value;
            }
        }

        public Osoba Osoba { get { return osoba; } set { osoba = value; } }


    }
}
