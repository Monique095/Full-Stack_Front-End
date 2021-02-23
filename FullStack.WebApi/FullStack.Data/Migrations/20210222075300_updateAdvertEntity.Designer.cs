﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApi.Helpers;

namespace FullStack.Data.Migrations
{
    [DbContext(typeof(FullStackDbContext))]
    [Migration("20210222075300_updateAdvertEntity")]
    partial class updateAdvertEntity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FullStack.Data.Entities.Advert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdvertDetail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AdvertHeadlineText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Adverts");
                });

            modelBuilder.Entity("FullStack.Data.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProvinceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityName = "Bloemfontein",
                            ProvinceId = 1
                        },
                        new
                        {
                            Id = 2,
                            CityName = "Bethlehem",
                            ProvinceId = 1
                        },
                        new
                        {
                            Id = 3,
                            CityName = "Pretoria",
                            ProvinceId = 2
                        },
                        new
                        {
                            Id = 4,
                            CityName = "Johannesburg",
                            ProvinceId = 2
                        },
                        new
                        {
                            Id = 5,
                            CityName = "Cape Town",
                            ProvinceId = 3
                        },
                        new
                        {
                            Id = 6,
                            CityName = "Somerset West",
                            ProvinceId = 3
                        },
                        new
                        {
                            Id = 7,
                            CityName = "Durban",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 8,
                            CityName = "Pietermaritzburg",
                            ProvinceId = 4
                        },
                        new
                        {
                            Id = 9,
                            CityName = "Nelspruit",
                            ProvinceId = 5
                        },
                        new
                        {
                            Id = 10,
                            CityName = "Witbank",
                            ProvinceId = 5
                        },
                        new
                        {
                            Id = 11,
                            CityName = "Port Elizabeth",
                            ProvinceId = 6
                        },
                        new
                        {
                            Id = 12,
                            CityName = "East London",
                            ProvinceId = 6
                        },
                        new
                        {
                            Id = 13,
                            CityName = "Rustenburg",
                            ProvinceId = 7
                        },
                        new
                        {
                            Id = 14,
                            CityName = "Potchefstroom",
                            ProvinceId = 7
                        });
                });

            modelBuilder.Entity("FullStack.Data.Entities.Province", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProvinceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProvinceName = "Free State"
                        },
                        new
                        {
                            Id = 2,
                            ProvinceName = "Gauteng"
                        },
                        new
                        {
                            Id = 3,
                            ProvinceName = "Western Cape"
                        },
                        new
                        {
                            Id = 4,
                            ProvinceName = "KwaZulu Natal"
                        },
                        new
                        {
                            Id = 5,
                            ProvinceName = "Mpumalanga"
                        },
                        new
                        {
                            Id = 6,
                            ProvinceName = "Eastern Cape"
                        },
                        new
                        {
                            Id = 7,
                            ProvinceName = "North West"
                        });
                });

            modelBuilder.Entity("WebApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FullStack.Data.Entities.Advert", b =>
                {
                    b.HasOne("WebApi.Entities.User", null)
                        .WithMany("Adverts")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FullStack.Data.Entities.City", b =>
                {
                    b.HasOne("FullStack.Data.Entities.Province", null)
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
