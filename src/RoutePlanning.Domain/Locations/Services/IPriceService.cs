using Netcompany.Net.DomainDrivenDesign.Services;

namespace RoutePlanning.Domain.Locations.Services;

public interface IPriceService : IDomainService
{
    float CalculatePrice(Route route, Package package);
}
