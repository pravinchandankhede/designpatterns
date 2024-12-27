namespace FactoryMethod.Account;

/// <summary>
/// Common account features.
/// </summary>
internal interface IAccount
{
    string Name { get; }
    System.Int64 Number { get; }
    decimal GetBalance();
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void Transfer(decimal amount, IAccount toAccount);
}
