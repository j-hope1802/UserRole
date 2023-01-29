namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class User{
    public int Id{get;set;}
    [Required,MaxLength(50)]
    public string FullName{get;set;}
        [Required,MaxLength(50)]
    public string Email{get;set;}
       [Required,MaxLength(50)]
    public string PhoneNumber{get;set;}
       [Required,MaxLength(50)]
    public string Password{get;set;}
       [Required,MaxLength(50)]
    public string ConfirmPassword{get;set;}
    public List<UserRoles>UserRoles{get;set;}
}