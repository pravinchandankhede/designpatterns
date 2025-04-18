namespace AbstractFactory.Accounts;
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

internal class AccountFactory : IPaymentFactory
{
	public IPayment CreatePayment() => new Accounts.SavingAccount();
}

namespace AbstractFactory.Factories
	{
		

		internal class CurrentAccountFactory : IPaymentFactory
		{
			public IPayment CreatePayment() => new Accounts.CurrentAccount();
		}

		internal class CreditCardFactory : IPaymentFactory
		{
			public IPayment CreatePayment() => new Accounts.CreditCard();
		}

		internal class VisaFactory : IPaymentFactory
		{
			public IPayment CreatePayment() => new Accounts.Visa();
		}

		internal class UpiFactory : IPaymentFactory
		{
			public IPayment CreatePayment() => new Accounts.Upi();
		}

		internal class WalletFactory : IPaymentFactory
		{
			public IPayment CreatePayment() => new Accounts.Wallet();
		}
	}
}
