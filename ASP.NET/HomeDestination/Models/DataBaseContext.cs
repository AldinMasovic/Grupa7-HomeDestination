using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace HomeDestination.Models
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext() : base("AzureConection") { }
        
        //modeli mapirani u bazu podataka
        public DbSet<Osoba> Osoba { get; set; }
        public DbSet<Smjestaj> Smjestaj { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Filter> Filter { get; set; }
        public DbSet<FilterDom> FilterDom { get; set; }
        public DbSet<Dojam> Dojam { get; set; }

        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}