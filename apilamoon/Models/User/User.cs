using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MainProfiles.Models;

public class User
{
    public int? id {get; set;}
    [Required]
    public string? Name {get; set;}
     [Required]
    public string? email {get; set;}
     [Required]
    public string? password {get; set;}
}