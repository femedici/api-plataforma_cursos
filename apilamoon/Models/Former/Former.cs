using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MainProfiles.Models;

public class Former
{
    public int Id {get; set;}
    public string? Name {get; set;}
    public string? Email {get; set;}
    public string? Password {get; set;}
}