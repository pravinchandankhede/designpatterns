namespace FactoryMethod.AccountFactory;

using FactoryMethod.Account;
using Microsoft.Extensions.DependencyInjection;

/// <summary>
/// Account Factor using IServiceProvider.
/// </summary>
internal class AccountFactoryServiceProvider : IAccountFactory
{
    private readonly IServiceProvider _serviceProvider;

    public AccountFactoryServiceProvider(IServiceProvider serviceProvider)
    {
        this._serviceProvider = serviceProvider;
    }

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
