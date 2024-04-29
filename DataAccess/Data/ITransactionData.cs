using DataAccess.Models;

namespace DataAccess.Data;
public interface ITransactionData
{
    Task<IEnumerable<TransactionModel>> GetAllTransactions();
    Task<TransactionModel?> GetTransactionById(int transactionId);
    Task<IEnumerable<TransactionModel>> GetTransactionsByAccount(int accountId);
    Task InsertTransaction(TransactionModel transaction);
}