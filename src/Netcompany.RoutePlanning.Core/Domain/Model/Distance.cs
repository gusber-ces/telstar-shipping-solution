using Netcompany.Net.DomainDrivenDesign.Models;

namespace Netcompany.RoutePlanning.Core.Domain.Model;

public record Distance : IValueObject
{
    public Distance(int distance)
    {
        if (distance <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distance), "A distance must be greater than zero");
        }

        Value = distance;
    }

    public int Value { get; private set; }

    public static implicit operator Distance(int distance) => new(distance);

    public static implicit operator int(Distance distance) => distance.Value;
}
