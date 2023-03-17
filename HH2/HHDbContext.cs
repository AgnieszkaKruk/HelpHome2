using Domain.Entities;
using HH2.Entities;
using HH2.Utils;
using Microsoft.EntityFrameworkCore;

namespace HH2
{
    public class HHDbContext : DbContext
    {
        public HHDbContext(DbContextOptions<HHDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Offer> Offers { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>(eb =>
            {
                eb.HasData(new Role
                {
                    Id = 1,
                    Name = "Seeker"
                }, new Role
                {
                    Id = 2,
                    Name = "Offerent"
                }, new Role
                {
                    Id = 3,
                    Name = "Administrator"
                }
                );
            });


            modelBuilder.Entity<User>()
        .HasMany(u => u.Offers)
        .WithOne(o => o.User)
        .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Seeker>(eb =>
                {
                    eb.Property(u => u.Name).HasMaxLength(25).IsRequired();
                    eb.Property(u => u.Email).IsRequired();

                });
            modelBuilder.Entity<Offerent>()
       .HasMany(u => u.Events)
       .WithOne(o => o.Offerent)
       .HasForeignKey(o => o.UserId);

            modelBuilder.Entity<Seeker>(eb =>
                {
                    eb.Property(u => u.Name).HasMaxLength(25).IsRequired();
                    eb.Property(u => u.Email).IsRequired();

                });

            modelBuilder.Entity<Offerent>(eb =>
            {
                eb.Property(u => u.Name).HasMaxLength(25).IsRequired();
                eb.Property(u => u.Email).IsRequired();

            });

            modelBuilder.Entity<Role>(eb =>
            {
                eb.Property(u => u.Name).IsRequired();

            });



            modelBuilder.Entity<Offerent>()
                .HasData(
                new Offerent
                {
                    Name = "Jan Kowalski",
                    Id = 1,
                    Email = "jankowalski@com",
                    PhoneNumber = "123456",
                    PasswordHash = "#1234#",
                    RoleId = 2
                }, new Offerent
                {
                    Name = "Aga Kruk",
                    Id = 2,
                    Email = "agakruk@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 3
                }, new Offerent
                {
                    Name = "Monika L",
                    Id = 3,
                    Email = "monikal@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 2
                }, new Offerent
                {
                    Name = "Olga Z",
                    Id = 4,
                    Email = "olgaz@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 2
                }, new Offerent
                {
                    Name = "Krzysiek k",
                    Id = 5,
                    Email = "krzysiekk@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 2
                }, new Offerent
                {
                    Name = "£ukasz szus",
                    Id = 6,
                    Email = "³ukaszszus@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 2
                }
                );

            modelBuilder.Entity<Seeker>()
                .HasData(
                new Seeker
                {
                    Name = "Janian",
                    Id = 7,
                    Email = "janian@com",
                    PhoneNumber = "123456",
                    PasswordHash = "#1234#",
                    RoleId = 1
                }, new Seeker
                {
                    Name = "Zosia",
                    Id = 8,
                    Email = "zosia@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 1
                }, new Seeker
                {
                    Name = "Gosia",
                    Id = 9,
                    Email = "gosia@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 1
                }, new Seeker
                {
                    Name = "Mietek",
                    Id = 10,
                    Email = "mietek@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 1
                }, new Seeker
                {
                    Name = "Filip Sz",
                    Id = 11,
                    Email = "filip@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 1
                }, new Seeker
                {
                    Name = "Andrzej",
                    Id = 12,
                    Email = "andrzej@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 1
                }
                );


            modelBuilder.Entity<Address>()
                .HasData(new Address()
                {
                    Id = 1,
                    City = "Orzesze",
                    Street = "Dworcowa",
                    PostalCode = "43-190"
                });
            modelBuilder.Entity<Address>()
               .HasData(new Address()
               {
                   Id = 2,
                   City = "Miko³ów",
                   Street = "Majowa 5",
                   PostalCode = "43-190"
               });
            modelBuilder.Entity<Address>()
               .HasData(new Address()
               {
                   Id = 3,
                   City = "Katowice",
                   Street = "Kopernika 34",
                   PostalCode = "43-190"
               });
            modelBuilder.Entity<Address>()
               .HasData(new Address()
               {
                   Id = 4,
                   City = "Katowice",
                   Street = "G³ogowa 8",
                   PostalCode = "43-190"
               });
            modelBuilder.Entity<Address>()
               .HasData(new Address()
               {
                   Id = 5,
                   City = "Wroc³aw",
                   Street = "G³ówna 10",
                   PostalCode = "13-190"
               });
            modelBuilder.Entity<Address>()
               .HasData(new Address()
               {
                   Id = 6,
                   City = "Kraków",
                   Street = "Moja 14",
                   PostalCode = "43-190"
               });
            modelBuilder.Entity<Address>()
               .HasData(new Address()
               {
                   Id = 7,
                   City = "Katowice",
                   Street = "Zielona 5",
                   PostalCode = "43-190"
               });

            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 1,
                       Name = "Sprz¹tanie",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 1,
                       offerType = Domain.Utils.OfferType.Sprz¹tanie,
                       Description = "Oferujê us³ugi spz¹tania mieszkañ we Wroc³awiu",
                       AddressId = 1,


                   });
            
          
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 2,
                       Name = "Sprz¹tanie",
                       PriceOffer = 150,
                       CreatedDate = DateTime.Now,
                       UserId = 1,
                       offerType = Domain.Utils.OfferType.Sprz¹tanie,
                       Description = "Oferujê us³ugi spz¹tania najlepiej i najtaniej",
                       AddressId = 2,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 3,
                       Name = "Sprz¹tanie",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 1,
                       offerType = Domain.Utils.OfferType.Sprz¹tanie,
                       Description = "Posprz¹tam u Ciebie!",
                       AddressId = 3,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 4,
                       Name = "Mycie okien",
                       PriceOffer = 800,
                       CreatedDate = DateTime.Now,
                       UserId = 1,
                       offerType = Domain.Utils.OfferType.MycieOkien,
                       Description = "Oferujê us³ugi myycia okien",
                       AddressId = 4,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 5,
                       Name = "Mycie okien",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 2,
                       offerType = Domain.Utils.OfferType.MycieOkien,
                       Description = "Myje okna az sie b³yszcz¹",
                       AddressId = 5,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 6,
                       Name = "Mycie okien",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 2,
                       offerType = Domain.Utils.OfferType.MycieOkien,
                       Description = "Najtaniej, najelpiej i najszybciej umyje Ci okna",
                       AddressId = 6,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 7,
                       Name = "Mycie okien",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 2,
                       offerType = Domain.Utils.OfferType.MycieOkien,
                       Description = "Oferujê us³ugi mycia okien na b³ysk!",
                       AddressId = 1,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 8,
                       Name = "Sprz¹tanie",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 3,
                       offerType = Domain.Utils.OfferType.Sprz¹tanie,
                       Description = "Oferujê us³ugi spz¹tania biur w Twoim miescie",
                       AddressId = 2,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 9,
                       Name = "Sprz¹tanie",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 4,
                       offerType = Domain.Utils.OfferType.Sprz¹tanie,
                       Description = "SPRZATANIE NA JUZ",
                       AddressId = 3,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 10,
                       Name = "Sprz¹tanie",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 5,
                       offerType = Domain.Utils.OfferType.Sprz¹tanie,
                       Description = "SPRZATANIE NA JUZ",
                       AddressId = 4,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 11,
                       Name = "Sprz¹tanie",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 6,
                       offerType = Domain.Utils.OfferType.Sprz¹tanie,
                       Description = "sprzatam jutro",
                       AddressId = 5,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 12,
                       Name = "Sprz¹tanie",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 5,
                       offerType = Domain.Utils.OfferType.Sprz¹tanie,
                       Description = "SPRZATANIE teraz",
                       AddressId = 6,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 13,
                       Name = "Pranie dywanów",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 5,
                       offerType = Domain.Utils.OfferType.PranieDywanów,
                       Description = "Piore dywany",
                       AddressId = 1,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 14,
                       Name = "Pranie dywanów",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 6,
                       offerType = Domain.Utils.OfferType.PranieDywanów,
                       Description = "wyprawne dywany i juz nie masz alergii",
                       AddressId = 2,


                   });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 15,
                       Name = "Pranie dywanów",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 4,
                       offerType = Domain.Utils.OfferType.PranieDywanów,
                       Description = "Profesjonalne pranie dywanów",
                       AddressId = 3,


                   });



        }
    }

}


