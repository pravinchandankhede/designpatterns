namespace FactoryMethod.Account;

using FactoryMethod.AccountStore;

/// <summary>
/// Current account features
/// </summary>
internal class CurrentAccount : AccountBase, IAccount
{
    private readonly IAccountStore _store;

    public CurrentAccount(IAccountStore store)
    {
        _store = store;
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
        _store.Save(this);
    }

    public decimal GetBalance()
    {
        return Balance;
    }

    public void Transfer(decimal amount, IAccount toAccount)
    {
        // Implement atomic transfer here
        toAccount.Deposit(amount);
        Withdraw(amount);
    }

    public void Withdraw(decimal amount)
    {
        Balance -= amount;
        _store.Save(this);
    }
}
