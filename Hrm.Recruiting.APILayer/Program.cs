using Azure.Storage.Blobs;
using Hrm.Recruiting.ApplicationCore.Contract.Repository;
using Hrm.Recruiting.ApplicationCore.Contract.Service;
using Hrm.Recruiting.Infrastructure.Data;
using Hrm.Recruiting.Infrastructure.Repository;
using Hrm.Recruiting.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using JWTAuthenticationManager;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddCustomJWTAuthentication();



//blob storage dependency injection
builder.Services.AddSingleton(x => new BlobServiceClient(builder.Configuration.GetValue<string>("recruitingcandidateresumecontainer")));
builder.Services.AddScoped<IBlobServiceAsync, BlobServiceAsync>();



//var result = builder.Configuration.GetConnectionString("RecruitmentDb");
builder.Services.AddDbContext<RecruitmentDbContext>(options =>
{
    //if (result != null)
    //options.UseSqlServer(builder.Configuration.GetConnectionString("RecruitmentDb"));
    //else
    options.UseSqlServer(Environment.GetEnvironmentVariable("RecruitmentApi"));

});


//Dependency Injection
builder.Services.AddScoped<ICandidateServiceAsync, CandidateServiceAsync>();
builder.Services.AddScoped<ICandidateRepositoryAsync, CandidateRepositoryAsync>();
builder.Services.AddScoped<IJobCategoryServiceAsync, JobCategoryServiceAsync>();
builder.Services.AddScoped<IJobCategoryRepositoryAsync, JobCategoryRepositoryAsync>();
builder.Services.AddScoped<IJobRequirementServiceAsync, JobRequirementServiceAsync>();
builder.Services.AddScoped<IJobRequirementRepositoryAsync, JobRequirementRepositoryAsync>();    
builder.Services.AddScoped<ISubmissionServiceAsync, SubmissionServiceAsync>();  
builder.Services.AddScoped<ISubmissionRepositoryAsync, SubmissionRepositoryAsync>();
builder.Services.AddScoped<ISubmissionStatusServiceAsync, SubmissionStatusServiceAsync>();
builder.Services.AddScoped<ISubmissionStatusRepositoryAsync, SubmissionStatusRepositoryAsync>();



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

//authentication must be put before authorization, and between should put userouting
app.UseAuthentication();
app.UseRouting(); 
app.UseAuthorization();

app.UseCors();

app.UseEndpoints(endpoints => { endpoints.MapControllers(); }); 

app.Run();

