namespace AbstractFactory;

using AbstractFactory.Accounts;
using AbstractFactory.Cards;
using Microsoft.Extensions.DependencyInjection;
using System;

internal class ProgramDependencyInjection
{
	static void Main()
	{
		// Create a service collection
		var services = new ServiceCollection();
		// Register the IPaymentFactory and its implementations
		services.AddTransient<IPaymentFactory, SavingAccountFactory>();
		//services.AddTransient<IPaymentFactory, CreditCardFactory>();

		// Register the IPayment and its implementations
		services.AddTransient<IPayment, SavingAccount>();
		services.AddTransient<IPayment, CurrentAccount>();
		
		//services.AddTransient<IPayment, CreditCard>();
		//services.AddTransient<IPayment, Visa>();

		// Build the service provider
		var serviceProvider = services.BuildServiceProvider();

		// Resolve the IPaymentFactory
		var factory = serviceProvider.GetService<IPaymentFactory>();

		if (factory != null)
		{
			var payment = factory.CreatePayment();
			payment.Credit(100);
			payment.Debit(50);
			Console.WriteLine($"Balance: {payment.GetBalance()}");
		}
	}
}
