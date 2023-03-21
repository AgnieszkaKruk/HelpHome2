﻿// <auto-generated />
using System;
using HH2;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(HHDbContext))]
    partial class HHDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("End")
                        .HasPrecision(5)
                        .HasColumnType("datetime2(5)");

                    b.Property<DateTime>("Start")
                        .HasPrecision(5)
                        .HasColumnType("datetime2(5)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Events");
                });

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
                            Street = "Majowa 5"
                        },
                        new
                        {
                            Id = 3,
                            City = "Katowice",
                            PostalCode = "43-190",
                            Street = "Kopernika 34"
                        },
                        new
                        {
                            Id = 4,
                            City = "Katowice",
                            PostalCode = "43-190",
                            Street = "Głogowa 8"
                        },
                        new
                        {
                            Id = 5,
                            City = "Wrocław",
                            PostalCode = "13-190",
                            Street = "Główna 10"
                        },
                        new
                        {
                            Id = 6,
                            City = "Kraków",
                            PostalCode = "43-190",
                            Street = "Moja 14"
                        },
                        new
                        {
                            Id = 7,
                            City = "Katowice",
                            PostalCode = "43-190",
                            Street = "Zielona 5"
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
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getutcdate()");

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

                    b.Property<DateTime?>("UpdateDate")
                        .ValueGeneratedOnUpdate()
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("offerType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique();

                    b.HasIndex("UserId");

                    b.ToTable("Offers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddressId = 1,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3312),
                            Description = "Oferuję usługi spzątania mieszkań we Wrocławiu",
                            Name = "Sprzątanie",
                            PriceOffer = 100,
                            UserId = 1,
                            offerType = 0
                        },
                        new
                        {
                            Id = 2,
                            AddressId = 2,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3443),
                            Description = "Oferuję usługi spzątania najlepiej i najtaniej",
                            Name = "Sprzątanie",
                            PriceOffer = 150,
                            UserId = 1,
                            offerType = 0
                        },
                        new
                        {
                            Id = 3,
                            AddressId = 3,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3497),
                            Description = "Posprzątam u Ciebie!",
                            Name = "Sprzątanie",
                            PriceOffer = 100,
                            UserId = 1,
                            offerType = 0
                        },
                        new
                        {
                            Id = 4,
                            AddressId = 4,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3633),
                            Description = "Oferuję usługi myycia okien",
                            Name = "Mycie okien",
                            PriceOffer = 800,
                            UserId = 1,
                            offerType = 1
                        },
                        new
                        {
                            Id = 5,
                            AddressId = 5,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3722),
                            Description = "Myje okna az sie błyszczą",
                            Name = "Mycie okien",
                            PriceOffer = 100,
                            UserId = 2,
                            offerType = 1
                        },
                        new
                        {
                            Id = 6,
                            AddressId = 6,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3786),
                            Description = "Najtaniej, najelpiej i najszybciej umyje Ci okna",
                            Name = "Mycie okien",
                            PriceOffer = 100,
                            UserId = 2,
                            offerType = 1
                        },
                        new
                        {
                            Id = 7,
                            AddressId = 1,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3836),
                            Description = "Oferuję usługi mycia okien na błysk!",
                            Name = "Mycie okien",
                            PriceOffer = 100,
                            UserId = 2,
                            offerType = 1
                        },
                        new
                        {
                            Id = 8,
                            AddressId = 2,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3888),
                            Description = "Oferuję usługi spzątania biur w Twoim miescie",
                            Name = "Sprzątanie",
                            PriceOffer = 100,
                            UserId = 3,
                            offerType = 0
                        },
                        new
                        {
                            Id = 9,
                            AddressId = 3,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3939),
                            Description = "SPRZATANIE NA JUZ",
                            Name = "Sprzątanie",
                            PriceOffer = 100,
                            UserId = 4,
                            offerType = 0
                        },
                        new
                        {
                            Id = 10,
                            AddressId = 4,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(3995),
                            Description = "SPRZATANIE NA JUZ",
                            Name = "Sprzątanie",
                            PriceOffer = 100,
                            UserId = 5,
                            offerType = 0
                        },
                        new
                        {
                            Id = 11,
                            AddressId = 5,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4087),
                            Description = "sprzatam jutro",
                            Name = "Sprzątanie",
                            PriceOffer = 100,
                            UserId = 6,
                            offerType = 0
                        },
                        new
                        {
                            Id = 12,
                            AddressId = 6,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4151),
                            Description = "SPRZATANIE teraz",
                            Name = "Sprzątanie",
                            PriceOffer = 100,
                            UserId = 5,
                            offerType = 0
                        },
                        new
                        {
                            Id = 13,
                            AddressId = 1,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4215),
                            Description = "Piore dywany",
                            Name = "Pranie dywanów",
                            PriceOffer = 100,
                            UserId = 5,
                            offerType = 2
                        },
                        new
                        {
                            Id = 14,
                            AddressId = 2,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4260),
                            Description = "wyprawne dywany i juz nie masz alergii",
                            Name = "Pranie dywanów",
                            PriceOffer = 100,
                            UserId = 6,
                            offerType = 2
                        },
                        new
                        {
                            Id = 15,
                            AddressId = 3,
                            CreatedDate = new DateTime(2023, 3, 21, 11, 49, 58, 837, DateTimeKind.Local).AddTicks(4305),
                            Description = "Profesjonalne pranie dywanów",
                            Name = "Pranie dywanów",
                            PriceOffer = 100,
                            UserId = 4,
                            offerType = 2
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
                            Email = "jankowalski@com",
                            Name = "Jan Kowalski",
                            PasswordHash = "#1234#",
                            PhoneNumber = "123456",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 2,
                            Email = "agakruk@wp.pl",
                            Name = "Aga Kruk",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 3
                        },
                        new
                        {
                            Id = 3,
                            Email = "monikal@wp.pl",
                            Name = "Monika L",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 4,
                            Email = "olgaz@wp.pl",
                            Name = "Olga Z",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 5,
                            Email = "krzysiekk@wp.pl",
                            Name = "Krzysiek k",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 2
                        },
                        new
                        {
                            Id = 6,
                            Email = "łukaszszus@wp.pl",
                            Name = "Łukasz szus",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 2
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
                            Id = 7,
                            Email = "janian@com",
                            Name = "Janian",
                            PasswordHash = "#1234#",
                            PhoneNumber = "123456",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 8,
                            Email = "zosia@wp.pl",
                            Name = "Zosia",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 9,
                            Email = "gosia@wp.pl",
                            Name = "Gosia",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 10,
                            Email = "mietek@wp.pl",
                            Name = "Mietek",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 11,
                            Email = "filip@wp.pl",
                            Name = "Filip Sz",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 1
                        },
                        new
                        {
                            Id = 12,
                            Email = "andrzej@wp.pl",
                            Name = "Andrzej",
                            PasswordHash = "#$%%^^&&",
                            PhoneNumber = "444555333",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.Event", b =>
                {
                    b.HasOne("HH2.Entities.Offerent", "Offerent")
                        .WithMany("Events")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Offerent");
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
                        .WithOne("Offer")
                        .HasForeignKey("HH2.Entities.Offer", "AddressId")
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

            modelBuilder.Entity("HH2.Entities.Address", b =>
                {
                    b.Navigation("Offer")
                        .IsRequired();
                });

            modelBuilder.Entity("HH2.Entities.User", b =>
                {
                    b.Navigation("Offers");
                });

            modelBuilder.Entity("HH2.Entities.Offerent", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("BlockedSeekers");

                    b.Navigation("Events");
                });
#pragma warning restore 612, 618
        }
    }
}
