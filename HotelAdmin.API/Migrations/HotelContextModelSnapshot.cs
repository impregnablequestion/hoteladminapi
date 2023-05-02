﻿// <auto-generated />
using HotelAdmin.API.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelAdmin.API.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HotelAdmin.API.Entities.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "Unique_Name")
                        .IsUnique();

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "18 Argyle Street, Glasgow, G42 8LT",
                            City = "Glasgow",
                            Country = "Scotland",
                            Email = "radissonblue@gmail.com",
                            Name = "Radisson Blue",
                            PhoneNumber = "+0913839409",
                            Website = "https://www.radisson.blue"
                        },
                        new
                        {
                            Id = 2,
                            Address = "12 O'Connell Street, Dublin, D1",
                            City = "Dublin",
                            Country = "Ireland",
                            Email = "yotel@gmail.com",
                            Name = "Yotel",
                            PhoneNumber = "+0837481739",
                            Website = "www.yotel.com"
                        },
                        new
                        {
                            Id = 3,
                            Address = "4 Oxford Street, London SW14",
                            City = "London",
                            Country = "United Kingdom",
                            Email = "hilton@gmail.com",
                            Name = "Hilton London",
                            PhoneNumber = "+0038291039901",
                            Website = "www.hilton.com"
                        });
                });

            modelBuilder.Entity("HotelAdmin.API.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("HotelId")
                        .HasColumnType("int");

                    b.Property<decimal>("PricePerNight")
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("RoomNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capacity = 5,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 2,
                            Capacity = 4,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 3,
                            Capacity = 5,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 4,
                            Capacity = 2,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 5,
                            Capacity = 3,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 6,
                            Capacity = 4,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 7,
                            Capacity = 1,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 8,
                            Capacity = 1,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 9,
                            Capacity = 2,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 10,
                            Capacity = 5,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 11,
                            Capacity = 4,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 12,
                            Capacity = 1,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 13,
                            Capacity = 2,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 14,
                            Capacity = 4,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 15,
                            Capacity = 4,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 16,
                            Capacity = 1,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 17,
                            Capacity = 4,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 18,
                            Capacity = 5,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 19,
                            Capacity = 5,
                            Description = "Auto-created Room for Radisson",
                            HotelId = 1,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 20,
                            Capacity = 3,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 21,
                            Capacity = 3,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 22,
                            Capacity = 1,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 23,
                            Capacity = 5,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 24,
                            Capacity = 4,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 25,
                            Capacity = 5,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 26,
                            Capacity = 4,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 27,
                            Capacity = 2,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 28,
                            Capacity = 3,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 29,
                            Capacity = 1,
                            Description = "Auto-created Room for Yotel",
                            HotelId = 2,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 30,
                            Capacity = 4,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 31,
                            Capacity = 1,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 32,
                            Capacity = 5,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 33,
                            Capacity = 2,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 34,
                            Capacity = 1,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 35,
                            Capacity = 2,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 36,
                            Capacity = 3,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 37,
                            Capacity = 2,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 38,
                            Capacity = 2,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 39,
                            Capacity = 1,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 40,
                            Capacity = 3,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 41,
                            Capacity = 2,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 42,
                            Capacity = 4,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 43,
                            Capacity = 1,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        },
                        new
                        {
                            Id = 44,
                            Capacity = 1,
                            Description = "Auto-created Room for Hilton",
                            HotelId = 3,
                            PricePerNight = 80.00m,
                            Type = 2
                        });
                });

            modelBuilder.Entity("HotelAdmin.API.Entities.Room", b =>
                {
                    b.HasOne("HotelAdmin.API.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("HotelAdmin.API.Entities.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
