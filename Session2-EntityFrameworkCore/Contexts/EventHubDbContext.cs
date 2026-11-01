using Microsoft.EntityFrameworkCore;
using Session2_EntityFrameworkCore.Configurations;
using Session2_EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session2_EntityFrameworkCore.Contexts
{
    internal class EventHubDbContext : DbContext
    {
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<OrganizerProfile> OrganizerProfiles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Badge> Badges { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=EventHubDB;Trusted_Connection=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrganizerProfileConfiguration());

            modelBuilder.ApplyConfiguration(new EventConfiguration());



            modelBuilder.Entity<Badge>(builder =>
            {
                builder.Property(b => b.BadgeNumber).HasMaxLength(100).IsRequired();

                builder.Property(b => b.IssuedDate).IsRequired();

                builder.Property(b => b.Tier).IsRequired();



                builder.HasOne(b => b.Attendee)
                       .WithOne(a => a.Badge)
                       .HasForeignKey<Badge>(b => b.AttendeeId);
            });
        }
        }
}
