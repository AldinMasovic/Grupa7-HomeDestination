using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDestination.Models
{
    public class Dojam
    {
        //dio za atribute
       [Key]
        public String ID { get; set; }
        public int SmjestajId { get; set; }
        public int KorisnikId { get; set; }
        public int Ocjena { get; set; }
        public int Komentar { get; set; }

        //dio u kojem se definišu veze sa ostalim klasama
        public virtual Smjestaj Smjestaj { get; set; }
        public virtual Osoba Osoba { get; set; }
    }
}