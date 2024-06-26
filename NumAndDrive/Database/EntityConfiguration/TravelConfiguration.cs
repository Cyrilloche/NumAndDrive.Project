﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NumAndDrive.Models;

namespace NumAndDrive.Database.EntityConfiguration
{
    public class TravelConfiguration : IEntityTypeConfiguration<Travel>
    {
        public void Configure(EntityTypeBuilder<Travel> builder)
        {
            builder.ToTable("travel");

            builder.HasKey(t => t.TravelId);

            builder
                .Property(t => t.DepartureTime)
                .HasColumnType("time");
            builder
                .Property(t => t.CreationDate)
                .HasColumnType("datetime");
            builder
                .Property(t => t.AvailablePlace)
                .HasColumnType("tinyint");

            builder
                .HasOne<User>(t => t.PublisherUser)
                .WithMany(u => u.PublishedTravel)
                .HasForeignKey(t => t.PublisherUserId);

            builder
                .HasOne<Address>(t => t.DepartureAddress)
                .WithMany(a => a.DepartureTravel)
                .HasForeignKey(t => t.DepartureAddressId);

            builder
                .HasOne<Address>(t => t.ArrivalAddress)
                .WithMany(a => a.ArrivalTravel)
                .HasForeignKey(t => t.ArrivalAddressId);
        }
    }
}
