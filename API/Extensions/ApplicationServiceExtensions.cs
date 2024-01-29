using API.Data;
using API.Interfaces;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt => 
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        }); // initiate sqlite

        services.AddCors(); // allow app to access
        services.AddScoped<ITokenService, TokenService>(); // initialize token service 

        return services;
    }
}
