namespace FactoryMethod;

using FactoryMethod.Account;
using FactoryMethod.AccountStore;
using Microsoft.Extensions.DependencyInjection;

internal class Program
{
    static void Main()
    {
        InvokeFactoryMethodPatternUsingTraditionalObjectCreation();

        InvokeFactoryMethodPatternUsingDependencyInjection();
    }

    private static void InvokeFactoryMethodPatternUsingTraditionalObjectCreation()
    {
        Console.WriteLine("Factory Method Pattern Using Traditional Object Creation");

        //create a account store, this will be your persistance storage.
        IAccountStore accountStore = new AccountStore.AccountStore();

        //create a factory that works with a partibular type of store.
        var accountFactory = new AccountFactory.AccountFactory(accountStore);

        //ask the factory to create saving & current account.
        var savingAccount = accountFactory.GetAccount(AccountType.Saving);
        var currentAccount = accountFactory.GetAccount(AccountType.Current);

        //save these instances in store.
        accountStore.CreateAccount(savingAccount);
        accountStore.CreateAccount(currentAccount);

        //Perform some operations
        savingAccount.Deposit(1000);
        savingAccount.Withdraw(500);
        Console.WriteLine($"Saving account Number {savingAccount.Number} Balance: {savingAccount.GetBalance()}");

        currentAccount.Deposit(1500);
        currentAccount.Withdraw(700);
        Console.WriteLine($"Current account Number {currentAccount.Number} Balance: {currentAccount.GetBalance()}");
    }

    private static void InvokeFactoryMethodPatternUsingDependencyInjection()
    {
        Console.WriteLine("Factory Method Pattern Using Dependency Injection");

        //create a service collection and register the types.
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddTransient<SavingAccount>();
        serviceCollection.AddTransient<CurrentAccount>();
        serviceCollection.AddSingleton<IAccountStore, AccountStore.AccountStore>();

        //create a service provider
        var serviceProvider = serviceCollection.BuildServiceProvider();

        //create account store, this will be your persistance storage.
        IAccountStore accountStore =  serviceProvider.GetRequiredService<IAccountStore>();

        //create a factory that works with a particular type of store.
        var accountFactory = new AccountFactory.AccountFactoryServiceProvider(serviceProvider);

        //ask the factory to create saving & current account.
        var savingAccount = accountFactory.GetAccount(AccountType.Saving);
        var currentAccount = accountFactory.GetAccount(AccountType.Current);

        //save these instances in store.
        accountStore.CreateAccount(savingAccount);
        accountStore.CreateAccount(currentAccount);

        //Perform some operations
        savingAccount.Deposit(1000);
        savingAccount.Withdraw(500);
        Console.WriteLine($"Saving account Number {savingAccount.Number} Balance: {savingAccount.GetBalance()}");

        currentAccount.Deposit(1500);
        currentAccount.Withdraw(700);
        Console.WriteLine($"Current account Number {currentAccount.Number} Balance: {currentAccount.GetBalance()}");
    }
}
