namespace FactoryMethod;

using FactoryMethod.AccountStore;

internal class Program
{
    static void Main()
    {
        IAccountStore accountStore = new AccountStore.AccountStore();

        var accountFactory = new AccountFactory.AccountFactory(accountStore);

        var savingAccount = accountFactory.GetAccount(AccountType.Saving);
        var currentAccount = accountFactory.GetAccount(AccountType.Current);

        accountStore.CreateAccount(savingAccount);
        accountStore.CreateAccount(currentAccount);

        savingAccount.Deposit(1000);
        savingAccount.Withdraw(500);
        Console.WriteLine($"Saving account balance: {savingAccount.GetBalance()}");

        currentAccount.Deposit(1500);
        currentAccount.Withdraw(700);
        Console.WriteLine($"Current account balance: {currentAccount.GetBalance()}");
    }
}
