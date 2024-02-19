using API.Data;
using API.Helpers;
using API.Interfaces;
using API.Services;
using API.SignalR;
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
        //services.AddScoped<IUserRepository, UserRepository>(); // initialize i user repository, scoped to the level of http request, injectable to the user controller
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings")); // map settings with custom class
        services.AddScoped<IPhotoService, PhotoService>();
        services.AddScoped<LogUserActivity>();
        // services.AddScoped<ILikesRepository, LikesRepository>();
        // services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddSignalR();
        services.AddSingleton<PresenceTracker>(); // we need this to live as long our application lives, we don't want this to destroyed once http request is completed
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
