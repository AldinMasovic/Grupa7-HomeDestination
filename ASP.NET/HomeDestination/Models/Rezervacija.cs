using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDestination.Models
{
    public enum Placanje { aplikacija, gotovina, racun}
    public class Rezervacija
    {
        //dio za atribute
        [Key]
        public String ID { get; set; }
        public int SmjestajId { get; set; }
        public int KorisnikId { get; set; }
        [Required]
        public Placanje NacinPlacanja { get; set; }
        public double Dugovanja { get; set; }
        [Required]
        public DateTime DatDolaska { get; set; }
        public DateTime DatOdlaska { get; set; }

        //dio u kojem se definišu veze sa ostalim klasama
        public virtual Smjestaj Smjestaj { get; set; }
        public virtual Osoba Osoba { get; set; }

    }
}