using Microsoft.EntityFrameworkCore;
using RMS_Models.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using RMS_Models.Models.ServiceModels;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.API_Models.ProductSetup.SalesItemHierarchy;

namespace RMS_Data.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options)  {  }

        //Application Models...
        public DbSet<CustomerGroup> CustomerGroups { get; set; }

        public DbSet<CompanyConcept> concept { get; set; }


        public DbSet<CategoryViewModel> Category { get; set; }

        public DbSet<DivisionViewModel> Division { get; set; }

        public DbSet<ItemGroupViewModel> ItemGroup { get; set; }

        //Service Models...
        public DbSet<ErrorLog>  ErrorLogs{ get; set; }



    }
}

