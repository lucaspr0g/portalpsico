﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

#nullable disable

namespace Persistence.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220511134252_user")]
    partial class user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Psychologist", b =>
                {
                    b.Property<string>("PsychologistId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Approach")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("ApprovedEPSI")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("CRP")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("isActive")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("PsychologistId")
                        .HasName("pkPsicologo");

                    b.ToTable("Psycologists");
                });

            modelBuilder.Entity("Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Day")
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PsychologistId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Time")
                        .HasColumnType("longtext");

                    b.HasKey("ScheduleId")
                        .HasName("pkAgenda");

                    b.HasIndex("PsychologistId");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleBooking", b =>
                {
                    b.Property<int>("BookingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("PsycologistId")
                        .IsRequired()
                        .HasColumnType("varchar(255)");

                    b.HasKey("BookingId")
                        .HasName("pkReserva");

                    b.HasIndex("PsycologistId");

                    b.ToTable("ScheduleBookings");
                });

            modelBuilder.Entity("Domain.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<bool>("IsActive")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("State")
                        .HasColumnType("longtext");

                    b.HasKey("UserId")
                        .HasName("pkUser");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Entities.Schedule", b =>
                {
                    b.HasOne("Domain.Entities.Psychologist", "Psychologist")
                        .WithMany("Schedules")
                        .HasForeignKey("PsychologistId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fkpsicologoAgendaId");

                    b.Navigation("Psychologist");
                });

            modelBuilder.Entity("Domain.Entities.ScheduleBooking", b =>
                {
                    b.HasOne("Domain.Entities.Psychologist", "Psycologist")
                        .WithMany("ScheduleBookings")
                        .HasForeignKey("PsycologistId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired()
                        .HasConstraintName("fkpsicologoReservaId");

                    b.Navigation("Psycologist");
                });

            modelBuilder.Entity("Domain.Entities.Psychologist", b =>
                {
                    b.Navigation("ScheduleBookings");

                    b.Navigation("Schedules");
                });
#pragma warning restore 612, 618
        }
    }
}
