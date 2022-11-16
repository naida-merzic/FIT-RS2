using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class OftamoloskiCentarContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Spol>().HasData(
                 new Spol()
                 {
                     SpolId = 1,
                     Naziv = "Musko"
                 },
                 new Spol()
                 {
                     SpolId = 2,
                     Naziv = "Zensko"
                 },
                 new Spol()
                 {
                     SpolId = 3,
                     Naziv = "Ostali"
                 }
             );
            modelBuilder.Entity<Rola>().HasData(
                 new Rola()
                 {
                     RolaId = 1,
                     Naziv = "Admin"
                 },
                 new Rola()
                 {
                     RolaId = 2,
                     Naziv = "BasicUser"
                 }
             );
            modelBuilder.Entity<VrstaArtikla>().HasData(
                 new VrstaArtikla()
                 {
                     VrstaArtiklaId = 1,
                     NazivArtikla = "Staklo"
                 },
                 new VrstaArtikla()
                 {
                     VrstaArtiklaId = 2,
                     NazivArtikla = "Okvir"
                 },
                 new VrstaArtikla()
                 {
                     VrstaArtiklaId = 3,
                     NazivArtikla = "Kontaktne lece"
                 }
             );
            modelBuilder.Entity<KorisnickiRacun>().HasData(
                 new KorisnickiRacun()
                 {
                     KorisnickiRacunId = 1,
                     Ime = "Naida",
                     Prezime = "Merzic",
                     Email = "naida@edu.fit.ba",
                     BrojTelefona = "4893746",
                     Adresa = "Mostar",
                     DatumRodjenja = DateTime.Now,
                     KorisnickoIme = "desktopAdmin",
                     LozinkaHash = "iT1uhx6S6PAyJprCMObyy9Fls3E=", //user
                     LozinkaSalt = "04ag2smW6AnPa2DMW0/iBg==", //user
                 },
                 new KorisnickiRacun()
                 {
                     KorisnickiRacunId = 2,
                     Ime = "Amel",
                     Prezime = "Music",
                     Email = "amel@edu.fit.ba",
                     BrojTelefona = "u493764",
                     Adresa = "Sarajevo",
                     DatumRodjenja = DateTime.Now,
                     KorisnickoIme = "mobile",
                     LozinkaHash = "iT1uhx6S6PAyJprCMObyy9Fls3E=", //user
                     LozinkaSalt = "04ag2smW6AnPa2DMW0/iBg==", //user
                 },
                 new KorisnickiRacun()
                 {
                     KorisnickiRacunId = 3,
                     Ime = "Amina",
                     Prezime = "Merzic",
                     Email = "amina@edu.fit.ba",
                     BrojTelefona = "4893746",
                     Adresa = "Mostar",
                     DatumRodjenja = DateTime.Now,
                     KorisnickoIme = "desktopBasic",
                     LozinkaHash = "iT1uhx6S6PAyJprCMObyy9Fls3E=", //user
                     LozinkaSalt = "04ag2smW6AnPa2DMW0/iBg==", //user
                 }
             );
            modelBuilder.Entity<Uposlenik>().HasData(
                 new Uposlenik()
                 {
                     UposlenikId = 1,
                     SpolId = 2,
                     KorisnickiRacunId = 1,
                     Status = true
                 },
                 new Uposlenik()
                 {
                     UposlenikId = 2,
                     SpolId = 2,
                     KorisnickiRacunId = 3,
                     Status = true
                 }
             ) ;
            modelBuilder.Entity<Klijent>().HasData(
                 new Klijent()
                 {
                     KlijentId = 1,
                     SpolId=1,
                     KorisnickiRacunId = 2,
                 }
             );
            modelBuilder.Entity<UposlenikRola>().HasData(
                 new UposlenikRola()
                 {
                     UposlenikRolaId = 1,
                     UposlenikId = 1,
                     RolaId = 1,
                     DatumIzmjene=DateTime.Now,
                 },
                 new UposlenikRola()
                 {
                     UposlenikRolaId = 2,
                     UposlenikId = 2,
                     RolaId = 2,
                     DatumIzmjene = DateTime.Now,
                 }
             );
            modelBuilder.Entity<Termin>().HasData(
                 new Termin()
                 {
                     TerminId = 1,
                     DatumTermina = DateTime.Now,
                     VrstaPregleda = "kontrola",
                     KlijentId=1
                 }
             );
            modelBuilder.Entity<Artikal>().HasData(
                new Artikal()
                {
                    ArtikalId = 1,
                    Naziv = "DG okvir za dioptrijske naocale",
                    Opis = "DG okvir za dioptrijske naocale",
                    Cijena = Convert.ToDecimal(200.00),
                    Sifra = "fnkfmk345",
                    StateMachine = "draft",
                    Slika = File.ReadAllBytes("img/slika2.PNG"),
                    VrstaArtiklaId = 2
                },
                new Artikal()
                {
                    ArtikalId = 2,
                    Naziv = "DG staklo za dioptrijske naocale",
                    Opis = "DG staklo za dioptrijske naocale",
                    Cijena = Convert.ToDecimal(200.00),
                    Sifra = "fnkfmk345",
                    StateMachine = "draft",
                    Slika = File.ReadAllBytes("img/slika1.PNG"),
                    VrstaArtiklaId = 1
                }
            );
            modelBuilder.Entity<Dojam>().HasData(
                new Dojam()
                {
                    DojamId = 1,
                    ArtikalId = 1,
                    IsLiked = true,
                    KlijentId = 1
                }
            );
            modelBuilder.Entity<Racun>().HasData(
                new Racun()
                {
                    RacunId = 1,
                    BrojRacuna = 543,
                    Iznos = 400,
                    KlijentId = 1,
                    Datum = DateTime.Now
                }
            );
            modelBuilder.Entity<StavkaRacuna>().HasData(
                new StavkaRacuna()
                {
                    StavkaRacunaId = 1,
                    RacunId = 1,
                    ArtikalId = 1,
                    Kolicina = 1
                },
                new StavkaRacuna()
                {
                    StavkaRacunaId = 2,
                    RacunId = 1,
                    ArtikalId = 2,
                    Kolicina = 1
                }
            );
            modelBuilder.Entity<Novost>().HasData(
                new Novost()
                {
                    NovostId = 1,
                    Naslov = "Akcija - popusti na oftamoloske preglede za studente!",
                    DatumObjave = DateTime.Now,
                    UposlenikId = 1, 
                    Sadrzaj = "Akcijske ponude na dioptrijska pomagala i popusti na oftamoloske preglede za studente!"
                }
            );
            modelBuilder.Entity<Dijagnoza>().HasData(
                new Dijagnoza()
                {
                    DijagnozaId = 1,
                    Naziv = "Refrakcione anomalije",
                    Sadrzaj = "Najčešće promjene i simptomi: suzni ocni kapci, mutan vid.",
                    KlijentId = 1, 
                }
            );
            modelBuilder.Entity<DijagnozaUposlenik>().HasData(
               new DijagnozaUposlenik()
               {
                   DijagnozaUposlenikId = 1,
                   DijagnozaId = 1,
                   UposlenikId = 1
               }
           );
        }
    }
}
