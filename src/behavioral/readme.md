# Design Patterns Documentation

## Table of Contents
- [Design Patterns](#design-patterns)
  - [Strategy Pattern (Oil Refinery Example)](#strategy-pattern-oil-refinery-example)
  - [Other Patterns](#other-patterns)

---

## Design Patterns

### Strategy Pattern (Oil Refinery Example)

#### Overview
Demonstrates the Strategy Pattern using an oil refinery domain example. The refinery selects among different refining processes (Hydrocracking, FCC, Coking) based on crude oil properties and market needs.

#### Pattern Summary
- **Context:** `OilRefinery` manages the refining process.
- **Strategy Interface:** `IRefiningStrategy` defines the contract for all strategies.
- **Strategies:** Hydrocracking, Fluid Catalytic Cracking (FCC), Delayed Coking.

#### Class Structure
- **CrudeOil:** Input model (type, barrels, API gravity, sulfur).
- **RefinedProducts:** Output model (product yields, cost).
- **IRefiningStrategy:** Interface for strategies.
- **OilRefinery:** Context for strategy selection and processing.

#### Strategies
- **Hydrocracking:** Maximizes gasoline/jet fuel. Best for light, sweet crude.
- **FCC:** Balanced product mix. Best for medium crude.
- **Coking:** Handles heavy, sour crude. Produces petroleum coke.

#### Usage Example

```csharp
var strategies = new List<IRefiningStrategy> {
    new HydrocrackingStrategy(),
    new FluidCatalyticCrackingStrategy(),
    new CokingStrategy()
};
var refinery = new OilRefinery("Gulf Coast Refinery");
var brentCrude = new CrudeOil("Brent Crude", 10000m, 38.3m, 0.37m);
refinery.OptimizeStrategyFor(brentCrude, strategies);
var results = refinery.ProcessCrudeOil(brentCrude);
results.DisplayResults();
```

#### Output Example

```
=== Refining Results ===
Gasoline: 4500.00 barrels (45.0%)
Jet Fuel: 2000.00 barrels (20.0%)
Diesel: 1800.00 barrels (18.0%)
Heating Oil: 800.00 barrels (8.0%)
Heavy Fuel Oil: 500.00 barrels (5.0%)
Petrochemical Feedstock: 400.00 barrels (4.0%)
Total Yield: 10000.00 barrels
Processing Cost: $155,000.00
```

#### Key Benefits
- Flexible strategy selection
- Easy to extend with new processes
- Clear separation of concerns

#### Code Implementation
See `Program.cs` for the full implementation.

---

### Other Patterns

