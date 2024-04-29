using DataAccess.DbAccess;
using DataAccess.Models;

namespace DataAccess.Data;
public class TransactionData : ITransactionData
{
    private readonly ISqlDataAccess _dataAccess;

    public TransactionData(ISqlDataAccess dataAccess)
    {
        _dataAccess = dataAccess;
    }

    public Task InsertTransaction(TransactionModel transaction) =>
        _dataAccess.SaveData(
            "dbo.spTransaction_Insert",
            new
            {
                transaction.TransactionDate,
                transaction.Amount,
                TransactionType = (int)transaction.TransactionType,
                transaction.AccountId
            });

    public async Task<TransactionModel?> GetTransactionById(int transactionId)
    {
        var results = await _dataAccess.LoadData<TransactionModel, dynamic>(
            "dbo.spTransaction_Get",
            new { TransactionId = transactionId });

        return results.FirstOrDefault();
    }

    public Task<IEnumerable<TransactionModel>> GetAllTransactions() =>
        _dataAccess.LoadData<TransactionModel, dynamic>(
            "dbo.spTransaction_GetAll",
            new { });

    public Task<IEnumerable<TransactionModel>> GetTransactionsByAccount(int accountId) =>
        _dataAccess.LoadData<TransactionModel, dynamic>(
            "dbo.spTransaction_GetByAccount",
            new { AccountId = accountId });
}
