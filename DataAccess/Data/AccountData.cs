using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class AccountData : IAccountData
{
    private readonly ISqlDataAccess _dataAccess;

    public AccountData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task InsertAccount(AccountModel account) =>
    _dataAccess.SaveData(
        "dbo.spAccount_Insert",
        new { account.Balance, account.InterestRate, account.ClientId });

    public Task<IEnumerable<AccountModel>> GetAccounts() =>
        _dataAccess.LoadData<AccountModel, dynamic>("dbo.spAccount_GetAll", new { });

    public async Task<AccountModel?> GetAccount(int accountId)
    {
        var results = await _dataAccess.LoadData<AccountModel, dynamic>(
            "dbo.spAccount_Get",
            new { AccountId = accountId });

        return results.FirstOrDefault();
    }

    public Task<IEnumerable<AccountModel>> GetAccountsByClient(int clientId) =>
        _dataAccess.LoadData<AccountModel, dynamic>(
            "dbo.spAccount_GetByClient",
            new { ClientId = clientId });

    public Task UpdateAccountBalance(int accountId, decimal amount) =>
        _dataAccess.SaveData(
            "dbo.spAccount_UpdateBalance",
            new { AccountId = accountId, Amount = amount });

    public Task UpdateAccountInterestRate(int accountId, decimal interestRate) =>
        _dataAccess.SaveData(
            "dbo.spAccount_UpdateInterestRate",
            new { AccountId = accountId, InterestRate = interestRate });
}
