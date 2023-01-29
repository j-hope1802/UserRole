using Infrastructure.Context;
using Domain.Dtos;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.MapperProfiles;
using AutoMapper;
using Domain.Wrapper;
using System.Net;

namespace Infrastructure.Services;
public class UserService
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;
    public UserService(DataContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<RegisterDto>>> GetUsers()
    {
        var mapped = _mapper.Map<List<RegisterDto>>(_context.Users.ToList());
        return new Response<List<RegisterDto>>(mapped);
    }
    public async Task<Response<string>> Login(LoginDto log)
    {
        try
        {
            var result = await _context.Users.FirstOrDefaultAsync(x => (x.FullName == log.FullName) && x.Password == log.Password);
            if (result == null)
                return new Response<string>(HttpStatusCode.BadRequest, new List<string> { "Username or password is incorect" });
            var mapped = _mapper.Map<string>(result);
            return new Response<string>("You are welcome");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.NotFound, new List<string> { ex.Message });
        }

    }
    public async Task<Response<string>> Register(RegisterDto reg)
    {
        try
        {
            var register = await _context.Users.FirstOrDefaultAsync(x => x.Email == reg.Email || x.PhoneNumber == reg.PhoneNumber);
            if (register != null)
                return new Response<string>(HttpStatusCode.BadRequest, new List<string> { "This email or phone is already exist" });
            var mapped = _mapper.Map<User>(reg);
            _context.Users.Add(mapped);
            await _context.SaveChangesAsync();
            reg.Id = reg.Id;
            return new Response<string>("You are succesufyly registered");
        }
        catch (Exception ex)
        {
            return new Response<string>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }

    }

}