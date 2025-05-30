using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RMS_Data.Data;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models;
using RMS_Models.Models.API_Models.Company;
using RMS_Models.Models.DTO.Company;
using RMS_Models.Models.ServiceModels;

namespace RMS_Data.Service.Company
{
    public class CompanyRegistrationRepository : ICompanyRegistrationRepository
    {
        private readonly OtherService _os;
        public CompanyRegistrationRepository(OtherService os)
        {
            _os = os;
        }

        public async Task<Registration> GetAsync(string id)
        {
            var user = await _os.Registration.FirstOrDefaultAsync(u => u.token == id);

            if (user == null)
                throw new Exception("Company not found.");

            var newUser = new Registration
            {
                CompanyName = user.CompanyName,
                OwnerName= user.OwnerName,
                FamilyName = user.FamilyName,
                Place = user.Place,
                Country = user.Country,
                Phone = user.Phone,
                Email = user.Email,
                HeadOffice = user.HeadOffice,
                RegistrationNumber = user.RegistrationNumber,
                Address = user.Address,
                ProductId = user.ProductId
            };
            return newUser;
        }


        public async Task<Registration?> GetByRegNumberAsync(string? token)
        {
            return await _os.Registration.FirstOrDefaultAsync(c => c.token == token);
        }



        public async Task<Registration> UpdateAsync(Registration company)
        {
            var existing = await _os.Registration
                .FirstOrDefaultAsync(x => x.token == company.token);


            if (existing == null)
                return null;

            await _os.SaveChangesAsync();
            await _os.Entry(existing).ReloadAsync();

            return existing;
        }



    }
}
