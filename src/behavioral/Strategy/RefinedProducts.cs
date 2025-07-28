namespace Strategy;

using System;
using System.Collections.Generic;
using System.Linq;

public class RefinedProducts
{
    public Dictionary<String, Decimal> Products { get; set; } = new Dictionary<String, Decimal>();
    public Decimal TotalYield => Products.Values.Sum();
    public Decimal ProcessingCost { get; set; }

    public void AddProduct(String productName, Decimal barrels)
    {
        if (Products.ContainsKey(productName))
        {
            Products[productName] += barrels;
        }
        else
        {
            Products[productName] = barrels;
        }
    }

    public void DisplayResults()
    {
        Console.WriteLine("=== Refining Results ===");
        foreach (KeyValuePair<String, Decimal> product in Products)
        {
            Decimal percentage = product.Value / TotalYield * 100;
            Console.WriteLine($"{product.Key}: {product.Value:F2} barrels ({percentage:F1}%)");
        }
        Console.WriteLine($"Total Yield: {TotalYield:F2} barrels");
        Console.WriteLine($"Processing Cost: ${ProcessingCost:F2}");
        Console.WriteLine();
    }
}
