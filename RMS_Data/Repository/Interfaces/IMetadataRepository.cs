using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Data.Data;
using RMS_Models.Models.ServiceModels;

namespace RMS_Data.Repository.Interfaces
{
    public interface IMetadataRepository
    {
        Task InsertAsync(UserMetadata entity);
    }

    public class MetadataRepository : IMetadataRepository
    {
        private readonly OtherService _db;

        public MetadataRepository(OtherService db)
        {
            _db = db;
        }

        public async Task InsertAsync(UserMetadata entity)
        {
            _db.UserMetadata.Add(entity);
            await _db.SaveChangesAsync();
        }
    }

}
