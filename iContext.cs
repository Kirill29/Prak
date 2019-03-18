using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Geoportal
{
    public partial class iContext : DbContext
    {
        public iContext()
        {
        }

        public iContext(DbContextOptions<iContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cmr> Cmr { get; set; }
        public virtual DbSet<Cmr1> Cmr1 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Database=i;Username=postgres;Password=0-0-0-");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("adminpack")
                .HasPostgresExtension("dblink")
                .HasPostgresExtension("postgis")
                .HasPostgresExtension("postgis_topology")
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<Cmr>(entity =>
            {
                entity.ToTable("cmr", "data");

                entity.ForNpgsqlHasComment("Цифровая модель рельефа");

                entity.HasIndex(e => e.CmrTypeCode)
                    .HasName("cmr_cmr_type_ind");

                entity.Property(e => e.CmrId)
                    .HasColumnName("cmr_id")
                    .HasDefaultValueSql("nextval('data.cmr_cmr_id_seq'::regclass)")
                    .ForNpgsqlHasComment("ИД ЦМР");

                entity.Property(e => e.CmrIdent)
                    .HasColumnName("cmr_ident")
                    .HasMaxLength(128);

                entity.Property(e => e.CmrKindCode)
                    .HasColumnName("cmr_kind_code")
                    .HasDefaultValueSql("0")
                    .ForNpgsqlHasComment("Вид ЦМР");

                entity.Property(e => e.CmrName)
                    .HasColumnName("cmr_name")
                    .HasMaxLength(255)
                    .ForNpgsqlHasComment("Наименование района");

                entity.Property(e => e.CmrTypeCode)
                    .HasColumnName("cmr_type_code")
                    .ForNpgsqlHasComment("Код типа карты");

                entity.Property(e => e.ComplE)
                    .HasColumnName("compl_e")
                    .HasDefaultValueSql("false")
                    .ForNpgsqlHasComment("Наличие сводки - восток");

                entity.Property(e => e.ComplN)
                    .HasColumnName("compl_n")
                    .HasDefaultValueSql("false")
                    .ForNpgsqlHasComment("Наличие сводки - север");

                entity.Property(e => e.ComplS)
                    .HasColumnName("compl_s")
                    .HasDefaultValueSql("false")
                    .ForNpgsqlHasComment("Наличие сводки - юг");

                entity.Property(e => e.ComplW)
                    .HasColumnName("compl_w")
                    .HasDefaultValueSql("false")
                    .ForNpgsqlHasComment("Наличие сводки - запад");

                entity.Property(e => e.CoordSysCode)
                    .HasColumnName("coord_sys_code")
                    .HasDefaultValueSql("4326")
                    .ForNpgsqlHasComment("Код EPSG системы координат");

                entity.Property(e => e.DateMake)
                    .HasColumnName("date_make")
                    .ForNpgsqlHasComment("Дата создания");

                entity.Property(e => e.DatumCode).HasColumnName("datum_code");

                entity.Property(e => e.Deleted).HasColumnName("deleted");

                entity.Property(e => e.FillingProcent).HasColumnName("filling_procent");

                entity.Property(e => e.FormatCode)
                    .HasColumnName("format_code")
                    .ForNpgsqlHasComment("Формат данных");

                entity.Property(e => e.Height)
                    .HasColumnName("height")
                    .ForNpgsqlHasComment("Размер по ширине");

                entity.Property(e => e.Legenda)
                    .HasColumnName("legenda")
                    .ForNpgsqlHasComment("Описание");

                entity.Property(e => e.MdId).HasColumnName("md_id");

                entity.Property(e => e.Metadata)
                    .HasColumnName("metadata")
                    .ForNpgsqlHasComment("Метаданные");

                entity.Property(e => e.NeLat)
                    .HasColumnName("ne_lat")
                    .ForNpgsqlHasComment("Широта северо-восточного угла  в системе WGS-84, рад");

                entity.Property(e => e.NeLong)
                    .HasColumnName("ne_long")
                    .ForNpgsqlHasComment("Долгота северо-восточного угла  в системе WGS-84, рад");

                entity.Property(e => e.Nomenclature)
                    .HasColumnName("nomenclature")
                    .HasMaxLength(30)
                    .ForNpgsqlHasComment("Номенклатура");

                entity.Property(e => e.NwLat)
                    .HasColumnName("nw_lat")
                    .ForNpgsqlHasComment("Широта северо-западного угла  в системе WGS-84, рад");

                entity.Property(e => e.NwLong)
                    .HasColumnName("nw_long")
                    .ForNpgsqlHasComment("Долгота северо-западного угла  в системе WGS-84, рад");

                entity.Property(e => e.Picture)
                    .HasColumnName("picture")
                    .ForNpgsqlHasComment("изображение");

                entity.Property(e => e.Resolution)
                    .HasColumnName("resolution")
                    .ForNpgsqlHasComment("Разрешение на местности");

                entity.Property(e => e.Scale)
                    .HasColumnName("scale")
                    .ForNpgsqlHasComment("Масштаб");

                entity.Property(e => e.SeLat)
                    .HasColumnName("se_lat")
                    .ForNpgsqlHasComment("Широта юго-восточного угла  в системе WGS-84, рад");

                entity.Property(e => e.SeLong)
                    .HasColumnName("se_long")
                    .ForNpgsqlHasComment("Долгота юго-восточного угла  в системе WGS-84, рад");

                entity.Property(e => e.SkoHgo)
                    .HasColumnName("sko_hgo")
                    .ForNpgsqlHasComment("СКО по высоте");

                entity.Property(e => e.SkoSgo)
                    .HasColumnName("sko_sgo")
                    .ForNpgsqlHasComment("СКО в плане");

                entity.Property(e => e.StepNet)
                    .HasColumnName("step_net")
                    .ForNpgsqlHasComment("Шаг сетки");

                entity.Property(e => e.SwLat)
                    .HasColumnName("sw_lat")
                    .ForNpgsqlHasComment("Широта юго-западного угла  в системе WGS-84, рад");

                entity.Property(e => e.SwLong)
                    .HasColumnName("sw_long")
                    .ForNpgsqlHasComment("Долгота юго-западного угла  в системе WGS-84, рад");

                entity.Property(e => e.UsesysidIns).HasColumnName("usesysid_ins");

                entity.Property(e => e.UsesysidUpd).HasColumnName("usesysid_upd");

                entity.Property(e => e.Width)
                    .HasColumnName("width")
                    .ForNpgsqlHasComment("Размер по высоте");

                entity.Property(e => e.YearMake)
                    .HasColumnName("year_make")
                    .ForNpgsqlHasComment("Год изготовления");
            });

            modelBuilder.Entity<Cmr1>(entity =>
            {
                entity.HasKey(e => new { e.CmrId, e.DeletId })
                    .HasName("pk_cmr_delet_id");

                entity.ToTable("cmr", "deletion");

                entity.Property(e => e.CmrId).HasColumnName("cmr_id");

                entity.Property(e => e.DeletId).HasColumnName("delet_id");

                entity.HasOne(d => d.Cmr)
                    .WithMany(p => p.Cmr1)
                    .HasForeignKey(d => d.CmrId)
                    .HasConstraintName("fk_cmr_id");
            });

            modelBuilder.HasSequence("demand_delete_demand_delete_nr_seq");

            modelBuilder.HasSequence("demand_retrieve_demand_retrieve_nr_seq").StartsAt(20);

            modelBuilder.HasSequence("directory_shots_directory_shots_nr_seq");

            modelBuilder.HasSequence("routes_on_cycle_nr_seq");

            modelBuilder.HasSequence("cmr_cmr_id_seq");

            modelBuilder.HasSequence("map_map_id_seq");

            modelBuilder.HasSequence("scan_scan_id_seq");

            modelBuilder.HasSequence("stereopair_stereo_num_seq");

            modelBuilder.HasSequence("region_region_id_seq");

            modelBuilder.HasSequence("scan_idplan_plan_id_seq");
        }
    }
}
