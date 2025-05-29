using Microsoft.EntityFrameworkCore;
using RMS_Models.Models.ServiceModels;

namespace RMS_Data.Data
{
    public class OtherService : DbContext
    {

        public OtherService(DbContextOptions<OtherService> options): base(options)
        {
        }

        public DbSet<UserMaster> UserMaster { get; set; }
        public DbSet<Registration> Registration { get; set; }
        public DbSet<DatabaseMapping> DBMapper { get; set; }

        public DbSet<UserMetadata> UserMetadata { get; set; }
    }
}
