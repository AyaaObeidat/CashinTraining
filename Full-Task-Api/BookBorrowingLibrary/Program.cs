using BookBorrowingLibrary.Data;
using BookBorrowingLibrary.Repositories.implementations;
using BookBorrowingLibrary.Repositories.Interfaces;
using BookBorrowingLibrary.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookBorrowingLibraryDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("BookBorrowingLibraryConnectionString")));
builder.Services.AddScoped<IUserInterface,UserInterface>();
builder.Services.AddScoped<IBookInterface, BookInterface>();
builder.Services.AddScoped<IDamagedBooksInterface, DamagedBooksInterface>();
builder.Services.AddScoped<IReturnTransactionInterface, ReturnTransactionInterface>();
builder.Services.AddScoped<IBorrowingTransactionInterface, BorrowingTransactionInterface>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<CustomerService>();  
builder.Services.AddScoped<BookService>();

builder.Services.AddCors(Options =>
{
    Options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
