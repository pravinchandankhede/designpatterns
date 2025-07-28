namespace Strategy;

using System;

public class CrudeOil
{
    public String Type { get; set; }
    public Decimal Barrels { get; set; }
    public Decimal APIGravity { get; set; } // Oil density measure
    public Decimal SulfurContent { get; set; } // Percentage

    public CrudeOil(String type, Decimal barrels, Decimal apiGravity, Decimal sulfurContent)
    {
        Type = type;
        Barrels = barrels;
        APIGravity = apiGravity;
        SulfurContent = sulfurContent;
    }
}
