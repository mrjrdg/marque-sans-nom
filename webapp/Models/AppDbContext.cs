using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Models
{

    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // !@#$%^&* MET LE NOM DE TES ENTITES AU PLURIEL ICI !@#$%^&*  //

        public DbSet<Entreprise> Entreprise { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventApplicationUser> EventApplicationUsers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            PasswordHasher<ApplicationUser> hasher = new PasswordHasher<ApplicationUser>();

            Dictionary<string, string> roleIds = new Dictionary<string, string>() {
                { "Admin", Guid.NewGuid ().ToString () },
                { "CustomerPeople", Guid.NewGuid ().ToString () },
                { "CustomerBusiness", Guid.NewGuid ().ToString () },
            };

            Dictionary<string, string> userIds = new Dictionary<string, string>() { { "jordangauthier@noname.com", Guid.NewGuid ().ToString () }, { "alexdufour@noname.com", Guid.NewGuid ().ToString () }, { "philippesoucy@noname.com", Guid.NewGuid ().ToString () }, { "alexhamel@noname.com", Guid.NewGuid ().ToString () },
            };

            var passwordHash = hasher.HashPassword(null, "admin123");

            base.OnModelCreating(modelBuilder);

            // SET UP MANY-TO-MAY RELATIONSHIP BETWEEN EVENT AND APPLICATION USER //

            modelBuilder.Entity<EventApplicationUser>()
                .HasKey(e => new { e.ApplicationUserId, e.EventId });

            modelBuilder.Entity<EventApplicationUser>()
                .HasOne(e => e.ApplicationUser)
                .WithMany(e => e.EventsParticipation)
                .HasForeignKey(e => e.ApplicationUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<EventApplicationUser>()
                .HasOne(e => e.Event)
                .WithMany(e => e.Members)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.Restrict);

            // SET UP ONE-TO-MANY RELATIONSHIP BETWEEN EVENT AND ENTREPRISE //

            modelBuilder.Entity<Event>()
                  .HasOne(e => e.Entreprise)
                  .WithMany(e => e.Events)
                  .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Event>()
              .HasOne(e => e.Address);

            modelBuilder.Entity<Entreprise>()
                .HasOne(e => e.Address);

            modelBuilder.Entity<IdentityRole>().HasData(
              new IdentityRole
              {
                  Id = roleIds["Admin"],
                  Name = "Admin",
                  NormalizedName = "ADMIN"
              },
              new IdentityRole
              {
                  Id = roleIds["CustomerPeople"],
                  Name = "CustomerPeople",
                  NormalizedName = "CUSTOMERPEOPLE"
              },
              new IdentityRole
              {
                  Id = roleIds["CustomerBusiness"],
                  Name = "CustomerBusiness",
                  NormalizedName = "CUSTOMERBUSINESS"
              }
          );

            var jordan = new ApplicationUser
            {
                Id = userIds["jordangauthier@noname.com"],
                UserName = "jordangauthier@noname.com",
                Email = "jordangauthier@noname.com",
                FirstName = "Jordan",
                LastName = "Gauthier",
                NormalizedUserName = "JORDANGAUTHIER@NONAME.COM",
                NormalizedEmail = "JORDANGAUTHIER@NONAME.COM",
                PhoneNumber = "514-979-7316",
                PhoneNumberConfirmed = true,
                PasswordHash = passwordHash
            };


            // SEEDING APPLICATION USERS //

            modelBuilder.Entity<ApplicationUser>().HasData(
                jordan,
                new ApplicationUser
                {
                    Id = userIds["alexdufour@noname.com"],
                    UserName = "alexdufour@noname.com",
                    Email = "alexdufour@noname.com",
                    FirstName = "Alex",
                    LastName = "Dufour",
                    NormalizedUserName = "ALEXDUFOUR@NONAME.COM",
                    NormalizedEmail = "ALEXDUFOUR@NONAME.COM",
                    PhoneNumber = "514-911-9111",
                    PhoneNumberConfirmed = false,
                    PasswordHash = passwordHash
                },
                new ApplicationUser
                {
                    Id = userIds["alexhamel@noname.com"],
                    UserName = "alexhamel@noname.com",
                    Email = "alexhamel@noname.com",
                    FirstName = "Alexandre",
                    LastName = "Hamel-Boudreault",
                    NormalizedUserName = "alexhamel@noname.com",
                    NormalizedEmail = "alexhamel@noname.com",
                    PasswordHash = passwordHash
                },
                new ApplicationUser
                {
                    Id = userIds["philippesoucy@noname.com"],
                    UserName = "philippesoucy@noname.com",
                    Email = "philippesoucy@noname.com",
                    FirstName = "Philippe",
                    LastName = "Soucy",
                    NormalizedUserName = "PHILIPPESOUCY@NONAME.COM",
                    NormalizedEmail = "PHILIPPESOUCY@NONAME.COM",
                    PasswordHash = passwordHash
                }
            );

            // SEEDING APPLICATION USERS ROLES //

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = roleIds["Admin"],
                    UserId = userIds["jordangauthier@noname.com"]
                },
                new IdentityUserRole<string>
                {
                    RoleId = roleIds["Admin"],
                    UserId = userIds["alexdufour@noname.com"]
                },
                new IdentityUserRole<string>
                {
                    RoleId = roleIds["Admin"],
                    UserId = userIds["alexhamel@noname.com"]
                },
                new IdentityUserRole<string>
                {
                    RoleId = roleIds["Admin"],
                    UserId = userIds["philippesoucy@noname.com"]
                }
            );

            // SEEDING ADDRESS //


            modelBuilder.Entity<Address>().HasData(
                new Address
                {
                    Id = 1,
                    Street = "Des jacinthes",
                    PostalCode = "J6X 0A5",
                    State = "QC",
                    Country = "Canada",
                    CivicNumber = 2502,
                    City = "Terrebonne"
                },
                new Address
                {
                    Id = 2,
                    Street = "Boulevard PIE-IX",
                    PostalCode = "H1V 2E6",
                    State = "QC",
                    Country = "Canada",
                    CivicNumber = 2265,
                    City = "Montreal",
                    AppartmentNumber = 2
                },
                new Address
                {
                    Id = 3,
                    Street = "Hochelaga",
                    PostalCode = "H1V 3N8",
                    State = "QC",
                    Country = "Canada",
                    CivicNumber = 4500,
                    City = "Montreal"
                }
            );

            // SEEDIND ENTREPRISE //

            modelBuilder.Entity<Entreprise>().HasData(
                new 
                {
                    Id = 1,
                    EntrepriseName = "Pro gym",
                    EntreprisePhone = "(514) 252-8704",
                    AddressId = 3
                },
                new 
                { 
                    Id = 2,
                    EntrepriseName = "Groupe tazor",
                    EntreprisePhone = "(514) 911-9111",
                    AddressId = 1
                }
            );

            // SEEDING EVENTTYPE //

            modelBuilder.Entity<EventType>().HasData(
                 new EventType
                 {
                     Id = 1,
                     Title = "Entrainement"
                 },
                 new EventType
                 {
                     Id = 2,
                     Title = "Lever de fond"
                 }
            );

            // SEEDING EVENT //

            modelBuilder.Entity<Event>().HasData(
                new
                {
                    Id = 1,
                    AddressId = 3,
                    EntrepriseId = 1,
                    ApplicationUserId = userIds["jordangauthier@noname.com"],
                    StartDate = new DateTime(2020, 02, 25, 13, 30, 0),
                    EndDate = new DateTime(2020, 02, 25, 18, 30, 0),
                    PriceToPayToParticipate = 50.0,
                    Title = "Zumba de dufour",
                    EventTypeId = 1,
                },
                new
                {
                    Id = 2,
                    AddressId = 2,
                    EntrepriseId = 2,
                    ApplicationUserId = userIds["alexdufour@noname.com"],
                    StartDate = new DateTime(2020, 02, 25, 13, 30, 0),
                    EndDate = new DateTime(2020, 02, 25, 18, 30, 0),
                    PriceToPayToParticipate = 50.0,
                    Title = "Souper spaghetti de dufour (Lever de fond)",
                    EventTypeId = 1,
                }
            );

            // SEEDING EVENT APPLICATION USER //

            modelBuilder.Entity<EventApplicationUser>().HasData(
                new EventApplicationUser 
                {
                    ApplicationUserId = userIds["jordangauthier@noname.com"],
                    EventId = 1
                },
                new EventApplicationUser
                {
                    ApplicationUserId = userIds["alexdufour@noname.com"],
                    EventId = 1
                },
                new EventApplicationUser
                {
                    ApplicationUserId = userIds["jordangauthier@noname.com"],
                    EventId = 2
                },
                new EventApplicationUser
                {
                    ApplicationUserId = userIds["alexdufour@noname.com"],
                    EventId = 2
                },
                new EventApplicationUser
                {
                    ApplicationUserId = userIds["philippesoucy@noname.com"],
                    EventId = 2
                },
                new EventApplicationUser
                {
                    ApplicationUserId = userIds["alexhamel@noname.com"],
                    EventId = 2
                }
            );
           
        }
    }
}