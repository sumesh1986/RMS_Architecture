using Microsoft.EntityFrameworkCore;
using RMS_Models.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using RMS_Models.Models.ServiceModels;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.Users;

namespace RMS_Data.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options)  {  }

        //Application Models...
        public DbSet<CustomerGroup> CustomerGroups { get; set; }

        public DbSet<CompanyConcept> CompanyConcepts { get; set; }

        public DbSet<UserPositions> UserPositions { get; set; } = null!;
        public DbSet<UserPermission> RolePermissions { get; set; }

        public DbSet<Departments> Department { get; set; } = null!;

        //Service Models...
        public DbSet<ErrorLog>  ErrorLogs{ get; set; }



    }
}

