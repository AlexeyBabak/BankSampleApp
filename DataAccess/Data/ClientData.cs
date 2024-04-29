using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class ClientData : IClientData
{
    private readonly ISqlDataAccess _dataAccess;

    public ClientData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task<IEnumerable<ClientModel>> GetClients() =>
        _dataAccess.LoadData<ClientModel, dynamic>("dbo.spClient_GetAll", new { });

    public async Task<ClientModel?> GetClient(int id)
    {
        var results = await _dataAccess.LoadData<ClientModel, dynamic>(
            "dbo.spClient_Get",
            new { ClientId = id });

        return results.FirstOrDefault();
    }

    public Task InsertClient(ClientModel client) =>
        _dataAccess.SaveData("dbo.spClient_Insert", new { client.FirstName, client.LastName, client.IsVerified });

    public Task DeleteClient(int id) =>
        _dataAccess.SaveData("dbo.spClient_Get", new { ClientId = id });
}
