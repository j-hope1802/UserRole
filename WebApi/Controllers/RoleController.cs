using System.Web;
using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class RoleController
{
    private readonly RoleServices _RoleService;

    public RoleController(RoleServices roleService)
    {
        _RoleService = roleService;
    }
    
    [HttpGet]
    public async Task<Response<List<RoleDto>>> GetUsers()
    {
        return  await _RoleService.GetRole();
    }
    [HttpPost("AddRole")]
    public async Task<Response<RoleDto>> AddRole(RoleDto register)
    {
        return await _RoleService.AddRole(register);
    }
    [HttpPut("UpdateRole")]
    public async Task<Response<RoleDto>> UpdateRole(RoleDto role)
    {
        return await _RoleService.UpdateRole(role);
    }
       [HttpDelete("Delete Role")]
    public async Task<Response<string>> Delete(int id)
    {
        return await _RoleService.DeleteRole(id);
    }

   
   
    
}