using Session2_EntityFrameworkCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Session2_EntityFrameworkCore.Configurations
{
    internal class OrganizerProfileConfiguration : IEntityTypeConfiguration<OrganizerProfile>
    {
        public void Configure(EntityTypeBuilder<OrganizerProfile> builder)
        {
            builder.Property(p => p.Biography).HasMaxLength(500);

            builder.Property(p => p.Website).HasMaxLength(100);

            builder.Property(p => p.Logo).HasMaxLength(300);


            builder.HasOne(p => p.Organizer)
                   .WithOne(o => o.Profile)
                   .HasForeignKey<OrganizerProfile>(p => p.OrganizerId);
        }
    }
}
