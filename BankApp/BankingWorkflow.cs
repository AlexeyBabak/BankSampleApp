using BankApp.Services;
using DataAccess.Models;

namespace BankApp;

public class BankingWorkflow
{
    private readonly ClientService clientService;
    private readonly AccountService accountService;
    private readonly TransactionService transactionService;

    public BankingWorkflow(ClientService clientService, AccountService accountService, TransactionService transactionService)
    {
        this.clientService = clientService;
        this.accountService = accountService;
        this.transactionService = transactionService;
    }

    public async Task Run()
    {
        await CreateAndSetClient();
        await ProcessAccounts();
    }

    private async Task CreateAndSetClient()
    {
        await clientService.AddClient("John", "Doe", true);
        var clients = await clientService.GetAllClients();
        var firstClient = clients.FirstOrDefault(c => c.FirstName == "John" && c.LastName == "Doe");

        if (firstClient == null)
        {
            Console.WriteLine("No clients found to add accounts.");
            return;
        }

        await accountService.AddAccount(1000, 1.5M, firstClient.cId);
        await accountService.AddAccount(5000, 2.0M, firstClient.cId);
    }

    private async Task ProcessAccounts()
    {
        var clients = await clientService.GetAllClients();
        var firstClient = clients.FirstOrDefault(c => c.FirstName == "John" && c.LastName == "Doe");
        if (firstClient == null) return;

        var accounts = await accountService.GetAccountsByClientId(firstClient.cId);
        if (accounts.Count() < 2)
        {
            Console.WriteLine("Not enough accounts to process.");
            return;
        }

        var firstTwoAccounts = accounts.Take(2).ToList();
        var account1 = firstTwoAccounts[0];
        var account2 = firstTwoAccounts[1];

        await PerformAccountOperations(account1, account2);
    }

    private async Task PerformAccountOperations(AccountModel account1, AccountModel account2)
    {
        await accountService.UpdateInterestRate(account1.aId, 5.0M);
        await accountService.Deposit(account1.aId, 1000M);
        await accountService.Withdrawal(account2.aId, 1000M);
        await accountService.Transfer(account1.aId, account2.aId, 200M);
    }
}
