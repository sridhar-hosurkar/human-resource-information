using System.ComponentModel.DataAnnotations;

namespace ServiceModels;

public class Address
{
    public int Id { get; set; }

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
}
