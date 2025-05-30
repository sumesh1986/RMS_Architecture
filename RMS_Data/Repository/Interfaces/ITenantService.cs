using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using RMS_Data.Data;
using RMS_Models.Models.ServiceModels;

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
        private readonly string _server;
        private readonly string _user;
        private readonly string _pswd;
        private readonly OtherService _os;

        public TenantService(IHttpContextAccessor httpContextAccessor, IOptions<UserDBSettings> settings, OtherService os)
        {
            _httpContextAccessor = httpContextAccessor;
            _server = settings.Value.server;
            _user = settings.Value.user;
            _pswd = settings.Value.password;
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

            return $"Server={_server};Database={dbName};User Id={_user};Password={_pswd};TrustServerCertificate=True;MultipleActiveResultSets=true;";

        }
    }


}
