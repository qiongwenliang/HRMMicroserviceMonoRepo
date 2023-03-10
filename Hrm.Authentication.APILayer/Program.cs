using Hrm.Authentication.ApplicationCore.Contract.Repository;
using Hrm.Authentication.ApplicationCore.Contract.Service;
using Hrm.Authentication.Infrastructure.Data;
using Hrm.Authentication.Infrastructure.Repository;
using Hrm.Authentication.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationDb"));
    options.UseSqlServer(Environment.GetEnvironmentVariable("AuthenticationApi"));
});


//Denpendency Injection
builder.Services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
builder.Services.AddScoped<IUserServiceAsync, UserServiceAsync>();
builder.Services.AddScoped<IUserRoleRepositoryAsync, UserRoleRepositoryAsync>();
builder.Services.AddScoped<IUserRoleServiceAsync, UserRoleServiceAsync>();
builder.Services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
builder.Services.AddScoped<IRoleServiceAsync, RoleServiceAsync>();



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
//map to a particular controller


app.Run();

