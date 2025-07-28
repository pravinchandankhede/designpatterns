namespace Strategy;

using Strategy.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;

// Context - Oil Refinery
public class OilRefinery
{
    private IRefiningStrategy _refiningStrategy;
    public String RefineryName { get; private set; }

    public OilRefinery(String refineryName)
    {
        RefineryName = refineryName;
    }

    public void SetRefiningStrategy(IRefiningStrategy strategy)
    {
        _refiningStrategy = strategy;
        Console.WriteLine($"[{RefineryName}] Switching to: {strategy.StrategyName}");
    }

    public RefinedProducts ProcessCrudeOil(CrudeOil crudeOil)
    {
        if (_refiningStrategy == null)
        {
            throw new InvalidOperationException("Refining strategy not set");
        }

        Console.WriteLine($"\n=== {RefineryName} Refinery Processing ===");
        return _refiningStrategy.ProcessCrudeOil(crudeOil);
    }

    // Automatically select optimal strategy based on crude oil properties
    public void OptimizeStrategyFor(CrudeOil crudeOil, List<IRefiningStrategy> availableStrategies)
    {
        IRefiningStrategy optimalStrategy = availableStrategies.FirstOrDefault(s => s.IsOptimalFor(crudeOil))
                             ?? availableStrategies.First(); // Default to first if none optimal

        SetRefiningStrategy(optimalStrategy);
        Console.WriteLine($"Strategy selected based on crude oil properties (API: {crudeOil.APIGravity}°, Sulfur: {crudeOil.SulfurContent}%)\n");
    }
}