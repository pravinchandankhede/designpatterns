namespace AbstractFactory.UPIs;

internal class UpiFactory : IPaymentFactory
{
	public IPayment CreatePayment() => new UPIs.Upi();
}
