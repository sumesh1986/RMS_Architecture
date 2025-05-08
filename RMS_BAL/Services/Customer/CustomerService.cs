using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.Result;
using RMS_Data.Repository.Interfaces;
using RMS_Models.Models.API_Models.Customers;
using RMS_Models.Models.DTO.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RMS_BAL.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        



        private readonly ICustomerRepository _repository;

        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<string>> GettitlesAsync()
        {
            try
            {
                return await _repository.GettitlesAsync();
            }
            catch (Exception)
            {
                return Enumerable.Empty<string>();
            }
        }

        public async Task<IEnumerable<string>> GetgroupsAsync()
        {
            try
            {
                return await _repository.GetgroupsAsync();
            }
            catch (Exception)
            {
                return Enumerable.Empty<string>();
            }
        }


        public async Task<IEnumerable<string>> GettypesAsync()
        {
            try
            {
                return await _repository.GettypesAsync();
            }
            catch (Exception)
            {
                return Enumerable.Empty<string>();
            }
        }


        public async Task<IEnumerable<int>> GetpriceAsync()
        {
            try
            {
                return await _repository.GetpriceAsync();
            }
            catch (Exception)
            {
                return Enumerable.Empty<int>();
            }
        }


        public async Task<IEnumerable<string>> GetdiscountAsync()
        {
            try
            {
                return await _repository.GetdiscountAsync();
            }
            catch (Exception)
            {
                return Enumerable.Empty<string>();
            }
        }
    }
}
