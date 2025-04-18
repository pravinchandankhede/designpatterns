namespace AbstractFactory.Wallets;

internal class WalletFactory : IPaymentFactory
{
	public IPayment CreatePayment() => new Wallets.Wallet();
}
