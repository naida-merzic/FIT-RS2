using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace eOftamoloskiCentar.Services.Database
{
    public partial class OftamoloskiCentarContext : DbContext
    {
        public OftamoloskiCentarContext()
        {
        }

        public OftamoloskiCentarContext(DbContextOptions<OftamoloskiCentarContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Artikal> Artikals { get; set; } = null!;
        public virtual DbSet<Dijagnoza> Dijagnozas { get; set; } = null!;
        public virtual DbSet<DijagnozaUposlenik> DijagnozaUposleniks { get; set; } = null!;
        public virtual DbSet<Klijent> Klijents { get; set; } = null!;
        public virtual DbSet<Novost> Novosts { get; set; } = null!;
        public virtual DbSet<Racun> Racuns { get; set; } = null!;
        public virtual DbSet<Rola> Rolas { get; set; } = null!;
        public virtual DbSet<Spol> Spols { get; set; } = null!;
        public virtual DbSet<StavkaRacuna> StavkaRacunas { get; set; } = null!;
        public virtual DbSet<Termin> Termins { get; set; } = null!;
        public virtual DbSet<Uposlenik> Uposleniks { get; set; } = null!;
        public virtual DbSet<UposlenikRola> UposlenikRolas { get; set; } = null!;
        public virtual DbSet<VrstaArtikla> VrstaArtiklas { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=OftamoloskiCentar;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artikal>(entity =>
            {
                entity.ToTable("Artikal");

                entity.Property(e => e.Cijena).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.VrstaArtikla)
                    .WithMany(p => p.Artikals)
                    .HasForeignKey(d => d.VrstaArtiklaId)
                    .HasConstraintName("FK_Artikal_Vrsta");
            });

            modelBuilder.Entity<Dijagnoza>(entity =>
            {
                entity.ToTable("Dijagnoza");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Dijagnozas)
                    .HasForeignKey(d => d.KlijentId)
                    .HasConstraintName("FK_Dijagnoza_Klijent");
            });

            modelBuilder.Entity<DijagnozaUposlenik>(entity =>
            {
                entity.ToTable("Dijagnoza_Uposlenik");

                entity.Property(e => e.DijagnozaUposlenikId).HasColumnName("Dijagnoza_UposlenikId");

                entity.HasOne(d => d.Dijagnoza)
                    .WithMany(p => p.DijagnozaUposleniks)
                    .HasForeignKey(d => d.DijagnozaId)
                    .HasConstraintName("FK_Dijagnoza_Uposlenik_Dijagnoza");

                entity.HasOne(d => d.Uposlenik)
                    .WithMany(p => p.DijagnozaUposleniks)
                    .HasForeignKey(d => d.UposlenikId)
                    .HasConstraintName("FK_Dijagnoza_Uposlenik_Uposlenik");
            });

            modelBuilder.Entity<Klijent>(entity =>
            {
                entity.ToTable("Klijent");

                entity.HasOne(d => d.Spol)
                    .WithMany(p => p.Klijents)
                    .HasForeignKey(d => d.SpolId)
                    .HasConstraintName("FK_Klijent_Spol");
            });

            modelBuilder.Entity<Novost>(entity =>
            {
                entity.ToTable("Novost");

                entity.Property(e => e.DatumObjave).HasColumnType("datetime");

                entity.HasOne(d => d.Uposlenik)
                    .WithMany(p => p.Novosts)
                    .HasForeignKey(d => d.UposlenikId)
                    .HasConstraintName("FK_Novost_Uposlenik");
            });

            modelBuilder.Entity<Racun>(entity =>
            {
                entity.ToTable("Racun");

                entity.Property(e => e.Datum).HasColumnType("datetime");

                entity.Property(e => e.Iznos).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Racuns)
                    .HasForeignKey(d => d.KlijentId)
                    .HasConstraintName("FK_Racun_Klijent");
            });

            modelBuilder.Entity<Rola>(entity =>
            {
                entity.ToTable("Rola");

                entity.Property(e => e.Naziv).HasMaxLength(10);
            });

            modelBuilder.Entity<Spol>(entity =>
            {
                entity.ToTable("Spol");

                entity.Property(e => e.Naziv).HasMaxLength(10);
            });

            modelBuilder.Entity<StavkaRacuna>(entity =>
            {
                entity.ToTable("StavkaRacuna");

                entity.HasOne(d => d.Artikal)
                    .WithMany(p => p.StavkaRacunas)
                    .HasForeignKey(d => d.ArtikalId)
                    .HasConstraintName("FK_StavkaRacuna_Artikal");

                entity.HasOne(d => d.Racun)
                    .WithMany(p => p.StavkaRacunas)
                    .HasForeignKey(d => d.RacunId)
                    .HasConstraintName("FK_StavkaRacuna_Racun");
            });

            modelBuilder.Entity<Termin>(entity =>
            {
                entity.ToTable("Termin");

                entity.Property(e => e.DatumTermina).HasColumnType("datetime");

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Termins)
                    .HasForeignKey(d => d.KlijentId)
                    .HasConstraintName("FK_Termin_Klijent");
            });

            modelBuilder.Entity<Uposlenik>(entity =>
            {
                entity.ToTable("Uposlenik");

                entity.Property(e => e.Status).HasDefaultValueSql("('FALSE')");

                entity.HasOne(d => d.Spol)
                    .WithMany(p => p.Uposleniks)
                    .HasForeignKey(d => d.SpolId)
                    .HasConstraintName("FK_Uposlenik_Spol");
            });

            modelBuilder.Entity<UposlenikRola>(entity =>
            {
                entity.ToTable("UposlenikRola");

                entity.Property(e => e.DatumIzmjene).HasColumnType("datetime");

                entity.HasOne(d => d.Rola)
                    .WithMany(p => p.UposlenikRolas)
                    .HasForeignKey(d => d.RolaId)
                    .HasConstraintName("FK_UposlenikRola_Rola");

                entity.HasOne(d => d.Uposlenik)
                    .WithMany(p => p.UposlenikRolas)
                    .HasForeignKey(d => d.UposlenikId)
                    .HasConstraintName("FK_UposlenikRola_Uposlenik");
            });

            modelBuilder.Entity<VrstaArtikla>(entity =>
            {
                entity.ToTable("VrstaArtikla");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
