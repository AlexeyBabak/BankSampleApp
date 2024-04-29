using BankApp.Services;
using DataAccess.Data;
using DataAccess.DbAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

class Program
{
    static async Task Main(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        var clientService = host.Services.GetRequiredService<ClientService>();
        var accountService = host.Services.GetRequiredService<AccountService>();
        var transactionService = host.Services.GetRequiredService<TransactionService>();

        // Create and set first Client
        await clientService.AddClient("John", "Doe", true);

        var firstClient = await clientService.GetClientById(2);
        if (firstClient != null)
        {
            await accountService.AddAccount(1000, 1.5M, firstClient.Id);
            await accountService.AddAccount(5000, 2.0M, firstClient.Id);
        }
        else
        {
            Console.WriteLine("No clients found to add accounts.");
        }

        var account1 = await accountService.GetAccountById(1);
        if (account1 != null)
        {
            await accountService.UpdateInterestRate(1, 5.0M);
        }
        else
        {
            Console.WriteLine("No such account to update interest rate.");
        }

        if (account1 != null)
        {
            await accountService.Deposit(1,1000M);
        }
        else
        {
            Console.WriteLine("No such account.");
        }

        var account2 = await accountService.GetAccountById(2);
        if (account2 != null)
        {
            await accountService.Withdrawal(2, 1000M);
        }
        else
        {
            Console.WriteLine("No such account.");
        }

        await host.RunAsync();
    }

    static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((context, services) =>
        {
            services.AddSingleton<IConfiguration>(provider => new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build());
            services.AddTransient<ISqlDataAccess, SqlDataAccess>();

            services.AddTransient<IClientData, ClientData>();
            services.AddTransient<IAccountData, AccountData>();
            services.AddTransient<ITransactionData, TransactionData>();

            services.AddTransient<ClientService>();
            services.AddTransient<AccountService>();
            services.AddTransient<TransactionService>();
        });
}
