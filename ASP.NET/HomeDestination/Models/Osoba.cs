using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDestination.Models
{
    public enum Pol { Musko, Zensko };
    public class Osoba
    {
        //dio za atribute
        [Key]
        public String ID { get; set; }
        [Required]
        public String Ime { get; set; }
        [Required]
        public String Prezime { get; set; }
        [Required]
        public String Telefon { get; set; }
        [Required]
        public String Mail { get; set; }
        [Required]
        public String Username { get; set; }
        [Required]
        public String Password { get; set; }
        [Required]
        public Pol Spol { get; set; }
        [Required]
        public String Adresa { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        //public  Slika { get; set; }
        public List<Smjestaj> RegistrovaniSmjestaji { get; set; } 
        public List<Rezervacija> Rezervacije { get; set; } 

        //dio u kojem se definišu veze sa ostalim klasama
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Smjestaj> Smjestaj { get; set; }
    }
}