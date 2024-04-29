using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;
public class TransactionModel
{
    public int Id { get; set; }

    [Required]
    public DateTime TransactionDate { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal Amount { get; set; }

    [Required]
    [ForeignKey("TransactionType")]
    public TransactionType TransactionType { get; set; }

    [Required]
    public int AccountId { get; set; }

    public virtual AccountModel Account { get; set; }

    public TransactionModel(DateTime transactionDate, decimal amount, TransactionType transactionType, int accountId)
    {
        TransactionDate = transactionDate;
        Amount = amount;
        TransactionType = transactionType;
        AccountId = accountId;
    }
}

public enum TransactionType { Deposit, Withdrawal, Transfer }