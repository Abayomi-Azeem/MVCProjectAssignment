using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCProjectAssignment.Models.DB_Model
{
    public partial class owodaInfo : DbContext
    {
        public owodaInfo()
            : base("name=owodaInfo1")
        {
        }

        public virtual DbSet<NURTWMember> NURTWMembers { get; set; }
        public virtual DbSet<NURTWVehicle> NURTWVehicles { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NURTWMember>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<NURTWMember>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<NURTWMember>()
                .HasMany(e => e.NURTWVehicles)
                .WithRequired(e => e.NURTWMember)
                .HasForeignKey(e => e.OwnerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NURTWMember>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.NURTWMember)
                .HasForeignKey(e => e.MemberId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NURTWVehicle>()
                .Property(e => e.VehicleMake)
                .IsUnicode(false);

            modelBuilder.Entity<NURTWVehicle>()
                .Property(e => e.VehicleModel)
                .IsUnicode(false);

            modelBuilder.Entity<NURTWVehicle>()
                .Property(e => e.VehicleStatus)
                .IsUnicode(false);
        }
    }
}
