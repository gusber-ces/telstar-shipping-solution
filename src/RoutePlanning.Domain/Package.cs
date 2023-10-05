using System.Collections;

namespace RoutePlanning.Domain;

public class Package
{
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

