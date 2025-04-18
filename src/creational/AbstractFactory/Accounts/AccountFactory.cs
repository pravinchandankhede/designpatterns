namespace AbstractFactory.Accounts;

internal class SavingAccountFactory : IPaymentFactory
{
	public IPayment CreatePayment() => new Accounts.SavingAccount();
}

internal class CurrentAccountFactory : IPaymentFactory
{
	public IPayment CreatePayment() => new Accounts.CurrentAccount();
}
