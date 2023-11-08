﻿using Microsoft.Extensions.DependencyInjection;
using RES.Application.Services.Users.command;

namespace RES.Application;

public static class DICountainer
{
    public static IServiceCollection ServiceCollections(this IServiceCollection services)
    {
        services.AddScoped<ICreateUserServices, CreateUserServices>();


        return services;
    }
}