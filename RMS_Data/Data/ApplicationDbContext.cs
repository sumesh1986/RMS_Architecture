using Microsoft.EntityFrameworkCore;
using RMS_Models.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using RMS_Models.Models.ServiceModels;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.API_Models.Company;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
=======
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;
using RMS_Models.Models.API_Models.Users;
>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274

namespace RMS_Data.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)  {
        }

        //Application Models...
        //public DbSet<CustomerGroup> CustomerGroups { get; set; }

<<<<<<< HEAD
        public DbSet<CustomerGroup> CustomerGroup { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<CompanyConcept> CompanyConcepts { get; set; }

        public DbSet<CustomerTitle> CustomerTitles { get; set; }

        //public DbSet<CustomerViewModel> CustomerTitles { get; set; }
=======
        public DbSet<CompanyConcept> concept { get; set; }

        public DbSet<CategoryViewModel> Category { get; set; }

        public DbSet<DivisionViewModel> Division { get; set; }

        public DbSet<ItemGroupViewModel> ItemGroup { get; set; }

        public DbSet<UserPositions> UserPositions { get; set; } = null!;
        public DbSet<RolePermission> RolePermissions { get; set; }

        public DbSet<PositionPermitted> PositionPermitted { get; set; }
>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274


        public DbSet<Departments> Department { get; set; } = null!;
        //Service Models...
        public DbSet<ErrorLog>  ErrorLogs{ get; set; }
<<<<<<< HEAD
        //public IEnumerable<object> CustomerTypes { get; internal set; }
=======

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.HasKey(e => e.ParticularID);
                entity.Property(e => e.ModuleName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.DivisionName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Particulars).IsRequired().HasMaxLength(200);
                entity.Property(e => e.IsActive).HasDefaultValue(true);
            });

            modelBuilder.Entity<UserPositions>(entity =>
            {
                entity.HasKey(e => e.SysId);
                entity.Property(e => e.UserPosition).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Active).HasDefaultValue("Active").HasMaxLength(10);
            });

            modelBuilder.Entity<PositionPermitted>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasOne<UserPositions>()
                    .WithMany()
                    .HasForeignKey(p => p.PositionID)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne<RolePermission>()
                    .WithMany()
                    .HasForeignKey(p => p.ParticularID)
                    .OnDelete(DeleteBehavior.Cascade);

                // Create unique index for position-permission combination
                entity.HasIndex(p => new { p.PositionID, p.ParticularID }).IsUnique();
            });
        }

>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274
    }
}

