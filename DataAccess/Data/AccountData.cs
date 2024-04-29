using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class AccountData
{
    private readonly ISqlDataAccess _dataAccess;

    public AccountData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task InsertAccount(AccountModel account) =>
    _dataAccess.SaveData("dbo.spAccount_Insert", new { account.Balance, account.InterestRate, account.ClientId });
}
