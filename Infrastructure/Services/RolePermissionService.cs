using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RolePermissionServices
{  
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RolePermissionServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

      public async Task<Response<List<RolePermissionDto>>> GetRolePermission()
   {
        try
        {
            var result = await _context.RolePremissions.ToListAsync();
            var mapped = _mapper.Map<List<RolePermissionDto>>(result);
            return new Response<List<RolePermissionDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<RolePermissionDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<RolePermissionDto>> AddRolePermission(RolePermissionDto role)
    {
        try
        {
            var mapped = _mapper.Map<RolePremission>(role);
           await _context.RolePremissions.AddAsync(mapped);
           await _context.SaveChangesAsync();
           role.Id=mapped.Id;
            return new Response<RolePermissionDto>(role);

        }
        catch (Exception ex)
        {
            return new Response<RolePermissionDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<RolePermissionDto>> UpdateRolePermission(RolePermissionDto role)
    {
        try
        {
            var mapped = _mapper.Map<RolePremission>(role);
            _context.RolePremissions.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<RolePermissionDto>(role);

        }
        catch (Exception ex)
        {
            return new Response<RolePermissionDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    
    public async Task<Response<string>> DeleteRolePermission(int id)
    {
        var find = await _context.RolePremissions.FindAsync(id);
        if (find == null)
            return new Response<string>(HttpStatusCode.NotFound, new List<string> { "Not found" });
        _context.RolePremissions   .Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
    }
}