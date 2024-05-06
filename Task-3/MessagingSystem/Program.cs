using MessagingSystem.Data;
using MessagingSystem.Repositories.Implementations;
using MessagingSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MessagingSystemDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("MessagingSystemConnectionString")));

builder.Services.AddScoped<IUserInterface, UserInterface>();
builder.Services.AddScoped<IMessageInterface, MessageInterface>();
builder.Services.AddScoped<IMessageDistenationInterface, MessageDistenationInterface>();

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
