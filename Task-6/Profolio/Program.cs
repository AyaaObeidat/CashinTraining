using Microsoft.EntityFrameworkCore;
using Profolio.Data;
using Profolio.Repositories.Implementations;
using Profolio.Repositories.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ProfolioDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("ProfolioConnectionString")));
builder.Services.AddScoped<IUserInterface, UserInterface>();
builder.Services.AddScoped<ISkillsInterface, SkillsInterface>();
builder.Services.AddScoped<IExperienceInterface, ExperienceInterface>();
builder.Services.AddScoped<IContactInterface, ContactInterface>();

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
