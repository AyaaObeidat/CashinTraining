using MessagingSystem.Data;
using MessagingSystem.Repositories.Implementations;
using MessagingSystem.Repositories.Interfaces;
using MessagingSystem.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MessagingSystemDbContext>(Options => 
Options.UseSqlServer(builder.Configuration.GetConnectionString("MessagingSystemConnectionString")));

builder.Services.AddScoped<IUserInterface,UserInterface>();
builder.Services.AddScoped<IUserProfileInterface, UserProfileInterface>();
builder.Services.AddScoped<IInboxInterface, InboxInterface>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<UserProfileService>();
builder.Services.AddScoped<InboxService>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
