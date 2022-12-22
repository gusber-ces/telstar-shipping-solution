using Netcompany.Net.Cqs.Commands;
using Netcompany.Net.DomainDrivenDesign.Services;
using Netcompany.RoutePlanning.Core.Domain.Model;

namespace Netcompany.RoutePlanning.Core.Application.Command.CreateTwoWayConnection;
public class CreateTwoWayConnectionCommandHandler : ICommandHandler<CreateTwoWayConnectionCommand>
{
    private readonly IRepository<Location> _locations;

    public CreateTwoWayConnectionCommandHandler(IRepository<Location> locations)
    {
        _locations = locations;
    }

    public async Task Handle(CreateTwoWayConnectionCommand command, CancellationToken cancellationToken)
    {
        var locationA = await _locations.Get(command.LocationAId, cancellationToken);
        var locationB = await _locations.Get(command.LocationBId, cancellationToken);

        locationA.AddConnection(locationB, command.Distance);
        locationB.AddConnection(locationA, command.Distance);
    }
}
