namespace Domain.Dtos;
using System.ComponentModel.DataAnnotations;
public class RegisterDto
{
    public int Id { get; set; }
    [Required, MaxLength(50)]
    public string FullName { get; set; }
    [Required, MaxLength(50)]
    [DataType(DataType.EmailAddress)]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string PhoneNumber { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [MaxLength(12, ErrorMessage = "Must be between 5 and 12")]
    [DataType(DataType.Password)]
    public string Password { get; set; }
    [Required(ErrorMessage = "Confirm password is required")]
    [MaxLength(12, ErrorMessage = "Must be between 5 and 12")]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
}