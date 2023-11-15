using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DomainModels;

public class User : BaseDomainModel
{
    [Required]
    [RegularExpression(
        @"^[a-zA-Z]+$",
        ErrorMessage = "Numbers and special characters are not allowed"
    )]
    public string FirstName { get; set; }

    [Required]
    [RegularExpression(
        @"^[a-zA-Z]+$",
        ErrorMessage = "Numbers and Special Characters are not allowed."
    )]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }

    [Required(ErrorMessage = "Mobile no. is required")]
    [RegularExpression(
        "^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$",
        ErrorMessage = "Please enter valid phone no."
    )]
    public string Phone { get; set; }

    public ICollection<Address> Addresses {get; set;}
}
