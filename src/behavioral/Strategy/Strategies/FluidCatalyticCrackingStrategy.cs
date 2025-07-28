namespace Strategy.Strategies;

using System;

// Concrete Strategy 2: Fluid Catalytic Cracking (FCC) - Balanced production
public class FluidCatalyticCrackingStrategy : IRefiningStrategy
{
    public String StrategyName => "Fluid Catalytic Cracking (FCC)";

    public RefinedProducts ProcessCrudeOil(CrudeOil crudeOil)
    {
        RefinedProducts products = new RefinedProducts();
        Decimal totalBarrels = crudeOil.Barrels;

        Console.WriteLine($"Processing {totalBarrels} barrels of {crudeOil.Type} using {StrategyName}");
        Console.WriteLine("Optimized for: Balanced gasoline and distillate production\n");

        // FCC yields - balanced production
        products.AddProduct("Gasoline", totalBarrels * 0.38m);
        products.AddProduct("Diesel", totalBarrels * 0.25m);
        products.AddProduct("Jet Fuel", totalBarrels * 0.15m);
        products.AddProduct("Heating Oil", totalBarrels * 0.12m);
        products.AddProduct("Heavy Fuel Oil", totalBarrels * 0.06m);
        products.AddProduct("LPG", totalBarrels * 0.04m);

        // Moderate processing cost
        products.ProcessingCost = totalBarrels * 12.75m;

        return products;
    }

    public Boolean IsOptimalFor(CrudeOil crudeOil)
    {
        // Good for medium gravity crude
        return crudeOil.APIGravity >= 25 && crudeOil.APIGravity <= 35;
    }
}