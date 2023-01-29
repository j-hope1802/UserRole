namespace Domain.Dtos;
using System.ComponentModel.DataAnnotations;
public class LoginDto
{
   
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Password { get; set; }
}