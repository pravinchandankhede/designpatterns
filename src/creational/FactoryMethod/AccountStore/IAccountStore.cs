namespace FactoryMethod.AccountStore;

using FactoryMethod.Account;

/// <summary>
/// Interface to a permanent store.
/// </summary>
internal interface IAccountStore
{
    void CreateAccount(IAccount account);
    void Save(IAccount account);
}
