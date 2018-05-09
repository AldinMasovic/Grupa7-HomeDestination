using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Models
{
    public static class Validacija
    {
        public static bool validirajPassword(String s)
        {
            if (s.Length < 6) return false;
            return true;
        }
        public static bool validirajUsername(String s)
        {
            if (s.Length < 6) return false;
            return true;
        }
        public static bool validirajNaziv(String s)
        {
            if (s.Length == 0 || s.Length >= 20) return false;
            s = s.ToLower();
            for (int i = 0; i < s.Length; i++) if (s[i] < 97 || s[i] > 122) return false;
            return true;
        }
        public static bool validirajKvadraturu(string s)
        {
            int broj = -1;
            bool uspjelo = Int32.TryParse(s, out broj);
            if (!uspjelo) return false;
            if (broj < 0 || broj > 2000) return false;
            return true;
        }
        public static bool validirajCijenu(string s)
        {
            int broj = -1;
            bool uspjelo = Int32.TryParse(s, out broj);
            if (!uspjelo) return false;
            if (broj < 0) return false;
            return true;
        }
        public static bool validirajBroj(string s)
        {
            int broj = -1;
            bool uspjelo=Int32.TryParse(s, out broj);
            if (!uspjelo) return false;
            if (broj < 0) return false;
            return true;

        }

    }
}
