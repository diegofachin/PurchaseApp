using Application.Behavior;
using Application.Handlers.AddApp;
using Application.Handlers.AddPurchase;
using Application.Validators;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Application;

[ExcludeFromCodeCoverage]
public static class IoC
{
    public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddFluentValidation();

        return services;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IValidator<AddAppRequestDto>, AddAppValidator>();
        services.AddScoped<IValidator<AddPurchaseRequestDto>, AddPurchaseValidator>();
        
        return services;
    }


}