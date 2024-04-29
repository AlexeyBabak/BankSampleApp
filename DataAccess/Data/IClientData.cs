using DataAccess.Models;

namespace DataAccess.Data;
public interface IClientData
{
    Task DeleteClient(int id);
    Task<ClientModel?> GetClient(int id);
    Task<IEnumerable<ClientModel>> GetClients();
    Task InsertClient(ClientModel client);
}