﻿using API.Data;
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
        services.AddScoped<IUserRepository, UserRepository>(); // initialize i user repository, scoped to the level of http request, injectable to the user controller
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
