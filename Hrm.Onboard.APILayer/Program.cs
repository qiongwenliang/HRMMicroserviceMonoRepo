using Hrm.Onboard.ApplicationCore.Contract.Repository;
using Hrm.Onboard.ApplicationCore.Contract.Service;
using Hrm.Onboard.Infrastructure.Data;
using Hrm.Onboard.Infrastructure.Repository;
using Hrm.Onboard.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var result = builder.Configuration.GetConnectionString("OnboardDb");
builder.Services.AddDbContext<OnboardDbContext>(options =>
{
    //if (result!=null)
    //options.UseSqlServer(builder.Configuration.GetConnectionString("OnboardDb"));
    //else
    options.UseSqlServer(Environment.GetEnvironmentVariable("OnboardApi"));
});


//Dependency Injection
builder.Services.AddScoped<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
builder.Services.AddScoped<IEmployeeServiceAsync, EmployeeServiceAsync>();
builder.Services.AddScoped<IEmployeeRoleRepositoryAsync, EmployeeRoleRepositoryAsync>();
builder.Services.AddScoped<IEmployeeRoleServiceAsync, EmployeeRoleServiceAsync>();
builder.Services.AddScoped<IEmployeeCategoryRepositoryAsync, EmployeeCategoryRepositoryAsync>();
builder.Services.AddScoped<IEmployeeCategoryServiceAsync, EmployeeCategoryServiceAsync>();
builder.Services.AddScoped<IEmployeeStatusServiceAsync, EmployeeStatusServiceAsync>();
builder.Services.AddScoped<IEmployeeStatusRepositoryAsync, EmployeeStatusRepositoryAsync>();



builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyMethod();
        policy.AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();
