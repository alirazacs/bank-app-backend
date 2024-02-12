using BankAppBackend.Models;
using BankAppBackend.Repositories;
using BankAppBackend.Repositories.Interfaces;
using BankAppBackend.Service;
using BankAppBackend.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options => options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("SQLConnectionString") ?? throw new InvalidOperationException("Connection string of name SQLConnectionString not found");
builder.Services.AddDbContext<DatabaseContext>(conn => conn.UseSqlServer(connectionString));
builder.Services.AddScoped<IApplicantRepository, ApplicantRepository>();
builder.Services.AddTransient<ITellerRepository, TellerRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ITransactionRepository, TranscationRepository>();
builder.Services.AddScoped<IApplicantService, ApplicantService>();
builder.Services.AddScoped<ITellerService, TellerService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IRedisMessagePublisherService, RedisMessagePublisherService>();
var app = builder.Build();


//Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
