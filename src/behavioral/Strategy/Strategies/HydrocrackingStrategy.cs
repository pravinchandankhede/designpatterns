namespace Strategy.Strategies;

using System;

// Concrete Strategy 1: Hydrocracking - Maximizes gasoline and jet fuel
public class HydrocrackingStrategy : IRefiningStrategy
{
    public String StrategyName => "Hydrocracking Process";

    public RefinedProducts ProcessCrudeOil(CrudeOil crudeOil)
    {
        RefinedProducts products = new RefinedProducts();
        Decimal totalBarrels = crudeOil.Barrels;

        Console.WriteLine($"Processing {totalBarrels} barrels of {crudeOil.Type} using {StrategyName}");
        Console.WriteLine("Optimized for: Maximum gasoline and jet fuel production\n");

        // Hydrocracking yields - optimized for light products
        products.AddProduct("Gasoline", totalBarrels * 0.45m);
        products.AddProduct("Jet Fuel", totalBarrels * 0.20m);
        products.AddProduct("Diesel", totalBarrels * 0.18m);
        products.AddProduct("Heating Oil", totalBarrels * 0.08m);
        products.AddProduct("Heavy Fuel Oil", totalBarrels * 0.05m);
        products.AddProduct("Petrochemical Feedstock", totalBarrels * 0.04m);

        // Higher processing cost due to hydrogen consumption
        products.ProcessingCost = totalBarrels * 15.50m;

        return products;
    }

    public Boolean IsOptimalFor(CrudeOil crudeOil)
    {
        // Best for light crude with low sulfur content
        return crudeOil.APIGravity > 35 && crudeOil.SulfurContent < 0.5m;
    }
}
