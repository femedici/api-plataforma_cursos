using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MainProfiles.Models;

public class User
{
    public int Id {get; set;}
    [Required]
    public string? Name {get; set;}
     [Required]
    public string? Email {get; set;}
     [Required]
    public string? Password {get; set;}
}