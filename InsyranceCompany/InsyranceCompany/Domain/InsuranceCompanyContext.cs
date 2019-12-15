using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace InsyranceCompany
{
    public partial class InsuranceCompanyContext : DbContext
    {
        public InsuranceCompanyContext()
        {
        }

        public InsuranceCompanyContext(DbContextOptions<InsuranceCompanyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agents> Agents { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<Contracts> Contracts { get; set; }
        public virtual DbSet<Filials> Filials { get; set; }
        public virtual DbSet<FioIds> FioIds { get; set; }
        public virtual DbSet<InsuranceCompanyClientsView> InsuranceCompanyClientsView { get; set; }
        public virtual DbSet<InsuranceCompanyWorkers> InsuranceCompanyWorkers { get; set; }
        public virtual DbSet<InsuranceType> InsuranceType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=InsuranceCompany;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agents>(entity =>
            {
                entity.HasKey(e => e.AgentId)
                    .HasName("PK__Agents__2C05379ECB3CCA43");

                entity.Property(e => e.AgentId).HasColumnName("agent_id");

                entity.Property(e => e.AAddress)
                    .HasColumnName("a_address")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.AName)
                    .HasColumnName("a_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.APatronymic)
                    .HasColumnName("a_patronymic")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.APhone)
                    .HasColumnName("a_phone")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ASurname)
                    .HasColumnName("a_surname")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FilialId).HasColumnName("filial_id");

                entity.Property(e => e.Salary)
                    .HasColumnName("salary")
                    .HasColumnType("money");

                entity.HasOne(d => d.Filial)
                    .WithMany(p => p.Agents)
                    .HasForeignKey(d => d.FilialId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Agents__filial_i__3E1D39E1");
            });

            modelBuilder.Entity<Clients>(entity =>
            {
                entity.HasKey(e => e.ClientId)
                    .HasName("PK__Clients__BF21A424056BA5B6");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.BirthYear)
                    .HasColumnName("birth_year")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CName)
                    .HasColumnName("c_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CPatronymic)
                    .HasColumnName("c_patronymic")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CPhone)
                    .HasColumnName("c_phone")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.CSurname)
                    .HasColumnName("c_surname")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Contracts>(entity =>
            {
                entity.HasKey(e => e.ContractId)
                    .HasName("PK__Contract__F8D66423CE0BCE1C");

                entity.Property(e => e.ContractId).HasColumnName("contract_id");

                entity.Property(e => e.AgentId).HasColumnName("agent_id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.DateConclusion)
                    .HasColumnName("date_conclusion")
                    .HasColumnType("date");

                entity.Property(e => e.InsuranceTypeId).HasColumnName("insurance_type_id");

                entity.Property(e => e.Payment)
                    .HasColumnName("payment")
                    .HasColumnType("money");

                entity.HasOne(d => d.Agent)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.AgentId)
                    .HasConstraintName("FK__Contracts__agent__41EDCAC5");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contracts__clien__42E1EEFE");

                entity.HasOne(d => d.InsuranceType)
                    .WithMany(p => p.Contracts)
                    .HasForeignKey(d => d.InsuranceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Contracts__insur__40F9A68C");
            });

            modelBuilder.Entity<Filials>(entity =>
            {
                entity.HasKey(e => e.FilialId)
                    .HasName("PK__Filials__DE090C4DFFEA28B4");

                entity.Property(e => e.FilialId).HasColumnName("filial_id");

                entity.Property(e => e.FilialAddress)
                    .HasColumnName("filial_address")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FilialPhone)
                    .HasColumnName("filial_phone")
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FioIds>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FIO_IDS");

                entity.Property(e => e.Id)
                    .IsRequired()
                    .HasColumnName("id")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InsuranceCompanyClientsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Insurance_company_clients_view");

                entity.Property(e => e.CPhone)
                    .HasColumnName("c_phone")
                    .HasMaxLength(17)
                    .IsUnicode(false);

                entity.Property(e => e.Фио)
                    .IsRequired()
                    .HasColumnName("ФИО")
                    .HasMaxLength(62)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InsuranceCompanyWorkers>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Insurance_company_workers");

                entity.Property(e => e.МестоРаботы)
                    .HasColumnName("Место работы")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.НомерТелефона)
                    .HasColumnName("Номер телефона")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ФиоАгента)
                    .IsRequired()
                    .HasColumnName("ФИО Агента")
                    .HasMaxLength(62)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<InsuranceType>(entity =>
            {
                entity.ToTable("Insurance_Type");

                entity.Property(e => e.InsuranceTypeId).HasColumnName("insurance_type_id");

                entity.Property(e => e.InsuranceName)
                    .HasColumnName("insurance_name")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.InsuranceSummary)
                    .HasColumnName("insurance_summary")
                    .HasColumnType("money");

                entity.Property(e => e.TarifRate)
                    .HasColumnName("tarif_rate")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
