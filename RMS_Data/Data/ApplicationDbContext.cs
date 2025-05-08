using Microsoft.EntityFrameworkCore;
using RMS_Models.Models;
using Microsoft.Extensions.Configuration;
using System.IO;
using System;
using RMS_Models.Models.ServiceModels;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.API_Models.Company;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace RMS_Data.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)  : base(options)  {  }

        //Application Models...
        //public DbSet<CustomerGroup> CustomerGroups { get; set; }

        public DbSet<CustomerGroup> CustomerGroup { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<CompanyConcept> CompanyConcepts { get; set; }

        public DbSet<CustomerTitle> CustomerTitles { get; set; }
        public DbSet<CustomerPrice>PriceGroupMaster { get; set; }

        public DbSet<CustomerDiscountTB> DiscountTB { get; set; }

        //public DbSet<CustomerViewModel> CustomerTitles { get; set; }
        //public DbSet<CustomerViewModel> CustomerTitles { get; set; }

        //Service Models...
        public DbSet<ErrorLog>  ErrorLogs{ get; set; }
        //public IEnumerable<object> CustomerTypes { get; internal set; }
    }
}

