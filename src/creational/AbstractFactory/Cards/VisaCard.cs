namespace AbstractFactory.Cards;

internal class Visa : IPayment
{
	public void Credit(decimal amount) => Console.WriteLine($"Credited {amount} to Visa");
	public void Debit(decimal amount) => Console.WriteLine($"Debited {amount} from Visa");
	public void Refund(decimal amount) => Console.WriteLine($"Refunded {amount} to Visa");
	public void Transfer(decimal amount) => Console.WriteLine($"Transferred {amount} from Visa");
	public decimal GetBalance() => 3000; // Example balance
}
