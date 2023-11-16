using Serilog;

namespace eAgendaMedica.WebApi.Config.Extensions
{
    public static class SerilogConfigExtension
    {
        public static void ConfigureSerilog(this IServiceCollection services, ILoggingBuilder logging)
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Information()
              .Enrich.FromLogContext()
              .WriteTo.Console()
              .CreateLogger();

            Log.Logger.Information("Starting application...");

            logging.ClearProviders();

            services.AddSerilog(Log.Logger);
        }
    }
}
