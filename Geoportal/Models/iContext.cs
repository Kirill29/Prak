﻿using System;
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

        public virtual DbSet<DemandArchiveErs> DemandArchiveErss { get; set; }
        public virtual DbSet<FilesDemandArchiveErs> FilesDemandArchiveErss { get; set; }

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
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<DemandArchiveErs>(entity =>
            {
                entity.HasKey(e => e.DemandArchiveErsNr)
                    .HasName("demand_archive_pkey");

                entity.ToTable("demand_archive_ers", "archive");

                entity.Property(e => e.DemandArchiveErsNr)
                    .HasColumnName("demand_archive_ers_nr")
                    .HasDefaultValueSql("nextval('archive.demand_archive_demand_archive_nr_seq'::regclass)");

                entity.Property(e => e.CmrId)
                    .HasColumnName("cmr_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ConfirmDeleteAfterArchive)
                    .HasColumnName("confirm_delete_after_archive")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DelId)
                    .HasColumnName("del_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DocId)
                    .HasColumnName("doc_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DomainNameToShare)
                    .HasColumnName("domain_name_to_share")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'workgroup'::character varying");

                entity.Property(e => e.DtstampBeginDemand)
                    .HasColumnName("dtstamp_begin_demand")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DtstampEndDemand).HasColumnName("dtstamp_end_demand");

                entity.Property(e => e.ErrorCode)
                    .HasColumnName("error_code")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MapId)
                    .HasColumnName("map_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MessageFromService)
                    .HasColumnName("message_from_service")
                    .HasMaxLength(2048)
                    .HasDefaultValueSql("'No any message'::character varying");

                entity.Property(e => e.NumberOfDemandArchiveNr)
                    .HasColumnName("number_of_demand_archive_nr")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ObjectId)
                    .HasColumnName("object_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.OfpId)
                    .HasColumnName("ofp_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.PasswordToShare)
                    .HasColumnName("password_to_share")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("'password'::character varying");

                entity.Property(e => e.PathToProfEbgd)
                    .HasColumnName("path_to_prof_ebgd")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("'nothing'::character varying");

                entity.Property(e => e.PathToShare)
                    .HasColumnName("path_to_share")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("'/'::character varying");

                entity.Property(e => e.Priority)
                    .HasColumnName("priority")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.ProductId)
                    .HasColumnName("product_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProgressPercentage)
                    .HasColumnName("progress_percentage")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProgressPercentageRemote)
                    .HasColumnName("progress_percentage_remote")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RegionTypesNr)
                    .HasColumnName("region_types_nr")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RouteId)
                    .HasColumnName("route_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ScanId)
                    .HasColumnName("scan_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.SensorId)
                    .HasColumnName("sensor_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ServerToShare)
                    .HasColumnName("server_to_share")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'0.0.0.0'::character varying");

                entity.Property(e => e.ServiceTypeToShare)
                    .HasColumnName("service_type_to_share")
                    .HasMaxLength(64)
                    .HasDefaultValueSql("'LOCAL'::character varying");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TrackId)
                    .HasColumnName("track_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.TypesDemandNr)
                    .HasColumnName("types_demand_nr")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UserToShare)
                    .HasColumnName("user_to_share")
                    .HasMaxLength(128)
                    .HasDefaultValueSql("'user'::character varying");

                entity.Property(e => e.UsesysidIns).HasColumnName("usesysid_ins");

                entity.Property(e => e.UsesysidUpd).HasColumnName("usesysid_upd");

                entity.Property(e => e.WorkstationsNr).HasColumnName("workstations_nr");
            });

            modelBuilder.Entity<FilesDemandArchiveErs>(entity =>
            {
                entity.HasKey(e => e.FilesDemandArchiveErsNr)
                    .HasName("files_demand_to_archive_pkey");

                entity.ToTable("files_demand_archive_ers", "archive");

                entity.HasIndex(e => e.DemandArchiveErsNr)
                    .HasName("files_demand_archive_ers_demand_archive_ers_nr_idx");

                entity.Property(e => e.FilesDemandArchiveErsNr)
                    .HasColumnName("files_demand_archive_ers_nr")
                    .HasDefaultValueSql("nextval('archive.files_demand_to_archive_files_demand_to_archive_nr_seq'::regclass)");

                entity.Property(e => e.CmrId)
                    .HasColumnName("cmr_id")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.DemandArchiveErsNr).HasColumnName("demand_archive_ers_nr");

                entity.Property(e => e.DomainNameToShare)
                    .HasColumnName("domain_name_to_share")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'workgroup'::character varying");

                entity.Property(e => e.ErrorCode)
                    .HasColumnName("error_code")
                    .HasDefaultValueSql("2");

                entity.Property(e => e.ExpectedMd5)
                    .HasColumnName("expected_md5")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'NOTHING'::character varying");

                entity.Property(e => e.FileSizeInBytes)
                    .HasColumnName("file_size_in_bytes")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.FileSizeInBytesArchived)
                    .HasColumnName("file_size_in_bytes_archived")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.MessageFromService)
                    .HasColumnName("message_from_service")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'No any message'::character varying");

                entity.Property(e => e.PasswordToShare)
                    .HasColumnName("password_to_share")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("'password'::character varying");

                entity.Property(e => e.PathFileName)
                    .HasColumnName("path_file_name")
                    .HasMaxLength(512);

                entity.Property(e => e.PathToShare)
                    .HasColumnName("path_to_share")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("'/'::character varying");

                entity.Property(e => e.ProgressPercentage)
                    .HasColumnName("progress_percentage")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ProgressPercentageRemote)
                    .HasColumnName("progress_percentage_remote")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.RealMd5)
                    .HasColumnName("real_md5")
                    .HasColumnType("character varying")
                    .HasDefaultValueSql("'NOTHING'::character varying");

                entity.Property(e => e.ServerToShare)
                    .HasColumnName("server_to_share")
                    .HasMaxLength(1024)
                    .HasDefaultValueSql("'0.0.0.0'::character varying");

                entity.Property(e => e.ServiceTypeToShare)
                    .HasColumnName("service_type_to_share")
                    .HasMaxLength(10)
                    .HasDefaultValueSql("'LOCAL'::character varying");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UniqueIdentAresp)
                    .HasColumnName("unique_ident_aresp")
                    .HasDefaultValueSql("'-1'::integer");

                entity.Property(e => e.UniqueIdentForRetrieve)
                    .HasColumnName("unique_ident_for_retrieve")
                    .HasDefaultValueSql("'-1'::integer");

                entity.Property(e => e.UserToShare)
                    .HasColumnName("user_to_share")
                    .HasMaxLength(100)
                    .HasDefaultValueSql("'user'::character varying");

                entity.Property(e => e.UsesysidIns).HasColumnName("usesysid_ins");

                entity.Property(e => e.UsesysidUpd).HasColumnName("usesysid_upd");
            });

            modelBuilder.HasSequence("demand_archive_demand_archive_nr_seq");

            modelBuilder.HasSequence("demand_delete_demand_delete_nr_seq");

            modelBuilder.HasSequence("demand_retrieve_demand_retrieve_nr_seq").StartsAt(20);

            modelBuilder.HasSequence("directory_shots_directory_shots_nr_seq");

            modelBuilder.HasSequence("files_demand_to_archive_files_demand_to_archive_nr_seq");

            modelBuilder.HasSequence("routes_on_cycle_nr_seq");

            modelBuilder.HasSequence("clouds_cloud_id_seq");

            modelBuilder.HasSequence("cmr_cmr_id_seq");

            modelBuilder.HasSequence("cmr_list_cmr_list_id_seq");

            modelBuilder.HasSequence("document_doc_id_seq");

            modelBuilder.HasSequence("document_list_doc_list_id_seq");

            modelBuilder.HasSequence("ggs_catalog_id_seq");

            modelBuilder.HasSequence("ggs_id_seq");

            modelBuilder.HasSequence("hole_hole_id_seq");

            modelBuilder.HasSequence("map_list_map_list_id_seq");

            modelBuilder.HasSequence("map_map_id_seq");

            modelBuilder.HasSequence("ofp_list_ofp_list_id_seq");

            modelBuilder.HasSequence("ofp_ofp_id_seq");

            modelBuilder.HasSequence("point_list_point_list_id_seq");

            modelBuilder.HasSequence("point_point_id_seq");

            modelBuilder.HasSequence("scan_list_scan_list_id_seq");

            modelBuilder.HasSequence("scan_scan_id_seq");

            modelBuilder.HasSequence("stereopair_stereo_num_seq");

            modelBuilder.HasSequence("track_list_track_list_id_seq");

            modelBuilder.HasSequence("track_track_id_seq");

            modelBuilder.HasSequence("object_list_object_list_id_seq");

            modelBuilder.HasSequence("objects_object_id_seq");

            modelBuilder.HasSequence("region_region_id_seq");

            modelBuilder.HasSequence("task_task_id_seq");

            modelBuilder.HasSequence("scan_idplan_plan_id_seq");

            modelBuilder.HasSequence("zapros_map_zapros_map_id_seq");

            modelBuilder.HasSequence("zapros_scan_zapros_id_seq");
        }
    }
}
