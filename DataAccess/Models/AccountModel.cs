using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;
public class AccountModel
{
    public int Id { get; set; }

    [Required]
    [DataType(DataType.Currency)]
    public decimal Balance { get; set; }

    [Required]
    [Range(0.00, 100.00, ErrorMessage = "Interest rate must be between 0.00% and 100.00%")]
    public decimal InterestRate { get; set; }

    [Required]
    public int ClientId { get; set; }

    public ClientModel Client { get; set; }

    public AccountModel(decimal balance, decimal interestRate, int clientId)
    {
        if (balance < 0)
            throw new ArgumentException("Balance cannot be negative.", nameof(balance));
        if (interestRate < 0 || interestRate > 100)
            throw new ArgumentException("Interest rate must be between 0.00% and 100.00%", nameof(interestRate));
        if (clientId <= 0)
            throw new ArgumentException("Client ID must be a positive integer", nameof(clientId));

        Balance = balance;
        InterestRate = interestRate;
        ClientId = clientId;
    }
}
