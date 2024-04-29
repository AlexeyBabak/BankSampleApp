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

        //Console.WriteLine("Adding a new client...");
        //await clientService.AddClient("John", "Doe", true);

        Console.WriteLine("Listing all clients:");
        var clients = await clientService.GetAllClients();
        foreach (var client in clients)
        {
            Console.WriteLine($"{client.FirstName} {client.LastName} - Verified: {client.IsVerified}");
        }

        var firstClient = await clientService.GetClientById(1);
        Console.WriteLine($"{firstClient.FirstName} {firstClient.LastName} - Verified: {firstClient.IsVerified}");

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

            services.AddTransient<ClientService>();
        });
}
