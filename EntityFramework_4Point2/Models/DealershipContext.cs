using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework_4Point2.Models
{
    class DealershipContext : DbContext
    {

        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connection =
                    "server=localhost;" +
                    "port=3306;" +
                    "user=root;" +
                    "database=codefirst_4point2;";

                string version = "10.4.14-MariaDB";

                optionsBuilder.UseMySql(connection, x => x.ServerVersion(version));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.Property(e => e.Name)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                entity.HasData(
                    new Manufacturer()
                    {
                        ID = -1,
                        Name = "Ford"
                    },
                    new Manufacturer()
                    {
                        ID = -2,
                        Name = "Chevrolet"
                    },
                    new Manufacturer()
                    {
                        ID = -3,
                        Name = "Dodge"
                    }
                );
            });
            modelBuilder.Entity<Vehicle>(entity =>
            {
                string keyName = "FK_" + nameof(Vehicle) +
                    "_" + nameof(Manufacturer);

                // These SHOULD be set automatically. If you want to play around with it by removing these and verify this version of EF works that way, feel free. 
                entity.Property(e => e.Model)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                entity.Property(e => e.Colour)
                .HasCharSet("utf8mb4")
                .HasCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.ManufacturerID)
                .HasName(keyName);

                entity.HasOne(thisEntity => thisEntity.Manufacturer)
                .WithMany(parent => parent.Vehicles)
                .HasForeignKey(thisEntity => thisEntity.ManufacturerID)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName(keyName);

                // In-class Practice 2:
                // Add seed data for 5 vehicles similarly to the manufacturers above.
            });
        }
    }
}
