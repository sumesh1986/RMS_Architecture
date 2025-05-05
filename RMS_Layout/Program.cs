using System.Text.Json.Serialization;
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
using RMS_Data.Repository.Company;
using RMS_Data.Repository.Customer;
<<<<<<< HEAD
//using RMS_Data.Repository.Dropdown;
=======
using RMS_Data.Repository.Dropdown;
>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274
using RMS_Data.Repository.ExcpetionHandling;
using RMS_Data.Repository.Interfaces;
using RMS_Data.Repository.ProductSetup.SalesItemHierarchy;
using RMS_Data.Repository.User;
using RMS_Data.Service.Interfaces;
using Scrutor;

var builder = WebApplication.CreateBuilder(args);


var assemblies = AppDomain.CurrentDomain.GetAssemblies();

//builder.Services.Scan(scan => scan
//    .FromAssemblies(assemblies)
//    .AddClasses(classes => classes
//        .InNamespaces("RMS_BAL.Repository", "RMS_BAL.Services") // Add the necessary namespaces
//        .Where(c => c.Name.EndsWith("Service"))
//    )
//    .AsImplementedInterfaces()
//    .WithScopedLifetime()
//);


builder.Services.AddScoped<IDivisionRepository, DivisionProductSalesRepository>();
builder.Services.AddScoped<IDivisionService, DivisionService>();

builder.Services.AddScoped<IDropdownCommonRepository, DropdownRepository>();
builder.Services.AddScoped<IDropdownCommonServices, DropdownService>();


builder.Services.AddScoped<ICustomerGroupRepository,CustomerGroupRepository>();
builder.Services.AddScoped<ICustomerGroupService, CustomerGroupService>();


<<<<<<< HEAD
builder.Services.AddScoped<ICustomerTypeRepository, CustomerTypeRepository>();
builder.Services.AddScoped<ICustomerTypeService, CustomerTypeService>();



builder.Services.AddScoped<ICustomerTitleRepository, CustomerTitleRepository>();
builder.Services.AddScoped<ICustomerTitleService, CustomerTitleService>();


=======
//Athira change
builder.Services.AddScoped<IUserPositionsRepository, UserPositionsRepository>();
builder.Services.AddScoped<IUserPositionsService, UserPositionsService>();

builder.Services.AddScoped<IDepartmentsRepository, DepartmentsRepository>();
builder.Services.AddScoped<IDepartmentsService, DepartmentService>();

builder.Services.AddScoped<IUserPermissionRepository, UserPermissionRepository>();
builder.Services.AddScoped<IUserPermissionService, UserPermissionService>();



/////////end/-----
>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274

builder.Services.AddScoped<IExceptionHandlingService, ExceptionHandlingService>();
builder.Services.AddScoped<IExcepetionHandlingRepository, ExcepetionHandlingRepository>();


<<<<<<< HEAD
//builder.Services.AddScoped<IDropdownCommonRepository, DropdownRepository>();
//builder.Services.AddScoped<IDropdownCommonServices, DropdownService>



//builder.Services.AddScoped<ICompanyConceptRepository, CompanyConceptRepository>();
//builder.Services.AddScoped<ICompanyConceptService, CompanyConceptService>();
=======
builder.Services.AddScoped<ICompanyConceptRepository, CompanyConceptRepository>();
builder.Services.AddScoped<ICompanyConceptService, CompanyConceptService>();


builder.Services.AddScoped<IProductSetupCategoryRepository, ProductCategoryRepository>();
builder.Services.AddScoped<IProductSetupCategoryService, ProductSetupCategoryServices>();

>>>>>>> 9e3255a0571a76a2273843c46cb22262d7c52274


// Register services BEFORE calling builder.Build()
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession();

// Add other services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });


builder.Services.AddControllersWithViews();

// Add API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    dbContext.Database.Migrate();
//}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRouting();

app.UseSession();

app.UseAuthorization();
app.MapControllers();

app.MapControllerRoute(
    name: "default",
       //pattern: "{controller=Home}/{action=Index}/{id?}");
       pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
