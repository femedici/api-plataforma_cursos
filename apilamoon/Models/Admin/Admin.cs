using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MainProfiles.Models;

public class Admin
{
    public int Id {get; set;}
    public string? Email {get; set;}
    public string? Password {get; set;}
}