using BankApp.Services;

namespace BankApp;

public class DisplayWorkflow
{
    private readonly ClientService clientService;
    private readonly AccountService accountService;
    private readonly TransactionService transactionService;

    public DisplayWorkflow(ClientService clientService, AccountService accountService, TransactionService transactionService)
    {
        this.clientService = clientService;
        this.accountService = accountService;
        this.transactionService = transactionService;
    }

    public async Task ShowAllClients()
    {
        try
        {
            Console.WriteLine("Showing all clients in the bank:");
            var clients = await clientService.GetAllClients();
            foreach (var client in clients)
            {
                Console.WriteLine($"Client: {client.FirstName} {client.LastName}, Verified: {client.IsVerified}");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while displaying clients: {ex.Message}");
        }
    }

    public async Task ShowAllAccounts()
    {
        try
        {
            Console.WriteLine("Showing all accounts in the bank:");
            var accounts = await accountService.GetAllAccounts();
            foreach (var account in accounts)
            {
                Console.WriteLine($"AccountID: {account.aId} - Balance: {account.Balance}");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while displaying accounts: {ex.Message}");
        }
    }

    public async Task ShowClientAccounts(int clientId)
    {
        try
        {
            var client = await clientService.GetClientById(clientId);
            if (client == null)
            {
                Console.WriteLine("Client not found.");
                return;
            }

            Console.WriteLine($"Client: {client.FirstName} {client.LastName}, Verified: {client.IsVerified}");
            Console.WriteLine("Accounts:");
            var accounts = await accountService.GetAccountsByClientId(client.cId);
            foreach (var account in accounts)
            {
                Console.WriteLine($"AccountID: {account.aId} - Balance: {account.Balance}");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while displaying client accounts: {ex.Message}");
        }
    }

    public async Task ShowAccountTransactions(int accountId)
    {
        try
        {
            Console.WriteLine($"Transactions for Account ID: {accountId}");
            var transactions = await transactionService.GetTransactionsByAccount(accountId);
            if (transactions.Any())
            {
                foreach (var transaction in transactions)
                {
                    Console.WriteLine($"Transaction Date: {transaction.TransactionDate}, Type: {transaction.TransactionType}, Amount: {transaction.Amount}");
                }
            }
            else
            {
                Console.WriteLine("No transactions found for this account.");
            }
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while displaying transactions for account ID {accountId}: {ex.Message}");
        }
    }
}
