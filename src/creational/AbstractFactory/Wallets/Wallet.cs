namespace AbstractFactory.Wallets;

using System;

internal class Wallet : IPayment
{
	public void Credit(decimal amount) => Console.WriteLine($"Credited {amount} to Wallet");
	public void Debit(decimal amount) => Console.WriteLine($"Debited {amount} from Wallet");
	public void Refund(decimal amount) => Console.WriteLine($"Refunded {amount} to Wallet");
	public void Transfer(decimal amount) => Console.WriteLine($"Transferred {amount} from Wallet");
	public decimal GetBalance() => 800; // Example balance
}
