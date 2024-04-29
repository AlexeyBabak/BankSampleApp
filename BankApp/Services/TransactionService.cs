using DataAccess.Data;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services;

public class TransactionService
{
    private readonly TransactionData _transactionData;

    public TransactionService(TransactionData transactionData)
    {
        _transactionData = transactionData;
    }

    public async Task AddTransaction(decimal amount, TransactionType transactionType, int accountId)
    {
        var transactionDate = DateTime.UtcNow;
        var newTransaction = new TransactionModel(transactionDate, amount, transactionType, accountId);
        await _transactionData.InsertTransaction(newTransaction);
    }

    public async Task<TransactionModel?> GetTransactionById(int transactionId)
    {
        return await _transactionData.GetTransactionById(transactionId);
    }

    public async Task<IEnumerable<TransactionModel>> GetAllTransactions()
    {
        return await _transactionData.GetAllTransactions();
    }

    public async Task<IEnumerable<TransactionModel>> GetTransactionsByAccount(int accountId)
    {
        return await _transactionData.GetTransactionsByAccount(accountId);
    }
}
