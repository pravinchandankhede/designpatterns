namespace FactoryMethod.AccountFactory;

using FactoryMethod.Account;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Account Factor using IServiceProvider.
/// </summary>
internal class AccountFactoryServiceProvider : IAccountFactory
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Take the service provider in constructor. This is used to resolve the instance inside factor method.
    /// </summary>
    /// <param name="serviceProvider">The constructed service provider</param>
    public AccountFactoryServiceProvider(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Factory method to create account based on account type and arguments passed in constructor.
    /// </summary>
    /// <param name="accountType">type of IAccount to be created.</param>
    /// <returns>An instance of IAccount</returns>
    /// <exception cref="ArgumentException">When not supported accountType is given.</exception>
    public IAccount GetAccount(AccountType accountType)
    {
        return accountType switch
        {
            AccountType.Saving => _serviceProvider.GetRequiredService<SavingAccount>(),
            AccountType.Current => _serviceProvider.GetRequiredService<CurrentAccount>(),
            _ => throw new ArgumentException("Invalid account type")
        };
    }
}
