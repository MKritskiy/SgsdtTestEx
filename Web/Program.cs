using Events.Web.Configurations;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Extensions.Logging;
using Web.Configurations;

var builder = WebApplication.CreateBuilder(args);

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting web host");
builder.AddLoggerConfigs();
builder.Services.AddControllers();
var appLogger = new SerilogLoggerFactory(logger)
    .CreateLogger<Program>();


builder.Services.AddInfrastructureServices(builder.Configuration, appLogger);
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DailyValute API",
        Version = "v1"
    });
});

#if (aspire)
builder.AddServiceDefaults();
#endif
var app = builder.Build();
app.UseAppMiddleware();

app.Run();
