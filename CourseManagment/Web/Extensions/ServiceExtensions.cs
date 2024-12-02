using Contracts;
using LoggerService;
using Microsoft.EntityFrameworkCore;
using Repository.OtherRepository;
using Service;
using Service.Contracts;

namespace Web.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

    public static void ConfigureIISIntegration(this IServiceCollection services) =>
        services.Configure<IISOptions>(options =>
        {
        });

    public static void ConfigureRepositoryManager(this IServiceCollection service) =>
        service.AddScoped<IRepositoryManager, RepositoryManager>();

    public static void ConfigureServiceManager(this IServiceCollection services) =>
        services.AddScoped<IServiceManager, ServiceManager>();


    public static void ConfigureLoggerService(this IServiceCollection services) => 
        services.AddSingleton<ILoggerManager, LoggerManager>();


    public static void ConfigureSqlContext(this IServiceCollection service, IConfiguration configuration) =>
    service.AddDbContext<RepositoryContext>(opts=>
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
}