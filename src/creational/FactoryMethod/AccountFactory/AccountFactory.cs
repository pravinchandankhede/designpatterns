namespace FactoryMethod.AccountFactory;

using FactoryMethod.Account;
using FactoryMethod.AccountStore;

internal class AccountFactory : IAccountFactory
{
    private readonly IAccountStore _accountStore;

    public AccountFactory(IAccountStore accountStore)
    {
        _accountStore = accountStore;
    }

    public IAccount GetAccount(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Saving => new SavingAccount(_accountStore),
            AccountType.Current => new CurrentAccount(_accountStore),
            _ => throw new ArgumentException("Invalid account type")
        };
    }
}
