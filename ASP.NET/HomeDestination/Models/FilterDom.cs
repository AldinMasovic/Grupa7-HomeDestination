using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeDestination.Models
{
    public class FilterDom:Filter
    {
        //dio za atribute
        public bool Teretana { get; set; }
        public bool Citaona { get; set; }
        public bool Kantina { get; set; }
        public bool VesMasina { get; set; }

        //dio u kojem se definišu veze sa ostalim klasama, nema?

    }
}