using Microsoft.EntityFrameworkCore;

namespace RoutePlanning.Domain.Locations.Services;

public static class PriceService
{
    public static double CalculatePrice(Package package)
    {
        double price = 3;
        if (package.Recorded) { price += 10; }
        
        if (package.Categories.Contains(Category.LiveAnimals)) { price += price * 0.5; }

        if (package.Categories.Contains(Category.CautiousParcels)) { price += price * 0.75; }

        if (package.Categories.Contains(Category.RefrigeratedGoods)) { price += price * 0.1; }

        return price;
    }
}
