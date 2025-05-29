using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.ServiceModels;

namespace RMS_BAL.Services.Interfaces
{
    public interface IMetadataService
    {
        Task SaveMetadataAsync(UserMetadataDto dto);
    }

    public class MetadataService : IMetadataService
    {
        private readonly IMetadataRepository _repo;
        public MetadataService(IMetadataRepository repo)
        {
            _repo = repo;
        }

        public async Task SaveMetadataAsync(UserMetadataDto metadata)
        {
            var entity = new UserMetadata
            {
                Ip = metadata.Ip,
                City = metadata.City,
                Region = metadata.Region,
                CountryName = metadata.CountryName,
                Latitude = metadata.Latitude,
                Longitude = metadata.Longitude,
                Timezone = metadata.Timezone,
                Platform = metadata.Platform,
                Language = metadata.Language,
                Browser = metadata.Browser,
                VisitorId = metadata.VisitorId,
                ScreenResolution = metadata.ScreenResolution,
                LocalStorage = metadata.LocalStorage,
                SessionStorage = metadata.SessionStorage,
                Cookie = metadata.Cookie,
                DeviceType = metadata.DeviceType,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.InsertAsync(entity);
        }
    }

}
