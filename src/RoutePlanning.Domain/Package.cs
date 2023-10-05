using System.Collections;

namespace RoutePlanning.Domain;

public class Package
{
    public Dimensions Dimensions { get; set; }
    public List<string> Categories { get; set; }
    public bool Recorded { get; set; }

    public Package(Dimensions dimensions, List<string> categories, bool recorded)
    {
        Dimensions = dimensions;
        Categories = categories;
        Recorded = recorded;
    }
}

