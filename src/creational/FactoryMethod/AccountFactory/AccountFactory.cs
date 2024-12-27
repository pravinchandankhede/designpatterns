namespace FactoryMethod.AccountFactory;

using FactoryMethod.Account;
using FactoryMethod.AccountStore;

/// <summary>
/// Actual Factory class to showcase the creation of diffeent type of IAccount.
/// </summary>
internal class AccountFactory : IAccountFactory
{
    private readonly IAccountStore _accountStore;

    public AccountFactory(IAccountStore accountStore)
    {
        _accountStore = accountStore;
    }

    /// <summary>
    /// Factory method. This method takes a identifier and creates an instance of this. For simplicity this method uses ENUM AccountType, however you may want to make it more sophisticated based on your scenario.
    /// </summary>
    /// <param name="accountType">identifier to tell what type of IAccount instance to create.</param>
    /// <returns>Return a instance of IAccount.</returns>
    /// <exception cref="ArgumentException"></exception>
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
