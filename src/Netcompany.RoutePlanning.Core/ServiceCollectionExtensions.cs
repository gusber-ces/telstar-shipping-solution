using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Netcompany.Net.Cqs;
using Netcompany.Net.DomainDrivenDesign;
using Netcompany.Net.DomainDrivenDesign.EntityFrameworkCore;
using Netcompany.Net.Middleware.UnhandledExceptions.Extensions;
using Netcompany.Net.UnitOfWork;
using Netcompany.Net.UnitOfWork.AmbientTransactions;
using Netcompany.Net.UnitOfWork.Cqs;
using Netcompany.Net.Validation.Exceptions.Extensions;
using Netcompany.Net.Validation.Extensions;
using Netcompany.RoutePlanning.Core.Database;
using Netcompany.RoutePlanning.Core.Domain.Service;

namespace Netcompany.RoutePlanning.Core;

public static class ServiceCollectionExtensions
{
    public static void AddRoutePlanningDomain(this IServiceCollection services, IConfiguration configuration)
    {
        // DDD, CQS, Validation
        services.AddDomainDrivenDesign()
            .AddRepositoryFactory<RoutePlanningDatabaseContext>()
            .AddQueryableFactory<RoutePlanningDatabaseContext>();
        services.AddUnitOfWork(builder => builder.UseAmbientTransactions().With<RoutePlanningDatabaseContext>());
        services.AddCqs(options => options.UseUnitOfWork()).With<RoutePlanningDatabaseContext>();
        services.AddValidation<RoutePlanningDatabaseContext>(configuration);

        // Domain services
        services.AddTransient<IShortestDistanceService, ShortestDistanceService>();

        // Middlewares
        services.AddNetcompanyExceptionHandlerMiddleware();
        services.AddValidationExceptionHandlerMiddleware();
    }
}
