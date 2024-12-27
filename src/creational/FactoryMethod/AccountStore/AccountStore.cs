namespace FactoryMethod.AccountStore;

using FactoryMethod.Account;

/// <summary>
/// This is sample store which store instances in a inmemory list. In real world you may want to put this in database.
/// </summary>
internal class AccountStore : IAccountStore
{
    private readonly List<IAccount> _accounts = new();

    public void CreateAccount(IAccount account)
    {
        _accounts.Add(account);
    }

    public void Save(IAccount account)
    {
        _accounts[_accounts.IndexOf(account)] = account;
    }
}
