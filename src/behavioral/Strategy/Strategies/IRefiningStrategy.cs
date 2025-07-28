namespace Strategy.Strategies;
using System;

// Strategy Interface
public interface IRefiningStrategy
{
    String StrategyName { get; }
    RefinedProducts ProcessCrudeOil(CrudeOil crudeOil);
    Boolean IsOptimalFor(CrudeOil crudeOil);
}
