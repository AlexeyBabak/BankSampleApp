using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models;

public class ClientModel
{
    public int Id { get; set; }

    [Required]
    [StringLength(50)]
    public string? FirstName { get; set; }
    
    [Required]
    [StringLength(50)]
    public string? LastName { get; set; }

    public bool IsVerified { get; set; } 
}
