using Email_System.Data;
using Email_System.Repositories.Implementations;
using Email_System.Repositories.Interfaces;
using Email_System.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<EmailSystemDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("EmailSystemConnectionString")));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageDestinationRepository, MessageDestinationRepository>();
builder.Services.AddScoped<IInboxRepository, InboxRepository>();
builder.Services.AddScoped<IOutboxRepository, OutboxRepository>();
builder.Services.AddScoped<ITrashRepository, TrashRepository>();
builder.Services.AddScoped<IInboxMessagesRepository, InboxMessagesRepository>();
builder.Services.AddScoped<IOutboxMessagesRepository, OutboxMessagesRepository>();
builder.Services.AddScoped<ITrashMessagesRepository, TrashMessagesRepository>();

builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<MessageService>();






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
