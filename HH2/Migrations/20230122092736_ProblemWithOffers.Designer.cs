﻿// <auto-generated />
using System;
using HH2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(HHDbContext))]
    [Migration("20230122092736_ProblemWithOffers")]
    partial class ProblemWithOffers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HH2.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OfferentId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OfferentId");

                    b.ToTable("Addresses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Orzesze",
                            PostalCode = "43-190",
                            Street = "Dworcowa"
                        },
                        new
                        {
                            Id = 2,
                            City = "Mikołów",
                            PostalCode = "43-190",
                            Street = "Majowa"
                        },
                        new
                        {
                            Id = 3,
                            City = "Katowice",
                            PostalCode = "43-190",
                            Street = "Głogowa"
                        });
                });

            modelBuilder.Entity("HH2.Entities.Offer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PriceOffer")
                        .HasColumnType("int");

                    b.Property<int?>("Regularity")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("offerType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            CreatedDate = new DateTime(2023, 1, 22, 10, 27, 35, 630, DateTimeKind.Local).AddTicks(4908),
                            Description = "Oferuję usługi spzątania mieszkań we Wrocławiu",
                            Name = "Sprzątanie",
                            PriceOffer = 100,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            offerType = 0
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            CreatedDate = new DateTime(2023, 1, 22, 10, 27, 35, 630, DateTimeKind.Local).AddTicks(4996),
                            Description = "Oferuję usługi spzątania biur we Wrocławiu",
                            Name = "Sprzątanie",
                            PriceOffer = 150,
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            offerType = 0
                        });
                });

            modelBuilder.Entity("HH2.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("HH2.Utils.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Seeker"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Offerent"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Administrator"
                        });
                });

            modelBuilder.Entity("HH2.Entities.Offerent", b =>
                {
                    b.HasBaseType("HH2.Entities.User");

                    b.HasDiscriminator().HasValue("Offerent");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "jdsks@com",
                            Name = "Jan Kowalski",
                            PasswordHash = "#1234#",
                            PhoneNumber = "123456",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 2,
                            Email = "agak@wp.pl",
                            Name = "Aga Kruk",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 3
                        });
                });

            modelBuilder.Entity("HH2.Entities.Seeker", b =>
                {
                    b.HasBaseType("HH2.Entities.User");

                    b.Property<int?>("OfferentId")
                        .HasColumnType("int");

                    b.HasIndex("OfferentId");

                    b.HasDiscriminator().HasValue("Seeker");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Email = "jdsks@com",
                            Name = "Janian",
                            PasswordHash = "#1234#",
                            PhoneNumber = "123456",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 4,
                            Email = "agak@wp.pl",
                            Name = "Zsoia",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("HH2.Entities.Address", b =>
                {
                    b.HasOne("HH2.Entities.Offerent", null)
                        .WithMany("Addresses")
                        .HasForeignKey("OfferentId");
                });

            modelBuilder.Entity("HH2.Entities.Offer", b =>
                {
                    b.HasOne("HH2.Entities.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HH2.Entities.User", "User")
                        .WithMany("Offers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("HH2.Entities.User", b =>
                {
                    b.HasOne("HH2.Utils.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("HH2.Entities.Seeker", b =>
                {
                    b.HasOne("HH2.Entities.Offerent", null)
                        .WithMany("BlockedSeekers")
                        .HasForeignKey("OfferentId");
                });

            modelBuilder.Entity("HH2.Entities.User", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("HH2.Entities.Offerent", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("BlockedSeekers");
                });
#pragma warning restore 612, 618
        }
    }
}
