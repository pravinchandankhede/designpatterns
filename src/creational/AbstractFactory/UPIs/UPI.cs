namespace AbstractFactory.UPIs;

using System;

internal class Upi : IPayment
{
	public void Credit(decimal amount) => Console.WriteLine($"Credited {amount} to UPI");
	public void Debit(decimal amount) => Console.WriteLine($"Debited {amount} from UPI");
	public void Refund(decimal amount) => Console.WriteLine($"Refunded {amount} to UPI");
	public void Transfer(decimal amount) => Console.WriteLine($"Transferred {amount} from UPI");
	public decimal GetBalance() => 1500; // Example balance
}
