namespace AbstractFactory.Cards;

using System;

internal class CreditCard : IPayment
{
	public void Credit(decimal amount) => Console.WriteLine($"Credited {amount} to Credit Card");
	public void Debit(decimal amount) => Console.WriteLine($"Debited {amount} from Credit Card");
	public void Refund(decimal amount) => Console.WriteLine($"Refunded {amount} to Credit Card");
	public void Transfer(decimal amount) => Console.WriteLine($"Transferred {amount} from Credit Card");
	public decimal GetBalance() => 5000; // Example balance
}
