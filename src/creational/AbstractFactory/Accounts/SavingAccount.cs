namespace AbstractFactory.Accounts;

using System;

internal class SavingAccount : IPayment
{
	public void Credit(decimal amount) => Console.WriteLine($"Credited {amount} to Saving Account");
	public void Debit(decimal amount) => Console.WriteLine($"Debited {amount} from Saving Account");
	public void Refund(decimal amount) => Console.WriteLine($"Refunded {amount} to Saving Account");
	public void Transfer(decimal amount) => Console.WriteLine($"Transferred {amount} from Saving Account");
	public decimal GetBalance() => 1000; // Example balance
}
