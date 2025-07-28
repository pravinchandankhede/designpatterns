namespace Strategy;

using Strategy.Strategies;

// Usage Example
public class Program
{
    public static void Main()
    {
        // Available refining strategies
        var strategies = new List<IRefiningStrategy>
        {
            new HydrocrackingStrategy(),
            new FluidCatalyticCrackingStrategy(),
            new CokingStrategy()
        };

        // Create refinery
        var refinery = new OilRefinery("Gulf Coast Refinery");

        // Different types of crude oil
        var brentCrude = new CrudeOil("Brent Crude", 10000m, 38.3m, 0.37m); // Light, sweet crude
        var mayaCrude = new CrudeOil("Maya Heavy Crude", 8000m, 22.0m, 3.3m); // Heavy, sour crude
        var wtICrude = new CrudeOil("WTI Crude", 12000m, 39.6m, 0.24m); // Light, sweet crude

        Console.WriteLine("=== Oil Refinery Strategy Pattern Demo ===\n");

        // Process Brent Crude - Auto-select optimal strategy
        refinery.OptimizeStrategyFor(brentCrude, strategies);
        var brentResults = refinery.ProcessCrudeOil(brentCrude);
        brentResults.DisplayResults();

        // Process Maya Heavy Crude - Auto-select optimal strategy
        refinery.OptimizeStrategyFor(mayaCrude, strategies);
        var mayaResults = refinery.ProcessCrudeOil(mayaCrude);
        mayaResults.DisplayResults();

        // Process WTI Crude with manual strategy selection
        Console.WriteLine("=== Manual Strategy Selection for Market Conditions ===");
        Console.WriteLine("Market demand high for gasoline - using Hydrocracking\n");
        refinery.SetRefiningStrategy(new HydrocrackingStrategy());
        var wtiResults = refinery.ProcessCrudeOil(wtICrude);
        wtiResults.DisplayResults();

        // Compare different strategies on same crude
        Console.WriteLine("=== Strategy Comparison on Same Crude Oil ===");
        CompareStrategies(wtICrude, strategies);
    }

    private static void CompareStrategies(CrudeOil crudeOil, List<IRefiningStrategy> strategies)
    {
        var comparisonRefinery = new OilRefinery("Comparison Unit");

        foreach (var strategy in strategies)
        {
            comparisonRefinery.SetRefiningStrategy(strategy);
            var results = comparisonRefinery.ProcessCrudeOil(crudeOil);

            Console.WriteLine($"Strategy: {strategy.StrategyName}");
            Console.WriteLine($"Gasoline Yield: {results.Products.GetValueOrDefault("Gasoline", 0):F0} barrels");
            Console.WriteLine($"Total Cost: ${results.ProcessingCost:F0}");
            Console.WriteLine($"Cost per barrel: ${results.ProcessingCost / crudeOil.Barrels:F2}");
            Console.WriteLine();
        }
    }
}