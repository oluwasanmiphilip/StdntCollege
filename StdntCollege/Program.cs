using Microsoft.EntityFrameworkCore;
using Serilog;
using StdntCollege.Data;
using StdntCollege.MyLogging;


var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders(); 
//builder.Logging.AddDebug();
//builder.Logging.AddConsole();
// Add services to the container.
builder.Logging.AddLog4Net();

builder.Services.AddDbContext<SchDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SchAppDBConnection"));
    });
#region Serilog Settings

//Log.Logger = new LoggerConfiguration().
//    MinimumLevel.Information()
//    .WriteTo.File("Log/log.txt",
//    rollingInterval: RollingInterval.Minute)
//    .CreateLogger();

////Use to override built in loggers 
//builder.Host.UseSerilog();

////Use SeriLog along with built in loggers
//builder.Logging.AddSerilog();
#endregion
builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMyLogger, LogToServerMemory>();
builder.Services.AddSingleton<IMyLogger, LogToServerMemory>();
builder.Services.AddTransient<IMyLogger, LogToServerMemory>();

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
