using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;
public class ClientModel
{
    public int cId { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }
    
    [StringLength(50)]
    public string? LastName { get; set; }

    public bool IsVerified { get; set; }

    public ClientModel() { }

    public ClientModel(string firstName, string lastName, bool isVerified)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name must not be null or whitespace.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name must not be null or whitespace.", nameof(lastName));


        FirstName = firstName;
        LastName = lastName;
        IsVerified = isVerified;
    }
}
