namespace FactoryMethod.AccountFactory;

using FactoryMethod.Account;

internal interface IAccountFactory
{
    IAccount GetAccount(AccountType accountType);
}
