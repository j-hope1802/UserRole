namespace Domain.Dtos;
 using System.ComponentModel.DataAnnotations;
public class RoleDto{
    [Required]
    public int Id{get;set;}
     [Required]
    public string Name{get;set;}
}