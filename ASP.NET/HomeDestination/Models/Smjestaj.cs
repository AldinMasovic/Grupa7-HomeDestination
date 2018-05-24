using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HomeDestination.Models
{
    public enum VrstaSmjestaja { Stan, Kuca, StudentskiDom };
    public class Smjestaj
    {
        //dio za atribute
        [Key]
        public string ID { get; set; }
        [Required]
        public VrstaSmjestaja Vrsta { get; set; }
        [Required]
        public string Cijena { get; set; }
        [Required]
        public string Kvadratura { get; set; }
        [Required]
        public String Lokacija { get; set; }
        public bool PogododnoStudentima { get; set; }
        //public StackPanel SlikeSmjestaja { get; set; }
        public String Opis { get; set; }
        public Filter Filteri { get; set; }
        public int BrojCimera { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        public List<Rezervacija> Rezervacije { get; set; }
        public List<Dojam> Dojmovi { get; set; }
        //dio u kojem se definišu veze sa ostalim klasama
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
        public virtual ICollection<Filter> Filter { get; set; }
        public virtual ICollection<Dojam> Dojam { get; set; }
    }
}