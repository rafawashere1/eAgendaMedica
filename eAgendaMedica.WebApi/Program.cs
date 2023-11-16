using eAgendaMedica.Application.ActivityModule;
using eAgendaMedica.Application.DoctorModule;
using eAgendaMedica.Domain.ActivityModule;
using eAgendaMedica.Domain.DoctorModule;
using eAgendaMedica.Domain.Shared;
using eAgendaMedica.Infra.Orm.ActivityModule;
using eAgendaMedica.Infra.Orm.DoctorModule;
using eAgendaMedica.Infra.Orm.Shared;
using eAgendaMedica.WebApi.Config.AutoMapperConfig.MappingActions;
using eAgendaMedica.WebApi.Config.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.ConfigureControllers();

            var connectionString = builder.Configuration.GetConnectionString("SqlServer");

            builder.Services.AddDbContext<IPersistenceContext, eAgendaMedicaDbContext>(optionsBulder =>
            {
                optionsBulder.UseSqlServer(connectionString);
            });

            builder.Services.AddTransient<IDoctorRepository, DoctorRepositoryOrm>();
            builder.Services.AddTransient<DoctorAppService>();

            builder.Services.AddTransient<IActivityRepository, ActivityRepositoryOrm>();
            builder.Services.AddTransient<ActivityAppService>();

            builder.Services.AddTransient<ConfigureActivityMappingAction>();

            builder.Services.ConfigureAutoMapper();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.ConfigureSwagger();

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
        }
    }
}