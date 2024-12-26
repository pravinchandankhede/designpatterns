namespace FactoryMethod.Account;

using FactoryMethod.AccountStore;

internal class SavingAccount : IAccount
{
    private decimal _balance;
    private readonly IAccountStore _store;

    public SavingAccount(IAccountStore store)
    {
        _store = store;
    }

    public void Deposit(decimal amount)
    {
        _balance += amount;
        _store.Save(this);
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Transfer(decimal amount, IAccount toAccount)
    {
        // Implement atomic transfer here
        toAccount.Deposit(amount);
        Withdraw(amount);
    }

    public void Withdraw(decimal amount)
    {
        _balance -= amount;
        _store.Save(this);
    }
}
