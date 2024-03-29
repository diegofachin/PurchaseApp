﻿using Domain.Interfaces;
using Infra.Context;
using Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Infra;

[ExcludeFromCodeCoverage]
public static class IoC
{
    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepository();

        services.AddDbContext<PurchaseAppDbContext>(opt => opt
            .UseSqlServer(configuration.GetConnectionString("PurchaseAppConnection")));

        return services;
    }

    public static IServiceCollection AddRepository(this IServiceCollection services)
    {
        services.AddTransient<IAppRepository, AppRepository>();
        services.AddTransient<IPurchaseRepository, PurchaseRepository>();
        services.AddTransient<ITransactionRepository, TransactionRepository>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();

        return services;
    }
}