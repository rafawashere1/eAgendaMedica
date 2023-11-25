using eAgendaMedica.WebApi.Config;
using eAgendaMedica.WebApi.Config.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi
{
    public class Program
    {
        static readonly string nameCors = "Development";

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });

            // Add services to the container.

            builder.Services.ConfigureIdentity();
            builder.Services.ConfigureSerilog(builder.Logging);
            builder.Services.ConfigureAutoMapper();
            builder.Services.ConfigureDependencyInjection(builder.Configuration);
            builder.Services.ConfigureSwagger();
            builder.Services.ConfigureControllers();
            builder.Services.ConfigureJwt();
            builder.Services.ConfigureCors(nameCors);

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandler>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(nameCors);

            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}