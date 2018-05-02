using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    public class HomeDestionation
    {
        public static List<Smjestaj> Smjestaji;
        public static List<Osoba> Korisnici;
        public HomeDestionation()
        {
            Smjestaji = new List<Smjestaj>();
            Korisnici = new List<Osoba>();
        }
    }
}
