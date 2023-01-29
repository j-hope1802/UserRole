using System.Net;
namespace WebApi.Controllers;

using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class RolePermissionController
{
    private readonly RolePermissionServices _RolePermissionService;

    public RolePermissionController(RolePermissionServices permissionService)
    {
        _RolePermissionService = permissionService;
    }

    [HttpGet("GetRolePermissons")]
    public async Task<Response<List<RolePermissionDto>>> GetRolePermisson()
    {
        return await _RolePermissionService.GetRolePermission();
    }
    [HttpPost("AddRolePermisson")]
    public async Task<Response<RolePermissionDto>> AddRolePermisson(RolePermissionDto register)
    {
        return await _RolePermissionService.AddRolePermission(register);
    }
    [HttpPut("UpdateRolePermisson")]
    public async Task<Response<RolePermissionDto>> UpdateRolePermisson(RolePermissionDto RolePermission)
    {
        return await _RolePermissionService.UpdateRolePermission(RolePermission);
    }
      [HttpDelete("Delete Role")]
    public async Task<Response<string>> Delete(int id)
    {
        return await _RolePermissionService.DeleteRolePermission(id);
    }

   



}