using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Interfaces;
using RMS_Data.Service.Company;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.ServiceModels;

namespace RMS_BAL.Services.Company
{
    public class CompanyRegistrationService : ICompanyRegistrationService
    {
        private readonly ICompanyRegistrationRepository _repo;
        public CompanyRegistrationService(ICompanyRegistrationRepository repository)
        {
            _repo = repository;
        }

        public async Task<Result<RegistrationDTO>> GetAsync(string id)
        {

            if (string.IsNullOrWhiteSpace(id))
            {
                return Result<RegistrationDTO>.FailureResult("Required Id.");
            }

            var existing = await _repo.GetAsync(id);

            if(existing is null)
            {
                return Result<RegistrationDTO>.FailureResult("Company registration details does not exists.");
            }

            var user = new RegistrationDTO
            {
                CompanyName = existing.CompanyName,
                OwnerName = existing.OwnerName,
                FamilyName = existing.FamilyName,
                Place = existing.Place,
                Country = existing.Country,
                Phone = existing.Phone,
                Email = existing.Email,
                HeadOffice = existing.HeadOffice,
                RegistrationNumber = existing.RegistrationNumber,
                Address = existing.Address,
                ProductId = existing.ProductId
            };
            return Result<RegistrationDTO>.SuccessResult(user);
        }

        public async Task<Result<Registration>> UpdateAsync(RegistrationDTO reg)
        {
            var existingEntity = await _repo.GetByRegNumberAsync(reg.tenantid);

            if (existingEntity == null)
                return null;



            existingEntity.OwnerName = reg.OwnerName;
            existingEntity.FamilyName = reg.FamilyName;
            existingEntity.Address = reg.Address;
            existingEntity.Phone = reg.Phone;
            existingEntity.HeadOffice = reg.HeadOffice;

           var result =  await _repo.UpdateAsync(existingEntity);
            return Result<Registration>.SuccessResult(result);
        }


    }
}
