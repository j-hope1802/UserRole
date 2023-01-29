namespace Domain.Dtos;
using System.ComponentModel.DataAnnotations;
public class RolePermissionDto
{
    [Required]
    public int Id { get; set; }
     [Required]
    public int RoleId { get; set; }
     [Required]
    public int PremissionId { get; set; }


}