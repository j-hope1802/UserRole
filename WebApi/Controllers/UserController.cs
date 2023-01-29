using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
        private readonly UserService _UserService;

        public UserController(UserService userService)
        {
                _UserService = userService;
        }

        
    [HttpGet("GetUsers")]
    public async Task<Response<List<RegisterDto>>> GetUsers()
    {
        return await _UserService.GetUsers();
    }
        [HttpPost("Register")]
        public async Task<Response<string>>Register([FromForm]RegisterDto user)
        {
            
                 return await  _UserService.Register(user);
        }
    [HttpPost("Login")]
    public async Task<Response<string>> GetLogin([FromForm]LoginDto log)
    {

        return await _UserService.Login(log);
    }
}