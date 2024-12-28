namespace FactoryMethod.AccountFactory;

using FactoryMethod.Account;
using FactoryMethod.AccountStore;

/// <summary>
/// Implements AccountFactory using reflection
/// </summary>
internal class AccountFactoryReflection : IAccountFactory
{
    private readonly IAccountStore _accountStore;

    /// <summary>
    /// take all dependencies in constructor and store them.
    /// </summary>
    /// <param name="accountStore"></param>
    public AccountFactoryReflection(IAccountStore accountStore)
    {
        this._accountStore = accountStore;
    }

    /// <summary>
    /// Factory method to create account based on account type and arguments passed in constructor.
    /// </summary>
    /// <param name="accountType"></param>
    /// <returns>An Instance of IAccount.</returns>
    /// <exception cref="System.NotImplementedException">When accountType is not matched.</exception>
    public IAccount GetAccount(AccountType accountType)
    {

        return accountType switch
        {
            AccountType.Saving => (IAccount)Activator.CreateInstance(typeof(SavingAccount), _accountStore)!,
            AccountType.Current => (IAccount)Activator.CreateInstance(typeof(CurrentAccount), _accountStore)!,
            _ => throw new System.NotImplementedException()
        };
    }
}
