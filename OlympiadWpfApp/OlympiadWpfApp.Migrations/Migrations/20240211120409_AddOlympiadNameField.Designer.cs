﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OlympiadWpfApp.DataAccess.Contexts;

#nullable disable

namespace OlympiadWpfApp.Migrations.Migrations
{
    [DbContext(typeof(OlympDbContext))]
    [Migration("20240211120409_AddOlympiadNameField")]
    partial class AddOlympiadNameField
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.OlympiadEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("city");

                    b.Property<string>("HostCountry")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("host_country");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<bool>("IsWinter")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_winter");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<DateOnly>("Year")
                        .HasColumnType("date")
                        .HasColumnName("year");

                    b.HasKey("Id")
                        .HasName("Olympiad_pkey");

                    b.ToTable("Olympiad", (string)null);
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.OlympiadParticipantEntity", b =>
                {
                    b.Property<int>("ParticipantId")
                        .HasColumnType("integer")
                        .HasColumnName("participant_id");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OlympiadId")
                        .HasColumnType("integer")
                        .HasColumnName("olympiad_id");

                    b.HasKey("ParticipantId")
                        .HasName("Olympiad_Participant_pkey");

                    b.HasIndex("OlympiadId");

                    b.ToTable("Olympiad_Participant", (string)null);
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.ParticipantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Birthdate")
                        .HasColumnType("date")
                        .HasColumnName("birthdate");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("country");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false)
                        .HasColumnName("is_deleted");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("patronymic");

                    b.Property<byte[]>("Photo")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("photo");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("Participant_pkey");

                    b.ToTable("Participant", (string)null);
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.SportTypeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("Sport_Type_pkey");

                    b.ToTable("Sport_Type", (string)null);
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.SportTypeOlympiadEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("OlympiadId")
                        .HasColumnType("integer")
                        .HasColumnName("olympiad_id");

                    b.Property<int>("SportTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("sport_type_id");

                    b.HasKey("Id")
                        .HasName("Sport_Type_Olympiad_pkey");

                    b.HasIndex("OlympiadId");

                    b.HasIndex("SportTypeId");

                    b.ToTable("Sport_Type_Olympiad", (string)null);
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.SportTypeParticipantEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BronzeMedals")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("bronze_medals");

                    b.Property<int>("GoldMedals")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("gold_medals");

                    b.Property<int>("ParticipantId")
                        .HasColumnType("integer")
                        .HasColumnName("participant_id");

                    b.Property<int>("SilverMedals")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0)
                        .HasColumnName("silver_medals");

                    b.Property<int>("SportTypeId")
                        .HasColumnType("integer")
                        .HasColumnName("sport_type_id");

                    b.HasKey("Id")
                        .HasName("Sport_Type_Participant_pkey");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("SportTypeId");

                    b.ToTable("Sport_Type_Participant", (string)null);
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.OlympiadParticipantEntity", b =>
                {
                    b.HasOne("OlympiadWpfApp.DataAccess.Entities.OlympiadEntity", "OlympiadEntity")
                        .WithMany("OlympiadParticipants")
                        .HasForeignKey("OlympiadId")
                        .IsRequired()
                        .HasConstraintName("olympiad_fk");

                    b.HasOne("OlympiadWpfApp.DataAccess.Entities.ParticipantEntity", "ParticipantEntity")
                        .WithOne("OlympiadParticipant")
                        .HasForeignKey("OlympiadWpfApp.DataAccess.Entities.OlympiadParticipantEntity", "ParticipantId")
                        .IsRequired()
                        .HasConstraintName("participant_fk");

                    b.Navigation("OlympiadEntity");

                    b.Navigation("ParticipantEntity");
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.SportTypeOlympiadEntity", b =>
                {
                    b.HasOne("OlympiadWpfApp.DataAccess.Entities.OlympiadEntity", "OlympiadEntity")
                        .WithMany("SportTypeOlympiads")
                        .HasForeignKey("OlympiadId")
                        .IsRequired()
                        .HasConstraintName("olymp_FK");

                    b.HasOne("OlympiadWpfApp.DataAccess.Entities.SportTypeEntity", "SportTypeEntity")
                        .WithMany("SportTypeOlympiads")
                        .HasForeignKey("SportTypeId")
                        .IsRequired()
                        .HasConstraintName("sport_type_FK");

                    b.Navigation("OlympiadEntity");

                    b.Navigation("SportTypeEntity");
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.SportTypeParticipantEntity", b =>
                {
                    b.HasOne("OlympiadWpfApp.DataAccess.Entities.ParticipantEntity", "ParticipantEntity")
                        .WithMany("SportTypeParticipants")
                        .HasForeignKey("ParticipantId")
                        .IsRequired()
                        .HasConstraintName("participant_id");

                    b.HasOne("OlympiadWpfApp.DataAccess.Entities.SportTypeEntity", "SportTypeEntity")
                        .WithMany("SportTypeParticipants")
                        .HasForeignKey("SportTypeId")
                        .IsRequired()
                        .HasConstraintName("sport_type_fk");

                    b.Navigation("ParticipantEntity");

                    b.Navigation("SportTypeEntity");
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.OlympiadEntity", b =>
                {
                    b.Navigation("OlympiadParticipants");

                    b.Navigation("SportTypeOlympiads");
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.ParticipantEntity", b =>
                {
                    b.Navigation("OlympiadParticipant");

                    b.Navigation("SportTypeParticipants");
                });

            modelBuilder.Entity("OlympiadWpfApp.DataAccess.Entities.SportTypeEntity", b =>
                {
                    b.Navigation("SportTypeOlympiads");

                    b.Navigation("SportTypeParticipants");
                });
#pragma warning restore 612, 618
        }
    }
}
