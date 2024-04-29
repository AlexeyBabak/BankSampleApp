using DataAccess.Data;
using DataAccess.Models;

namespace BankApp.Services;

public class AccountService
{
    private readonly IAccountData _accountData;
    private readonly TransactionService _transactionService;

    public AccountService(IAccountData accountData, TransactionService transactionService)
    {
        _accountData = accountData;
        _transactionService = transactionService;
    }

    public async Task AddAccount(decimal balance, decimal interestRate, int clientId)
    {
        var newAccount = new AccountModel(balance, interestRate, clientId);

        await _accountData.InsertAccount(newAccount);
    }

    public async Task<IEnumerable<AccountModel>> GetAllAccounts()
    {
        return await _accountData.GetAccounts();
    }

    public async Task<AccountModel?> GetAccountById(int accountId)
    {
        return await _accountData.GetAccount(accountId);
    }

    public async Task UpdateInterestRate(int accountId, decimal interestRate)
    {
        await _accountData.UpdateAccountInterestRate(accountId, interestRate);
    }

    public async Task Deposit(int accountId, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }

        await UpdateBalance(accountId, amount);

        await _transactionService.AddTransaction(amount, TransactionType.Deposit, accountId);
    }

    public async Task Withdrawal(int accountId, decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }

        var currentBalance = await GetAccountBalance(accountId);
        if (currentBalance < amount)
        {
            throw new InvalidOperationException("Not enough funds for withdrawal.");
        }

        await UpdateBalance(accountId, -amount);

        await _transactionService.AddTransaction(amount, TransactionType.Withdrawal, accountId);
    }

    private async Task UpdateBalance(int accountId, decimal amount)
    {
        await _accountData.UpdateAccountBalance(accountId, amount);
    }

    private async Task<decimal> GetAccountBalance(int accountId)
    {
        var account = await GetAccountById(accountId);
        return account == null ? throw new InvalidOperationException("Account not found.") : account.Balance;
    }
}
