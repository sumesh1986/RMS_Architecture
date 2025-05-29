using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RMS_Data.Data;

namespace RMS_Data.Repository.Interfaces
{
    public interface ITenantService
    {
        string GetCurrentTenantId();
        string GetConnectionStringForTenant(string tenantId);
    }

    public class TenantService : ITenantService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly OtherService _os;

        public TenantService(IHttpContextAccessor httpContextAccessor, OtherService os)
        {
            _httpContextAccessor = httpContextAccessor;
            _os = os;
        }

        //public string GetCurrentTenantId()
        //{
        //    return _httpContextAccessor.HttpContext.User.FindFirst("TenantId")?.Value;
        //}


        public string GetCurrentTenantId()
        {
            var context = _httpContextAccessor.HttpContext;

            if (context == null)
                return null;

            if (context.Request.Headers.TryGetValue("X-Tenant-ID", out var headerTenantId))
                return headerTenantId.ToString();

            return context.User?.FindFirst("TenantId")?.Value;
        }


        public string GetConnectionStringForTenant(string tenantId)
        {
            var tenant = _os.DBMapper.FirstOrDefault(x => x.Token == tenantId);

            if (tenant == null)
                throw new Exception("Invalid tenant ID");

            string dbName = "DB_" + tenant.RegNo;

            string server = "192.168.1.120,1433";
            string user = "BackOffice";
            string password = "admin123";

            return $"Server={server};Database={dbName};User Id={user};Password={password};TrustServerCertificate=True;MultipleActiveResultSets=true;";

        }
    }


}
