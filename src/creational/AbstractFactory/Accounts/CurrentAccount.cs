namespace AbstractFactory.Accounts;

using System;

internal class CurrentAccount : IPayment
{
	public void Credit(decimal amount) => Console.WriteLine($"Credited {amount} to Current Account");
	public void Debit(decimal amount) => Console.WriteLine($"Debited {amount} from Current Account");
	public void Refund(decimal amount) => Console.WriteLine($"Refunded {amount} to Current Account");
	public void Transfer(decimal amount) => Console.WriteLine($"Transferred {amount} from Current Account");
	public decimal GetBalance() => 2000; // Example balance
}
