namespace FactoryMethod.Account;

abstract class AccountBase
{
    protected System.Decimal Balance { get; set; }
    protected System.String? Name { get; set; }
    protected AccountType AccountType { get; set; }

    protected AccountBase() { }
}
