namespace Domain.Dtos;
using System.ComponentModel.DataAnnotations;
public class PermissionDto{
    public int Id{get;set;}
        [Required]
    public string Name{get;set;}
}