using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Text;
using Microsoft.OpenApi.Models;
using Profolio.Migrations;
using Profolio.Data;
using Profolio.Repositories.Interfaces;
using Profolio.Repositories.Implementations;
using Profolio.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ProfolioDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("BookBorrowingLibraryConnectionString")));


//builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<IUserInterface, UserInterface>();
builder.Services.AddScoped<ISkillsInterface, SkillsInterface>();
builder.Services.AddScoped<IContactInterface, ContactInterface>();
builder.Services.AddScoped<IExperienceInterface, ExperienceInterface>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<SkillsService>();
// Configure Swagger to use JWT authentication
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Book Borrowing Office API", Version = "v1" });

    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme.",
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "Bearer"
        }
    };

    c.AddSecurityDefinition("Bearer", securityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            securityScheme,
            new string[] {}
        }
    });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseCors("AllowAll");


app.UseAuthorization();

app.MapControllers();

app.Run();
