using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class RoleServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public RoleServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<RoleDto>>> GetRole()
  {
        try
        {
            var result = await _context.Roles.ToListAsync();
            var mapped = _mapper.Map<List<RoleDto>>(result);
            return new Response<List<RoleDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<RoleDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<RoleDto>> AddRole(RoleDto role)
    {
        try
        {
            var mapped = _mapper.Map<Role>(role);
           await _context.Roles.AddAsync(mapped);
           await _context.SaveChangesAsync();
           role.Id=mapped.Id;
            return new Response<RoleDto>(role);

        }
        catch (Exception ex)
        {
            return new Response<RoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<RoleDto>> UpdateRole(RoleDto role)
    {
        try
        {
            var mapped = _mapper.Map<Role>(role);
            _context.Roles.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<RoleDto>(role);

        }
        catch (Exception ex)
        {
            return new Response<RoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

       public async Task<Response<string>> DeleteRole(int id)
    {
        var find = await _context.Permissions.FindAsync(id);
        if (find == null)
            return new Response<string>(HttpStatusCode.NotFound, new List<string> { "Not found" });
        _context.Permissions.Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
    }
}