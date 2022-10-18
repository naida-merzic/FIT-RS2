using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eOftamoloskiCentar.Services.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rola",
                columns: table => new
                {
                    RolaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rola", x => x.RolaId);
                });

            migrationBuilder.CreateTable(
                name: "Spol",
                columns: table => new
                {
                    SpolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spol", x => x.SpolId);
                });

            migrationBuilder.CreateTable(
                name: "VrstaArtikla",
                columns: table => new
                {
                    VrstaArtiklaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazivArtikla = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrstaArtikla", x => x.VrstaArtiklaId);
                });

            migrationBuilder.CreateTable(
                name: "Klijent",
                columns: table => new
                {
                    KlijentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpolId = table.Column<int>(type: "int", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Klijent", x => x.KlijentId);
                    table.ForeignKey(
                        name: "FK_Klijent_Spol",
                        column: x => x.SpolId,
                        principalTable: "Spol",
                        principalColumn: "SpolId");
                });

            migrationBuilder.CreateTable(
                name: "Uposlenik",
                columns: table => new
                {
                    UposlenikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LozinkaHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LozinkaSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpolId = table.Column<int>(type: "int", nullable: true),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: true, defaultValueSql: "('FALSE')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uposlenik", x => x.UposlenikId);
                    table.ForeignKey(
                        name: "FK_Uposlenik_Spol",
                        column: x => x.SpolId,
                        principalTable: "Spol",
                        principalColumn: "SpolId");
                });

            migrationBuilder.CreateTable(
                name: "Artikal",
                columns: table => new
                {
                    ArtikalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cijena = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    VrstaArtiklaId = table.Column<int>(type: "int", nullable: true),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StateMachine = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikal", x => x.ArtikalId);
                    table.ForeignKey(
                        name: "FK_Artikal_Vrsta",
                        column: x => x.VrstaArtiklaId,
                        principalTable: "VrstaArtikla",
                        principalColumn: "VrstaArtiklaId");
                });

            migrationBuilder.CreateTable(
                name: "Dijagnoza",
                columns: table => new
                {
                    DijagnozaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlijentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dijagnoza", x => x.DijagnozaId);
                    table.ForeignKey(
                        name: "FK_Dijagnoza_Klijent",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "KlijentId");
                });

            migrationBuilder.CreateTable(
                name: "Racun",
                columns: table => new
                {
                    RacunId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrojRacuna = table.Column<int>(type: "int", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime", nullable: true),
                    Iznos = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    KlijentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racun", x => x.RacunId);
                    table.ForeignKey(
                        name: "FK_Racun_Klijent",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "KlijentId");
                });

            migrationBuilder.CreateTable(
                name: "Termin",
                columns: table => new
                {
                    TerminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatumTermina = table.Column<DateTime>(type: "datetime", nullable: true),
                    Dioptrija = table.Column<double>(type: "float", nullable: true),
                    VrstaPregleda = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KlijentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Termin", x => x.TerminId);
                    table.ForeignKey(
                        name: "FK_Termin_Klijent",
                        column: x => x.KlijentId,
                        principalTable: "Klijent",
                        principalColumn: "KlijentId");
                });

            migrationBuilder.CreateTable(
                name: "Novost",
                columns: table => new
                {
                    NovostId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naslov = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sadrzaj = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DatumObjave = table.Column<DateTime>(type: "datetime", nullable: true),
                    UposlenikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novost", x => x.NovostId);
                    table.ForeignKey(
                        name: "FK_Novost_Uposlenik",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "UposlenikId");
                });

            migrationBuilder.CreateTable(
                name: "UposlenikRola",
                columns: table => new
                {
                    UposlenikRolaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UposlenikId = table.Column<int>(type: "int", nullable: true),
                    RolaId = table.Column<int>(type: "int", nullable: true),
                    DatumIzmjene = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UposlenikRola", x => x.UposlenikRolaId);
                    table.ForeignKey(
                        name: "FK_UposlenikRola_Rola",
                        column: x => x.RolaId,
                        principalTable: "Rola",
                        principalColumn: "RolaId");
                    table.ForeignKey(
                        name: "FK_UposlenikRola_Uposlenik",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "UposlenikId");
                });

            migrationBuilder.CreateTable(
                name: "Dijagnoza_Uposlenik",
                columns: table => new
                {
                    Dijagnoza_UposlenikId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UposlenikId = table.Column<int>(type: "int", nullable: true),
                    DijagnozaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dijagnoza_Uposlenik", x => x.Dijagnoza_UposlenikId);
                    table.ForeignKey(
                        name: "FK_Dijagnoza_Uposlenik_Dijagnoza",
                        column: x => x.DijagnozaId,
                        principalTable: "Dijagnoza",
                        principalColumn: "DijagnozaId");
                    table.ForeignKey(
                        name: "FK_Dijagnoza_Uposlenik_Uposlenik",
                        column: x => x.UposlenikId,
                        principalTable: "Uposlenik",
                        principalColumn: "UposlenikId");
                });

            migrationBuilder.CreateTable(
                name: "StavkaRacuna",
                columns: table => new
                {
                    StavkaRacunaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RacunId = table.Column<int>(type: "int", nullable: true),
                    ArtikalId = table.Column<int>(type: "int", nullable: true),
                    Kolicina = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkaRacuna", x => x.StavkaRacunaId);
                    table.ForeignKey(
                        name: "FK_StavkaRacuna_Artikal",
                        column: x => x.ArtikalId,
                        principalTable: "Artikal",
                        principalColumn: "ArtikalId");
                    table.ForeignKey(
                        name: "FK_StavkaRacuna_Racun",
                        column: x => x.RacunId,
                        principalTable: "Racun",
                        principalColumn: "RacunId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artikal_VrstaArtiklaId",
                table: "Artikal",
                column: "VrstaArtiklaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dijagnoza_KlijentId",
                table: "Dijagnoza",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Dijagnoza_Uposlenik_DijagnozaId",
                table: "Dijagnoza_Uposlenik",
                column: "DijagnozaId");

            migrationBuilder.CreateIndex(
                name: "IX_Dijagnoza_Uposlenik_UposlenikId",
                table: "Dijagnoza_Uposlenik",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Klijent_SpolId",
                table: "Klijent",
                column: "SpolId");

            migrationBuilder.CreateIndex(
                name: "IX_Novost_UposlenikId",
                table: "Novost",
                column: "UposlenikId");

            migrationBuilder.CreateIndex(
                name: "IX_Racun_KlijentId",
                table: "Racun",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaRacuna_ArtikalId",
                table: "StavkaRacuna",
                column: "ArtikalId");

            migrationBuilder.CreateIndex(
                name: "IX_StavkaRacuna_RacunId",
                table: "StavkaRacuna",
                column: "RacunId");

            migrationBuilder.CreateIndex(
                name: "IX_Termin_KlijentId",
                table: "Termin",
                column: "KlijentId");

            migrationBuilder.CreateIndex(
                name: "IX_Uposlenik_SpolId",
                table: "Uposlenik",
                column: "SpolId");

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikRola_RolaId",
                table: "UposlenikRola",
                column: "RolaId");

            migrationBuilder.CreateIndex(
                name: "IX_UposlenikRola_UposlenikId",
                table: "UposlenikRola",
                column: "UposlenikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dijagnoza_Uposlenik");

            migrationBuilder.DropTable(
                name: "Novost");

            migrationBuilder.DropTable(
                name: "StavkaRacuna");

            migrationBuilder.DropTable(
                name: "Termin");

            migrationBuilder.DropTable(
                name: "UposlenikRola");

            migrationBuilder.DropTable(
                name: "Dijagnoza");

            migrationBuilder.DropTable(
                name: "Artikal");

            migrationBuilder.DropTable(
                name: "Racun");

            migrationBuilder.DropTable(
                name: "Rola");

            migrationBuilder.DropTable(
                name: "Uposlenik");

            migrationBuilder.DropTable(
                name: "VrstaArtikla");

            migrationBuilder.DropTable(
                name: "Klijent");

            migrationBuilder.DropTable(
                name: "Spol");
        }
    }
}
