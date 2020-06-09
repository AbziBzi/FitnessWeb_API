using System;
using AutoMapper;
using FitnessWeb_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FitnessWeb_API.Repositories
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options, IMapper mapper)
            : base(options)
        {
            Mapper = mapper;
        }
        
        public readonly IMapper Mapper;
        public virtual DbSet<AtliekamasPratimas> AtliekamasPratimas { get; set; }
        public virtual DbSet<Naudotojas> Naudotojas { get; set; }
        public virtual DbSet<Pratimas> Pratimas { get; set; }
        public virtual DbSet<Reitingas> Reitingas { get; set; }
        public virtual DbSet<Sportininkas> Sportininkas { get; set; }
        public virtual DbSet<SportoPrograma> SportoPrograma { get; set; }
        public virtual DbSet<SportoProgramosPratimas> SportoProgramosPratimas { get; set; }
        public virtual DbSet<Treneris> Treneris { get; set; }
        public virtual DbSet<Varzybos> Varzybos { get; set; }
        public virtual DbSet<VarzybuDalyvis> VarzybuDalyvis { get; set; }
        public virtual DbSet<Zinute> Zinute { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // if (!optionsBuilder.IsConfigured)
            // {
            //     optionsBuilder.UseMySql("server=localhost;userid=root;database=fitnessweb", x => x.ServerVersion("10.4.11-mariadb"));
            // }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AtliekamasPratimas>(entity =>
            {
                entity.HasKey(e => e.IdAtliekamasPratimas)
                    .HasName("PRIMARY");

                entity.ToTable("Atliekamas_pratimas");

                entity.HasIndex(e => e.FkPratimasId)
                    .HasName("turi");

                entity.HasIndex(e => e.FkSportininkasId)
                    .HasName("atlieka");

                entity.HasIndex(e => e.FkTrenerisId)
                    .HasName("vertina");

                entity.Property(e => e.IdAtliekamasPratimas)
                    .HasColumnName("id_Atliekamas_pratimas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPratimasId)
                    .HasColumnName("fk_Pratimas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkSportininkasId)
                    .HasColumnName("fk_Sportininkas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkTrenerisId)
                    .HasColumnName("fk_Treneris_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ivertinimas)
                    .HasColumnName("ivertinimas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IvertinimoData)
                    .HasColumnName("ivertinimo_data")
                    .HasColumnType("date");

                entity.Property(e => e.Kiekis)
                    .HasColumnName("kiekis")
                    .HasColumnType("int(11)");

                entity.Property(e => e.VaizdoIrasasUrl)
                    .HasColumnName("vaizdo_irasas_URL")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkPratimas)
                    .WithMany(p => p.AtliekamasPratimas)
                    .HasForeignKey(d => d.FkPratimasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("turi");

                entity.HasOne(d => d.FkSportininkas)
                    .WithMany(p => p.AtliekamasPratimas)
                    .HasForeignKey(d => d.FkSportininkasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("atlieka");

                entity.HasOne(d => d.FkTreneris)
                    .WithMany(p => p.AtliekamasPratimas)
                    .HasForeignKey(d => d.FkTrenerisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("vertina");
            });

            modelBuilder.Entity<Naudotojas>(entity =>
            {
                entity.HasKey(e => e.IdNaudotojas)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdNaudotojas)
                    .HasColumnName("id_Naudotojas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Epastas)
                    .HasColumnName("epastas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Lygis)
                    .HasColumnName("lygis")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PaskutinioPrisijungimoData)
                    .HasColumnName("paskutinio_prisijungimo_data")
                    .HasColumnType("date");

                entity.Property(e => e.Pavarde)
                    .HasColumnName("pavarde")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.RegistracijosData)
                    .HasColumnName("registracijos_data")
                    .HasColumnType("date");

                entity.Property(e => e.Slaptazodis)
                    .HasColumnName("slaptazodis")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Vardas)
                    .HasColumnName("vardas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");
            });

            modelBuilder.Entity<Pratimas>(entity =>
            {
                entity.HasKey(e => e.IdPratimas)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdPratimas)
                    .HasColumnName("id_Pratimas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aprasymas)
                    .HasColumnName("aprasymas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.NuotraukosUrl)
                    .HasColumnName("nuotraukos_url")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Verte)
                    .HasColumnName("verte")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Reitingas>(entity =>
            {
                entity.HasKey(e => e.IdReitingas)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.FkSportininkasId)
                    .HasName("ivertina");

                entity.HasIndex(e => e.FkTrenerisId)
                    .HasName("priklauso1");

                entity.Property(e => e.IdReitingas)
                    .HasColumnName("id_Reitingas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkSportininkasId)
                    .HasColumnName("fk_Sportininkas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkTrenerisId)
                    .HasColumnName("fk_Treneris_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Ivertinimas)
                    .HasColumnName("ivertinimas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IvertinimoData)
                    .HasColumnName("ivertinimo_data")
                    .HasColumnType("date");

                entity.HasOne(d => d.FkSportininkas)
                    .WithMany(p => p.Reitingas)
                    .HasForeignKey(d => d.FkSportininkasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ivertina");

                entity.HasOne(d => d.FkTreneris)
                    .WithMany(p => p.Reitingas)
                    .HasForeignKey(d => d.FkTrenerisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priklauso1");
            });

            modelBuilder.Entity<Sportininkas>(entity =>
            {
                entity.HasKey(e => e.IdNaudotojas)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdNaudotojas)
                    .HasColumnName("id_Naudotojas")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AtliktuPratymuSkaicius)
                    .HasColumnName("atliktu_pratymu_skaicius")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Taskai)
                    .HasColumnName("taskai")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdNaudotojasNavigation)
                    .WithOne(p => p.Sportininkas)
                    .HasForeignKey<Sportininkas>(d => d.IdNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Sportininkas_ibfk_1");
            });

            modelBuilder.Entity<SportoPrograma>(entity =>
            {
                entity.HasKey(e => e.IdSportoPrograma)
                    .HasName("PRIMARY");

                entity.ToTable("Sporto_programa");

                entity.HasIndex(e => e.FkTrenerisId)
                    .HasName("kuria2");

                entity.Property(e => e.IdSportoPrograma)
                    .HasColumnName("id_Sporto_programa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aprasas)
                    .HasColumnName("aprasas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkTrenerisId)
                    .HasColumnName("fk_Treneris_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NuotraukosUrl)
                    .HasColumnName("nuotraukos_url")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkTreneris)
                    .WithMany(p => p.SportoPrograma)
                    .HasForeignKey(d => d.FkTrenerisId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kuria2");
            });

            modelBuilder.Entity<SportoProgramosPratimas>(entity =>
            {
                entity.HasKey(e => e.IdSportoProgramosPratimas)
                    .HasName("PRIMARY");

                entity.ToTable("Sporto_programos_pratimas");

                entity.HasIndex(e => e.FkPratimasId)
                    .HasName("priklauso");

                entity.HasIndex(e => e.FkSportoProgramaId)
                    .HasName("sudaro");

                entity.Property(e => e.IdSportoProgramosPratimas)
                    .HasColumnName("id_Sporto_programos_pratimas")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkPratimasId)
                    .HasColumnName("fk_Pratimas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkSportoProgramaId)
                    .HasColumnName("fk_Sporto_programa_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Kartojimai)
                    .HasColumnName("kartojimai")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Setai)
                    .HasColumnName("setai")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkPratimas)
                    .WithMany(p => p.SportoProgramosPratimas)
                    .HasForeignKey(d => d.FkPratimasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("priklauso");

                entity.HasOne(d => d.FkSportoPrograma)
                    .WithMany(p => p.SportoProgramosPratimas)
                    .HasForeignKey(d => d.FkSportoProgramaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sudaro");
            });

            modelBuilder.Entity<Treneris>(entity =>
            {
                entity.HasKey(e => e.IdNaudotojas)
                    .HasName("PRIMARY");

                entity.Property(e => e.IdNaudotojas)
                    .HasColumnName("id_Naudotojas")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Kaina)
                    .HasColumnName("kaina")
                    .HasColumnType("double");

                entity.HasOne(d => d.IdNaudotojasNavigation)
                    .WithOne(p => p.Treneris)
                    .HasForeignKey<Treneris>(d => d.IdNaudotojas)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Treneris_ibfk_1");
            });

            modelBuilder.Entity<Varzybos>(entity =>
            {
                entity.HasKey(e => e.IdVarzybos)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.FkNaudotojasId)
                    .HasName("kuria");

                entity.Property(e => e.IdVarzybos)
                    .HasColumnName("id_Varzybos")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Aprasas)
                    .HasColumnName("aprasas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.FkNaudotojasId)
                    .HasColumnName("fk_Naudotojas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PabaigosData)
                    .HasColumnName("pabaigos_data")
                    .HasColumnType("date");

                entity.Property(e => e.Pavadinimas)
                    .HasColumnName("pavadinimas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.PrasidejimoData)
                    .HasColumnName("prasidejimo_data")
                    .HasColumnType("date");

                entity.Property(e => e.Vieta)
                    .HasColumnName("vieta")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkNaudotojas)
                    .WithMany(p => p.Varzybos)
                    .HasForeignKey(d => d.FkNaudotojasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("kuria");
            });

            modelBuilder.Entity<VarzybuDalyvis>(entity =>
            {
                entity.HasKey(e => new { e.FkNaudotojasId, e.FkVarzybosId })
                    .HasName("PRIMARY");

                entity.ToTable("Varzybu_dalyvis");

                entity.HasIndex(e => e.FkVarzybosId)
                    .HasName("turi2");

                entity.Property(e => e.FkNaudotojasId)
                    .HasColumnName("fk_Naudotojas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkVarzybosId)
                    .HasColumnName("fk_Varzybos_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.FkNaudotojas)
                    .WithMany(p => p.VarzybuDalyvis)
                    .HasForeignKey(d => d.FkNaudotojasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("yra");

                entity.HasOne(d => d.FkVarzybos)
                    .WithMany(p => p.VarzybuDalyvis)
                    .HasForeignKey(d => d.FkVarzybosId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("turi2");
            });

            modelBuilder.Entity<Zinute>(entity =>
            {
                entity.HasKey(e => e.IdZinute)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.FkGavejasId)
                    .HasName("gauna");

                entity.HasIndex(e => e.FkSiuntejasId)
                    .HasName("siuncia");

                entity.HasIndex(e => e.FkZinuteId)
                    .HasName("atsako");

                entity.Property(e => e.IdZinute)
                    .HasColumnName("id_Zinute")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkGavejasId)
                    .HasColumnName("fk_Gavejas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkSiuntejasId)
                    .HasColumnName("fk_Siuntejas_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FkZinuteId)
                    .HasColumnName("fk_Zinute_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IssiuntimoLaikas)
                    .HasColumnName("issiuntimo_laikas")
                    .HasColumnType("date");

                entity.Property(e => e.Tekstas)
                    .HasColumnName("tekstas")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_general_ci");

                entity.HasOne(d => d.FkGavejas)
                    .WithMany(p => p.ZinuteFkGavejas)
                    .HasForeignKey(d => d.FkGavejasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("gauna");

                entity.HasOne(d => d.FkSiuntejas)
                    .WithMany(p => p.ZinuteFkSiuntejas)
                    .HasForeignKey(d => d.FkSiuntejasId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("siuncia");

                entity.HasOne(d => d.FkZinute)
                    .WithMany(p => p.InverseFkZinute)
                    .HasForeignKey(d => d.FkZinuteId)
                    .HasConstraintName("atsako");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
