namespace FactoryMethod.Account;

/// <summary>
/// Base class to provide shared fields and feature among all type of IAccounts.
/// </summary>
internal abstract class AccountBase
{
    public System.Int64 Number { get; set; }
    protected System.Decimal Balance { get; set; }
    public System.String? Name { get; set; }
    protected AccountType AccountType { get; set; }

    protected AccountBase() {

        var random = new Random();
        Number = random.Next(0, 100);
    }
}
