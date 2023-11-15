using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DomainModels;

public class Address : BaseDomainModel
{
    [Required]
    public string DoorNo { get; set; }

    [Required]
    public string StreetName { get; set; }

    [Required]
    public string City { get; set; }

    [Required]
    public string State { get; set; }

    [Required]
    public string Country { get; set; }

    [Required]
    public int PostCode { get; set; }

    [ForeignKey("UserId")]
    public User User { get; set; }
    public int UserId { get; set; }
}
