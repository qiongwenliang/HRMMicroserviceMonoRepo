using JWTAuthenticationManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;



var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", false, true).AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);


//add authorization dependency
builder.Services.AddCustomJWTAuthentication();


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

//middleware
await app.UseOcelot();



//add authentication middleware
app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.UseCors();

app.Run();
