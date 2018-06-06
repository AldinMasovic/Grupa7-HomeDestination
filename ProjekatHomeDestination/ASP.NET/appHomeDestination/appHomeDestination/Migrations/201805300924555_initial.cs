namespace appHomeDestination.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dojam",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        SmjestajId = c.Int(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                        Ocjena = c.Int(nullable: false),
                        Komentar = c.Int(nullable: false),
                        Smjestaj_ID = c.String(maxLength: 128),
                        Smjestaj_ID1 = c.String(maxLength: 128),
                        Osoba_ID = c.String(maxLength: 128),
                        Smjestaj_ID2 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Smjestaj", t => t.Smjestaj_ID)
                .ForeignKey("dbo.Smjestaj", t => t.Smjestaj_ID1)
                .ForeignKey("dbo.Osoba", t => t.Osoba_ID)
                .ForeignKey("dbo.Smjestaj", t => t.Smjestaj_ID2)
                .Index(t => t.Smjestaj_ID)
                .Index(t => t.Smjestaj_ID1)
                .Index(t => t.Osoba_ID)
                .Index(t => t.Smjestaj_ID2);
            
            CreateTable(
                "dbo.Osoba",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Ime = c.String(nullable: false),
                        Prezime = c.String(nullable: false),
                        Telefon = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Spol = c.Int(nullable: false),
                        Adresa = c.String(nullable: false),
                        Datum = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Smjestaj",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Vrsta = c.Int(nullable: false),
                        Cijena = c.String(nullable: false),
                        Kvadratura = c.String(nullable: false),
                        Lokacija = c.String(nullable: false),
                        PogododnoStudentima = c.Boolean(nullable: false),
                        Opis = c.String(),
                        BrojCimera = c.Int(nullable: false),
                        Datum = c.DateTime(nullable: false),
                        Filteri_ID = c.String(maxLength: 128),
                        Osoba_ID = c.String(maxLength: 128),
                        Osoba_ID1 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Filter", t => t.Filteri_ID)
                .ForeignKey("dbo.Osoba", t => t.Osoba_ID)
                .ForeignKey("dbo.Osoba", t => t.Osoba_ID1)
                .Index(t => t.Filteri_ID)
                .Index(t => t.Osoba_ID)
                .Index(t => t.Osoba_ID1);
            
            CreateTable(
                "dbo.Filter",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Namjestaj = c.Boolean(nullable: false),
                        Parking = c.Boolean(nullable: false),
                        WiFi = c.Boolean(nullable: false),
                        Lift = c.Boolean(nullable: false),
                        Klima = c.Boolean(nullable: false),
                        Balkon = c.Boolean(nullable: false),
                        Novogradnja = c.Boolean(nullable: false),
                        Alarm = c.Boolean(nullable: false),
                        Videonadzor = c.Boolean(nullable: false),
                        TV = c.Boolean(nullable: false),
                        Teretana = c.Boolean(),
                        Citaona = c.Boolean(),
                        Kantina = c.Boolean(),
                        VesMasina = c.Boolean(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Smjestaj_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Smjestaj", t => t.Smjestaj_ID)
                .Index(t => t.Smjestaj_ID);
            
            CreateTable(
                "dbo.Rezervacija",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        SmjestajId = c.Int(nullable: false),
                        KorisnikId = c.Int(nullable: false),
                        NacinPlacanja = c.Int(nullable: false),
                        Dugovanja = c.Double(nullable: false),
                        DatDolaska = c.DateTime(nullable: false),
                        DatOdlaska = c.DateTime(nullable: false),
                        Osoba_ID = c.String(maxLength: 128),
                        Smjestaj_ID = c.String(maxLength: 128),
                        Smjestaj_ID1 = c.String(maxLength: 128),
                        Smjestaj_ID2 = c.String(maxLength: 128),
                        Osoba_ID1 = c.String(maxLength: 128),
                        Osoba_ID2 = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Osoba", t => t.Osoba_ID)
                .ForeignKey("dbo.Smjestaj", t => t.Smjestaj_ID)
                .ForeignKey("dbo.Smjestaj", t => t.Smjestaj_ID1)
                .ForeignKey("dbo.Smjestaj", t => t.Smjestaj_ID2)
                .ForeignKey("dbo.Osoba", t => t.Osoba_ID1)
                .ForeignKey("dbo.Osoba", t => t.Osoba_ID2)
                .Index(t => t.Osoba_ID)
                .Index(t => t.Smjestaj_ID)
                .Index(t => t.Smjestaj_ID1)
                .Index(t => t.Smjestaj_ID2)
                .Index(t => t.Osoba_ID1)
                .Index(t => t.Osoba_ID2);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dojam", "Smjestaj_ID2", "dbo.Smjestaj");
            DropForeignKey("dbo.Dojam", "Osoba_ID", "dbo.Osoba");
            DropForeignKey("dbo.Smjestaj", "Osoba_ID1", "dbo.Osoba");
            DropForeignKey("dbo.Rezervacija", "Osoba_ID2", "dbo.Osoba");
            DropForeignKey("dbo.Rezervacija", "Osoba_ID1", "dbo.Osoba");
            DropForeignKey("dbo.Smjestaj", "Osoba_ID", "dbo.Osoba");
            DropForeignKey("dbo.Rezervacija", "Smjestaj_ID2", "dbo.Smjestaj");
            DropForeignKey("dbo.Rezervacija", "Smjestaj_ID1", "dbo.Smjestaj");
            DropForeignKey("dbo.Rezervacija", "Smjestaj_ID", "dbo.Smjestaj");
            DropForeignKey("dbo.Rezervacija", "Osoba_ID", "dbo.Osoba");
            DropForeignKey("dbo.Smjestaj", "Filteri_ID", "dbo.Filter");
            DropForeignKey("dbo.Filter", "Smjestaj_ID", "dbo.Smjestaj");
            DropForeignKey("dbo.Dojam", "Smjestaj_ID1", "dbo.Smjestaj");
            DropForeignKey("dbo.Dojam", "Smjestaj_ID", "dbo.Smjestaj");
            DropIndex("dbo.Rezervacija", new[] { "Osoba_ID2" });
            DropIndex("dbo.Rezervacija", new[] { "Osoba_ID1" });
            DropIndex("dbo.Rezervacija", new[] { "Smjestaj_ID2" });
            DropIndex("dbo.Rezervacija", new[] { "Smjestaj_ID1" });
            DropIndex("dbo.Rezervacija", new[] { "Smjestaj_ID" });
            DropIndex("dbo.Rezervacija", new[] { "Osoba_ID" });
            DropIndex("dbo.Filter", new[] { "Smjestaj_ID" });
            DropIndex("dbo.Smjestaj", new[] { "Osoba_ID1" });
            DropIndex("dbo.Smjestaj", new[] { "Osoba_ID" });
            DropIndex("dbo.Smjestaj", new[] { "Filteri_ID" });
            DropIndex("dbo.Dojam", new[] { "Smjestaj_ID2" });
            DropIndex("dbo.Dojam", new[] { "Osoba_ID" });
            DropIndex("dbo.Dojam", new[] { "Smjestaj_ID1" });
            DropIndex("dbo.Dojam", new[] { "Smjestaj_ID" });
            DropTable("dbo.Rezervacija");
            DropTable("dbo.Filter");
            DropTable("dbo.Smjestaj");
            DropTable("dbo.Osoba");
            DropTable("dbo.Dojam");
        }
    }
}
