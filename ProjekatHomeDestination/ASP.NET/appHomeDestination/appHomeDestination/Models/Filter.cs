using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace appHomeDestination.Models
{
    public class Filter
    {
        //dio za atribute
        [ScaffoldColumn(false)]
        [Key]
        public String ID { get; set; }
        public bool Namjestaj { get; set; }
        public bool Parking { get; set; }
        public bool WiFi { get; set; }
        public bool Lift { get; set; }
        public bool Klima { get; set; }
        public bool Balkon { get; set; }
        public bool Novogradnja { get; set; }
        public bool Alarm { get; set; }
        public bool Videonadzor { get; set; }
        public bool TV { get; set; }

        //dio u kojem se definišu veze sa ostalim klasama, nema?
    }
}