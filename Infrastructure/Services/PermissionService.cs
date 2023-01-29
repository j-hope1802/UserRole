using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.MapperProfiles;

namespace Infrastructure.Services;
public class PermissionServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public PermissionServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<PermissionDto>>> GetPermission()
   {
        try
        {
            var result = await _context.Permissions.ToListAsync();
            var mapped = _mapper.Map<List<PermissionDto>>(result);
            return new Response<List<PermissionDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<PermissionDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<PermissionDto>> AddPermission(PermissionDto perm)
    {
        try
        {
            var mapped = _mapper.Map<Permission>(perm);
            await _context.Permissions.AddAsync(mapped);
            await _context.SaveChangesAsync();
            perm.Id = mapped.Id;
            return new Response<PermissionDto>(perm);

        }
        catch (Exception ex)
        {
            return new Response<PermissionDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<PermissionDto>> UpdatePermission(PermissionDto perm)
    {
        try
        {
            var mapped = _mapper.Map<Permission>(perm);
            _context.Permissions.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<PermissionDto>(perm);

        }
        catch (Exception ex)
        {
            return new Response<PermissionDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeletePermission(int id)
    {
        var find = await _context.Permissions.FindAsync(id);
        if (find == null)
            return new Response<string>(HttpStatusCode.NotFound, new List<string> { "Not found" });
        _context.Permissions.Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
    }
}