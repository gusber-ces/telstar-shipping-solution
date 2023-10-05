using Microsoft.EntityFrameworkCore;

namespace RoutePlanning.Domain.Locations.Services;

public static class PriceService
{
    public static double CalculatePrice(Package package)
    {
        double price = 3;
        if (package.Recorded) { price += 10; }
        
        if (package.Categories.Contains(Category.LiveAnimals)) { price *= 1.5; }

        if (package.Categories.Contains(Category.CautiousParcels)) { price *= 1.7; }

        if (package.Categories.Contains(Category.RefrigeratedGoods)) { price *= 1.1; }

        return price;
    }
}
