namespace Domain.Dtos;
using System.ComponentModel.DataAnnotations;
public class UserRoleDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int UserId { get; set; }
    [Required]
    public int RoleId { get; set; }
}