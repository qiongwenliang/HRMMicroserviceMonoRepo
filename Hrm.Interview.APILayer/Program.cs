using Hrm.Interview.ApplicationCore.Contract.Repository;
using Hrm.Interview.ApplicationCore.Contract.Service;
using Hrm.Interview.Infrastructure.Data;
using Hrm.Interview.Infrastructure.Repository;
using Hrm.Interview.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


//var result = builder.Configuration.GetConnectionString("InterviewDb");
builder.Services.AddDbContext<InterviewDbContext>(options =>
{
    //if (result != null)
    //options.UseSqlServer(builder.Configuration.GetConnectionString("InterviewDb"));
    //else
    options.UseSqlServer(Environment.GetEnvironmentVariable("InterviewApi"));
});


//Dependency Injection
builder.Services.AddScoped<IInterviewsRepositoryAsync, InterviewsRepositoryAsync>();
builder.Services.AddScoped<IInterviewsServiceAsync, InterviewsServiceAsync>();
builder.Services.AddScoped<IInterviewerRepositoryAsync, InterviewerRepositoryAsync>();  
builder.Services.AddScoped<IInterviewerServiceAsync, InterviewerServiceAsync>();
builder.Services.AddScoped<IInterviewFeedbackServiceAsync, InterviewFeedbackServiceAsync>();
builder.Services.AddScoped<IInterviewFeedbackRepositoryAsync, InterviewFeedbackRepositoryAsync>();
builder.Services.AddScoped<IInterviewTypeServiceAsync, InterviewTypeServiceAsync>();
builder.Services.AddScoped<IInterviewTypeRepositoryAsync, InterviewTypeRepositoryAsync>();
builder.Services.AddScoped<IRecruiterServiceAsync, RecruiterServiceAsync>();
builder.Services.AddScoped<IRecruiterRepositoryAsync, RecruiterRepositoryAsync>();

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
