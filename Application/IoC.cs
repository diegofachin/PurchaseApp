using Application.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

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
        //services.AddScoped<IValidator<RegisterPersonRequestDto>, RegisterPersonValidator>();
        //services.AddScoped<IValidator<AuthenticatePersonRequestDto>, AuthenticatePersonValidator>();

        return services;
    }


}