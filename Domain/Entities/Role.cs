namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Role{
        [Required]
    public int Id{get;set;}
        [Required]
    public string Name{get;set;}
    public List<UserRoles>UserRoles{get;set;}
        public List<RolePremission>RolePremissions{get;set;}
}