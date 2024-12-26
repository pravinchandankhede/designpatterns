namespace FactoryMethod.AccountStore;

using FactoryMethod.Account;

internal interface IAccountStore
{
    void CreateAccount(IAccount account);
    void Save(IAccount account);
}
