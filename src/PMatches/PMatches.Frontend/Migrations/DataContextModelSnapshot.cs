﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PMatches.Frontend.Data;

#nullable disable

namespace PMatches.Frontend.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PMatches.Frontend.Models.Match", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("EquipNameHome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EquipNameVisitor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PointsFromHome")
                        .HasColumnType("int");

                    b.Property<int>("PointsFromVisitor")
                        .HasColumnType("int");

                    b.Property<decimal>("Prize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<bool>("WinHome")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("StatusId");

                    b.ToTable("Matches");
                });

            modelBuilder.Entity("PMatches.Frontend.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("PMatches.Frontend.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AgainstPoints")
                        .HasColumnType("int");

                    b.Property<int?>("CumulativePoints")
                        .HasColumnType("int");

                    b.Property<int?>("FavorPoints")
                        .HasColumnType("int");

                    b.Property<string>("Initials")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MatchesLost")
                        .HasColumnType("int");

                    b.Property<int?>("MatchesPlayed")
                        .HasColumnType("int");

                    b.Property<int?>("MatchesTied")
                        .HasColumnType("int");

                    b.Property<int?>("MatchesWon")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Position")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("PMatches.Frontend.Models.Match", b =>
                {
                    b.HasOne("PMatches.Frontend.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Status");
                });
#pragma warning restore 612, 618
        }
    }
}
