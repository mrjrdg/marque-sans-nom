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
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<EventApplicationUser>()
                .HasOne(e => e.Event)
                .WithMany(e => e.Members)
                .HasForeignKey(e => e.EventId)
                .OnDelete(DeleteBehavior.NoAction);

            // SET UP ONE-TO-MANY RELATIONSHIP BETWEEN EVENT AND ENTREPRISE //

            modelBuilder.Entity<Event>()
                  .HasOne(e => e.Entreprise)
                  .WithMany(e => e.Events)
                  .OnDelete(DeleteBehavior.NoAction);

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


            // SEEDING APPLICATION USERS //

            modelBuilder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
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
                },
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
        }
    }
}