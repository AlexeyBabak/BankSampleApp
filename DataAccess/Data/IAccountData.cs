using DataAccess.Models;

namespace DataAccess.Data;
public interface IAccountData
{
    Task<AccountModel?> GetAccount(int accountId);
    Task<IEnumerable<AccountModel>> GetAccounts();
    Task<IEnumerable<AccountModel>> GetAccountsByClient(int clientId);
    Task InsertAccount(AccountModel account);
    Task UpdateAccountBalance(int accountId, decimal amount);
    Task UpdateAccountInterestRate(int accountId, decimal interestRate);
}