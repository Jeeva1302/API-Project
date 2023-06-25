using api_project.Auth;
using api_project.Data;
using api_project.Repository.AppointmentDatailsservices;
using api_project.Repository.CourseDetailsservice;
using api_project.Repository.DoctorDetailsservices;
using api_project.Repository.FeedbackDetailsservice;
using api_project.Repository.PatientDetailsservice;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IDoctorDetailservice, DoctorDetailsservice>();
builder.Services.AddScoped<IPatientdetailsservice, Patientdetailsservice>();
builder.Services.AddScoped<ICoursedetailsservice, Coursedetailsservice>();
builder.Services.AddScoped<IAppointmentDetailsservice, AppointmentDetailsservice>();
builder.Services.AddScoped<IFeedbackDetailsservice, FeedbackDetailsservice>();
builder.Services.AddDbContext<RjHospitalContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SQLConnection")));
builder.Services.AddDbContext<ApplicationDbContext>(optionsAction: options => options.UseSqlServer(builder.Configuration.GetConnectionString(name: "jwt")));

ConfigurationManager configuration = builder.Configuration;

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
