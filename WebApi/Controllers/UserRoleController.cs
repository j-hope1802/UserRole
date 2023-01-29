using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class UserRoleController
{
    private readonly UserRoleServices _UserRoleService;

    public UserRoleController(UserRoleServices userService)
    {
        _UserRoleService = userService;
    }
    
    [HttpGet]
    public async Task<Response<List<UserRoleDto>>> GetUsers()
    {
        return  await _UserRoleService.GetUserRole();
    }
    [HttpPost("ADD")]
    public async Task<Response<UserRoleDto>> Add(UserRoleDto register)
    {
        return await _UserRoleService.AddUserRole(register);
    }
    [HttpPut("Update")]
    public async Task<Response<UserRoleDto>> Update(UserRoleDto userRoleDto)
    {
        return await _UserRoleService.UpdateUserRole(userRoleDto);
    }
 [HttpDelete("Delete")]
      public async Task<Response<string>> Delete(int id)
    {
        return await _UserRoleService.DeleteUserRole(id);
    }

   
   
    
}