using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace MainProfiles.Models;

public class Admin
{
    public int? id {get; set;}
    public string? email {get; set;}
    public string? password {get; set;}
}