using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
namespace Infrastructure.MapperProfiles;
 public class InfrastructureProfile:Profile
 {
    public InfrastructureProfile()
    {
        CreateMap<LoginDto,User>().ReverseMap();
        CreateMap<RegisterDto,User>().ReverseMap();
        CreateMap<RoleDto,Role>().ReverseMap();
            CreateMap<UserRoles,UserRoleDto>().ReverseMap();
            CreateMap<Permission,PermissionDto>().ReverseMap();
            CreateMap<RolePremission,RolePermissionDto>().ReverseMap();
    }
 }