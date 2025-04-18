namespace AbstractFactory.Cards;

internal class CreditCardFactory : IPaymentFactory
{
	public IPayment CreatePayment() => new Cards.CreditCard();
}

internal class VisaFactory : IPaymentFactory
{
	public IPayment CreatePayment() => new Cards.Visa();
}
