namespace AbstractFactory;

internal interface IPayment
{
	void Credit(System.Decimal amount);
	void Debit(System.Decimal amount);
	void Refund(System.Decimal amount);
	void Transfer(System.Decimal amount);
	System.Decimal GetBalance();
}
