using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RMS_BAL.Middleware;
using RMS_BAL.Repository.Interfaces;
using RMS_BAL.Services.Company;
using RMS_BAL.Services.Customer;
using RMS_BAL.Services.Dropdown;
using RMS_BAL.Services.ExceptionHandlingService;
using RMS_BAL.Services.Interfaces;
using RMS_BAL.Services.ProductSetup.SalesItemHierarchy;
using RMS_BAL.Services.Users;
using RMS_Data.Data;
using RMS_Data.Repository.Customer;
using RMS_Data.Repository.Dropdown;
using RMS_Data.Repository.ExcpetionHandling;
using RMS_Data.Repository.Interfaces;
using RMS_Data.Repository.ProductSetup.SalesItemHierarchy;
using RMS_Data.Repository.User;
using RMS_Data.Service.Company;
using RMS_Data.Service.Interfaces;
using RMS_Models.Models.ServiceModels;

var builder = WebApplication.CreateBuilder(args);

// ====== Configuration Bindings ======
builder.Services.Configure<EncryptionSettings>(builder.Configuration.GetSection("EncryptionSettings"));
builder.Services.Configure<UserDBSettings>(builder.Configuration.GetSection("UserDBSettings"));

// ====== HTTP Context ======
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

// ====== Register OtherService (Main DB for DBMapper) ======
builder.Services.AddDbContext<OtherService>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("con")));

// ====== Register Tenant Service ======
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<IMetadataService, MetadataService>();
builder.Services.AddScoped<IMetadataRepository, MetadataRepository>();

// ====== Dynamic Tenant-Based DbContext ======
builder.Services.AddDbContext<ApplicationDbContext>((serviceProvider, options) =>
{
    var tenantService = serviceProvider.GetRequiredService<ITenantService>();
    var tenantId = tenantService.GetCurrentTenantId();

    if (string.IsNullOrEmpty(tenantId))
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("con"));
    }
    else
    {
        var connectionString = tenantService.GetConnectionStringForTenant(tenantId);
        options.UseSqlServer(connectionString);
    }
});

// ====== Repository and Service Registrations ======
//Company
builder.Services.AddScoped<ICompanyRegistrationRepository, CompanyRegistrationRepository>();
builder.Services.AddScoped<ICompanyRegistrationService, CompanyRegistrationService>();


// Product
builder.Services.AddScoped<I_ItemGroupRepository, ItemGroupRepository>();
builder.Services.AddScoped<I_ItemGroupService, ItemGroupService>();

builder.Services.AddScoped<IDivisionRepository, DivisionProductSalesRepository>();
builder.Services.AddScoped<IDivisionService, DivisionService>();

builder.Services.AddScoped<IProductSetupCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductSetupCategoryService, ProductSetupCategoryServices>();

// Dropdown
builder.Services.AddScoped<IDropdownCommonRepository, DropdownRepository>();
builder.Services.AddScoped<IDropdownCommonServices, DropdownService>();

// Customer
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerGroupRepository, CustomerGroupRepository>();
builder.Services.AddScoped<ICustomerGroupService, CustomerGroupService>();
builder.Services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
builder.Services.AddScoped<ICustomerTypeService, CustomerTypeService>();
builder.Services.AddScoped<ICustomerTitleRepository, CustomerTitleRepository>();
builder.Services.AddScoped<ICustomerTitleService, CustomerTitleService>();

// User/Department
builder.Services.AddScoped<IUserPositionsRepository, UserPositionsRepository>();
builder.Services.AddScoped<IUserPositionsService, UserPositionsService>();
builder.Services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
builder.Services.AddScoped<IDepartmentsService, DepartmentService>();
builder.Services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
builder.Services.AddScoped<IUserPermissionService, UserPermissionService>();

// Exception Handling
builder.Services.AddScoped<IExceptionHandlingService, ExceptionHandlingService>();
builder.Services.AddScoped<IExcepetionHandlingRepository, ExcepetionHandlingRepository>();

// === Authentication
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Home/Login";
        options.AccessDeniedPath = "/Home/AccessDenied";
        options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
    });

// ====== MVC and JSON Configuration ======
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });
builder.Services.AddControllersWithViews();

// ====== Swagger ======
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RMS API", Version = "v1" });
});

// ====== Build and Configure App Pipeline ======
var app = builder.Build();

// ====== Middleware Pipeline ======
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RMS API v1"));
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-store, no-cache, must-revalidate, max-age=0";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "-1";
    await next();
});


app.UseSession();

app.UseAuthentication();
app.UseAuthorization();
builder.Services.AddMemoryCache();
app.UseMiddleware<TenantValidationMiddleware>();

app.MapControllers();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();