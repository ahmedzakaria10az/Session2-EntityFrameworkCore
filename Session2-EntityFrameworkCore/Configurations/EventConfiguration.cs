using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Session2_EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session2_EntityFrameworkCore.Configurations
{
    internal class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Title).HasMaxLength(300).IsRequired();

            builder.Property(e => e.Description).IsRequired();

            builder.Property(e => e.StartDate).IsRequired();

            builder.Property(e => e.MaxAttendees).IsRequired();


            builder.HasOne(e => e.Organizer)
                   .WithMany(o => o.Events)
                   .HasForeignKey(e => e.OrganizerId);
        }
    }
}
