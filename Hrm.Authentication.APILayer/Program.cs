using Hrm.Authentication.ApplicationCore.Contract.Repository;
using Hrm.Authentication.ApplicationCore.Contract.Service;
using Hrm.Authentication.Infrastructure.Data;
using Hrm.Authentication.Infrastructure.Repository;
using Hrm.Authentication.Infrastructure.Service;
using JWTAuthenticationManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddControllers();


//add jwt service dependency
builder.Services.AddSingleton<JwtTokenHandler>();




//var result = builder.Configuration.GetConnectionString("AuthenticationDb");
builder.Services.AddDbContext<AuthenticationDbContext>(options =>
{
    //if (result!=null)
    options.UseSqlServer(builder.Configuration.GetConnectionString("AuthenticationDb"));
    //else
    options.UseSqlServer(Environment.GetEnvironmentVariable("AuthenticationApi"));
});


//Denpendency Injection
builder.Services.AddScoped<IUserRepositoryAsync, UserRepositoryAsync>();
builder.Services.AddScoped<IUserServiceAsync, UserServiceAsync>();
builder.Services.AddScoped<IUserRoleRepositoryAsync, UserRoleRepositoryAsync>();
builder.Services.AddScoped<IUserRoleServiceAsync, UserRoleServiceAsync>();
builder.Services.AddScoped<IRoleRepositoryAsync, RoleRepositoryAsync>();
builder.Services.AddScoped<IRoleServiceAsync, RoleServiceAsync>();



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

