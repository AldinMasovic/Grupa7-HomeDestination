using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login
{
    class ViewModelRegistracijaSmjestaja
    {
        List<String> gradovi;
        List<VrstaSmejstaja> vrsteSmjestaja;
        public ViewModelRegistracijaSmjestaja()
        {
            gradovi = new List<String>() { "Sarajevo", "Mostar", "Zenica", "Bugojno", "Bihac", "Zagreb", "Beograd" };
            vrsteSmjestaja = new List<VrstaSmejstaja>() { VrstaSmejstaja.Kuca, VrstaSmejstaja.Kuca, VrstaSmejstaja.StudentskiDom };
        }
        public List<String> dajGradove() { return gradovi; }
        public List<VrstaSmejstaja> dajVrsteSmjestaja() { return vrsteSmjestaja; }

    }
}
