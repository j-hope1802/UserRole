namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class UserRoles{
        [Required]
    public int Id{get;set;}
        [Required]
    public int UserId{get;set;}
    public User Users{get;set;}
        [Required]
    public int RoleId{get;set;}
    public Role Roles{get;set;}
}