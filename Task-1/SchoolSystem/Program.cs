using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SchoolSystemDbContext>(Options =>
Options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolSystemConnectionString")));

builder.Services.AddScoped<SchoolService>();
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<TeacherService>();

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
