namespace FactoryMethod.AccountStore;

using FactoryMethod.Account;

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
