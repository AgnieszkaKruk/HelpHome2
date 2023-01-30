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
                    Email = "jdsks@com",
                    PhoneNumber = "123456",
                    PasswordHash = "#1234#",
                    RoleId = 2
                }, new Offerent
                {
                    Name = "Aga Kruk",
                    Id = 2,
                    Email = "agak@wp.pl",
                    PhoneNumber = "444555333",
                    PasswordHash = "#$%%^^&&",
                    RoleId = 3
                }
                );
            modelBuilder.Entity<Seeker>()
                .HasData(
                new Seeker
                {
                    Name = "Janian",
                    Id = 3,
                    Email = "jdsks@com",
                    PhoneNumber = "123456",
                    PasswordHash = "#1234#",
                    RoleId = 1
                }, new Seeker
                {
                    Name = "Zsoia",
                    Id = 4,
                    Email = "agak@wp.pl",
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
                   City = "Miko��w",
                   Street = "Majowa",
                   PostalCode = "43-190"
               });
            modelBuilder.Entity<Address>()
               .HasData(new Address()
               {
                   Id = 3,
                   City = "Katowice",
                   Street = "G�ogowa",
                   PostalCode = "43-190"
               });
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 1,
                       Name = "Sprz�tanie",
                       PriceOffer = 100,
                       CreatedDate = DateTime.Now,
                       UserId = 1,
                       offerType = Domain.Utils.OfferType.Sprz�tanie,
                       Description = "Oferuj� us�ugi spz�tania mieszka� we Wroc�awiu",
                       AddressId = 1,


                   });
            ;
            ;
            modelBuilder.Entity<Offer>()
                   .HasData(new Offer()
                   {
                       Id = 2,
                       Name = "Sprz�tanie",
                       PriceOffer = 150,
                       CreatedDate = DateTime.Now,
                       UserId = 1,
                       offerType = Domain.Utils.OfferType.Sprz�tanie,
                       Description = "Oferuj� us�ugi spz�tania biur we Wroc�awiu",
                       AddressId = 2,


                   });




        }
    }

}


