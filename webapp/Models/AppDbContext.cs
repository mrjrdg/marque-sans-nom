﻿using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<Addresse> Addresses { get; set; }
        public DbSet<EventType> EventTypes { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EventApplicationUser e = new EventApplicationUser();
            
            modelBuilder.Entity<EventApplicationUser>()
                .HasKey(t => new { t.ApplicationUserId, t.EventId });

            modelBuilder.Entity<EventApplicationUser>()
                .HasOne( e => e.ApplicationUser)
                .WithMany(e => e.EventsParticipation)
                .HasForeignKey(e => e.ApplicationUserId);

            modelBuilder.Entity<EventApplicationUser>()
                .HasOne(e => e.Event)
                .WithMany(e => e.Members)
                .HasForeignKey(e => e.EventId);
        }
    }
}
