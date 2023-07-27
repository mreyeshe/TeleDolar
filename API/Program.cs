// <copyright file="Program.cs" company="TeleDolar">
// This source code is Free and MAY BE copied, reproduced,
// published, distributed or transmitted to or stored in any manner.
// </copyright>

using Serilog.Events;
using Serilog;
using Steeltoe.Extensions.Configuration.Placeholder;
using API.IoC;

const string APP_NAME = "TeleDolar API";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Serilog
builder.Host.UseSerilog();

// Add Placeholder
builder.AddPlaceholderResolver();

Log.Logger = new LoggerConfiguration()
        .MinimumLevel.Debug()
        .MinimumLevel.Override("Microsoft", LogEventLevel.Debug)
        .MinimumLevel.Override("System", LogEventLevel.Debug)
        .WriteTo.Seq(builder.Configuration.GetSection("AppConfig:SeqUrl").Value)
        .WriteTo.Console()
        .CreateLogger();

Log.Information($"{APP_NAME} service starting.");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCleanArchitectureServices(builder.Configuration);

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
