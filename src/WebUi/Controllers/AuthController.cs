using System;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories.Interfaces;
using WebUi.Dtos;

namespace WebUi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        public AuthController(IUserRepository repository)
        {
            _repository = repository;
        }
        
        [HttpPost("register")]
        public IActionResult Register(RegisterDto dto)
        {
            var user = new User()
            {
                Email = dto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            User result = _repository.Create(user);
            return Created("Success", result);
        }
        
        //TODO finish creating login methon (BCrypt verify problem)
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);
            Console.WriteLine($"Dto {dto.Email} {dto.Password}");
            Console.WriteLine($"User {user.Email} {user.Password}");

            if (user == null)
            {
                return BadRequest(new {message = "Invalid Credentials"});
            }

            if (!BCrypt.Net.BCrypt.Verify(dto.Password, user.Password))
            {
                Console.WriteLine(BCrypt.Net.BCrypt.Verify(dto.Password, user.Password));
                return BadRequest(new {message = "Invalid Credentials"});
            }
            
            return Ok(user);
        }
    }
}