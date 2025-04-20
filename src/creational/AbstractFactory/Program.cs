namespace AbstractFactory;

using AbstractFactory.Accounts;
using AbstractFactory.Cards;

internal class Program
{
    static void Main1()
    {
		IPaymentFactory factory = new SavingAccountFactory();
		IPayment payment = factory.CreatePayment();

		payment.Credit(100);
		payment.Debit(50);
		Console.WriteLine($"Balance: {payment.GetBalance()}");

		factory = new CreditCardFactory();
		payment = factory.CreatePayment();

		payment.Credit(200);
		payment.Debit(100);
		Console.WriteLine($"Balance: {payment.GetBalance()}");
	}
}
