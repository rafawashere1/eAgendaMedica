using eAgendaMedica.WebApi.Config;
using eAgendaMedica.WebApi.Config.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace eAgendaMedica.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.Configure<ApiBehaviorOptions>(config =>
            {
                config.SuppressModelStateInvalidFilter = true;
            });

            // Add services to the container.

            builder.Services.ConfigureSerilog(builder.Logging);
            builder.Services.ConfigureControllers();
            builder.Services.ConfigureDependencyInjection(builder.Configuration);
            builder.Services.ConfigureAutoMapper();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.ConfigureSwagger();

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandler>();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}