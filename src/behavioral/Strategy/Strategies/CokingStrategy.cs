namespace Strategy.Strategies;

using System;

// Concrete Strategy 3: Coking Process - Maximizes heavy product utilization
public class CokingStrategy : IRefiningStrategy
{
    public String StrategyName => "Delayed Coking Process";

    public RefinedProducts ProcessCrudeOil(CrudeOil crudeOil)
    {
        RefinedProducts products = new RefinedProducts();
        Decimal totalBarrels = crudeOil.Barrels;

        Console.WriteLine($"Processing {totalBarrels} barrels of {crudeOil.Type} using {StrategyName}");
        Console.WriteLine("Optimized for: Heavy crude processing and coke production\n");

        // Coking yields - more heavy products and coke
        products.AddProduct("Gasoline", totalBarrels * 0.28m);
        products.AddProduct("Diesel", totalBarrels * 0.30m);
        products.AddProduct("Jet Fuel", totalBarrels * 0.12m);
        products.AddProduct("Heavy Fuel Oil", totalBarrels * 0.15m);
        products.AddProduct("Petroleum Coke", totalBarrels * 0.10m);
        products.AddProduct("LPG", totalBarrels * 0.05m);

        // Lower processing cost but more waste
        products.ProcessingCost = totalBarrels * 10.25m;

        return products;
    }

    public Boolean IsOptimalFor(CrudeOil crudeOil)
    {
        // Best for heavy crude with high sulfur content
        return crudeOil.APIGravity < 25 || crudeOil.SulfurContent > 1.0m;
    }
}
