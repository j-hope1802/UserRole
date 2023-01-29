using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserRoleServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserRoleServices(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

       public async Task<Response<List<UserRoleDto>>> GetUserRole()
  {
        try
        {
            var result = await _context.Roles.ToListAsync();
            var mapped = _mapper.Map<List<UserRoleDto>>(result);
            return new Response<List<UserRoleDto>>(mapped);
        }
        catch (Exception ex)
        {

            return new Response<List<UserRoleDto>>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<UserRoleDto>> AddUserRole(UserRoleDto usr)
    {
        try
        {
            var mapped = _mapper.Map<UserRoles>(usr);
           await _context.UserRoles.AddAsync(mapped);
           await _context.SaveChangesAsync();
           usr.Id=mapped.Id;
            return new Response<UserRoleDto>(usr);

        }
        catch (Exception ex)
        {
            return new Response<UserRoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<UserRoleDto>> UpdateUserRole(UserRoleDto usr)
    {
        
        try
        {
            var poisk = _context.UserRoles.FirstOrDefaultAsync(x => x.Id == usr.Id);
            var mapped = _mapper.Map<UserRoles>(usr);
            _context.UserRoles.Update(mapped);
            await _context.SaveChangesAsync();
            return new Response<UserRoleDto>(usr);

        }
        catch (Exception ex)
        {
            return new Response<UserRoleDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }

    public async Task<Response<string>> DeleteUserRole(int id)
    {
        var find = await _context.UserRoles.FindAsync(id);
        if (find == null)
            return new Response<string>(HttpStatusCode.NotFound, new List<string> { "Not found" });
        _context.UserRoles.Remove(find);
        _context.SaveChangesAsync();
        return new Response<string>("Sucessfully");
    }

}