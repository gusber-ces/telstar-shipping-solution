using Microsoft.EntityFrameworkCore;

namespace RoutePlanning.Domain.Locations.Services;

public static class PriceService
{
    public static double CalculatePrice(Route route, Package package)
    {
        double price = route.Distance * 3;
        if (package.Recorded) { price += 10; }
        
        if (package.Categories.Contains(Category.LiveAnimals)) { price += price * 0.5; }

        if (package.Categories.Contains(Category.CautiousParcels)) { price += price * 0.75; }

        if (package.Categories.Contains(Category.RefrigeratedGoods)) { price += price * 0.1; }

        return price;
    }
}
