using DataAccess.Data;
using DataAccess.Models;

namespace BankApp.Services;

public class ClientService
{
    private readonly IClientData _clientData;

    public ClientService(IClientData clientData)
    {
        _clientData = clientData;
    }

    public async Task AddClient(string firstName, string lastName, bool isVerified)
    {
        var newClient = new ClientModel(firstName, lastName, isVerified);

        await _clientData.InsertClient(newClient);
    }

    public async Task<IEnumerable<ClientModel>> GetAllClients()
    {
        return await _clientData.GetClients();
    }

    public async Task<ClientModel?> GetClientById(int id)
    {
        return await _clientData.GetClient(id);
    }
}
