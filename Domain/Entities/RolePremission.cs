namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class RolePremission
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int RoleId { get; set; }
    public Role Roles { get; set; }
    [Required]
    public int PremissionId { get; set; }
    public Permission Permissions { get; set; }
    

}