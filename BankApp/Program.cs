using BankApp;
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

        var bankingWorkflow = new BankingWorkflow(clientService, accountService, transactionService);
        await bankingWorkflow.Run();

        // Show the data:
        var displayService = new DisplayWorkflow(clientService, accountService, transactionService);

        await displayService.ShowAllClients();
        await displayService.ShowAllAccounts();

        await displayService.ShowClientAccounts(2); // set this
        await displayService.ShowAccountTransactions(1); // set this

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
