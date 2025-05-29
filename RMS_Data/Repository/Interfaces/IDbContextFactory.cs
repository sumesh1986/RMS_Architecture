using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;

namespace RMS_Data.Repository.Interfaces
{
    public interface IDbContextFactory
    {
        ApplicationDbContext CreateDbContext(string connectionString);
    }

    public class DbContextFactory : IDbContextFactory
    {
        public ApplicationDbContext CreateDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }

}
