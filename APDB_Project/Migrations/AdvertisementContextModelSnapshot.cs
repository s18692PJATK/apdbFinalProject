﻿// <auto-generated />
using System;
using APDB_Project.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace APDB_Project.Migrations
{
    [DbContext(typeof(AdvertisementContext))]
    partial class AdvertisementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0-preview.5.20278.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("APDB_Project.Domain.Banner", b =>
                {
                    b.Property<int>("IdBanner")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Area")
                        .HasColumnType("float");

                    b.Property<int>("IdCampaign")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("IdBanner");

                    b.HasIndex("IdCampaign");

                    b.ToTable("Banner2");
                });

            modelBuilder.Entity("APDB_Project.Domain.Building", b =>
                {
                    b.Property<int>("IdBuilding")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Height")
                        .HasColumnType("real");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StreetNumber")
                        .HasColumnType("int");

                    b.HasKey("IdBuilding");

                    b.ToTable("Building2");
                });

            modelBuilder.Entity("APDB_Project.Domain.Campaign", b =>
                {
                    b.Property<int>("IdCampaign")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FromIdBuilding")
                        .HasColumnType("int");

                    b.Property<int?>("IdClient")
                        .HasColumnType("int");

                    b.Property<double>("PricePerSquareMeter")
                        .HasColumnType("float");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ToIdBuilding")
                        .HasColumnType("int");

                    b.HasKey("IdCampaign");

                    b.HasIndex("FromIdBuilding");

                    b.HasIndex("IdClient");

                    b.HasIndex("ToIdBuilding");

                    b.ToTable("Campaign2");
                });

            modelBuilder.Entity("APDB_Project.Domain.Client", b =>
                {
                    b.Property<int>("IdClient")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Login")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdClient");

                    b.HasIndex("Login")
                        .IsUnique()
                        .HasFilter("[Login] IS NOT NULL");

                    b.ToTable("Client2");
                });

            modelBuilder.Entity("APDB_Project.Domain.Banner", b =>
                {
                    b.HasOne("APDB_Project.Domain.Campaign", "Campaign")
                        .WithMany("Banners")
                        .HasForeignKey("IdCampaign")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("APDB_Project.Domain.Campaign", b =>
                {
                    b.HasOne("APDB_Project.Domain.Building", "FromBuilding")
                        .WithMany("FromBuildingCampaigns")
                        .HasForeignKey("FromIdBuilding")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("APDB_Project.Domain.Client", "Client")
                        .WithMany("Campaigns")
                        .HasForeignKey("IdClient")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("APDB_Project.Domain.Building", "ToBuilding")
                        .WithMany("ToBuildingCampaigns")
                        .HasForeignKey("ToIdBuilding")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
