using System.Collections;
using Netcompany.Net.DomainDrivenDesign.Models;

namespace RoutePlanning.Domain;

public class Package: Entity<Package>
{

    private Package()
    {
        Dimensions = new Dimensions(1, 1, 1, 1);
        Categories = new List<Category> { Category.Weapons };
    }
    public Dimensions Dimensions { get; set; }
    public List<Category> Categories { get; set; }
    public bool Recorded { get; set; }

    public Package(Dimensions dimensions, List<Category> categories, bool recorded)
    {
        Dimensions = dimensions;
        Categories = categories;
        Recorded = recorded;
    }
}

