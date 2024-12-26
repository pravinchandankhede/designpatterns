namespace FactoryMethod.Account;

internal interface IAccount
{
    decimal GetBalance();
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
    void Transfer(decimal amount, IAccount toAccount);
}
