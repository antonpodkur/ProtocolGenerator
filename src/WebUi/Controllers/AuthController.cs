using System;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories.Interfaces;
using WebUi.Dtos;
using BC = BCrypt.Net.BCrypt;


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
                Password = BC.HashPassword(dto.Password)
            };

            User result = _repository.Create(user);
            return Created("Success", result);
        }
        
        //TODO finish creating login methon (BCrypt verify problem)
        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _repository.GetByEmail(dto.Email);

            if (user == null)
            {
                return BadRequest(new {message = "Invalid Credentials"});
            }

            if (!BC.Verify(dto.Password, user.Password))
            {
                Console.WriteLine(BC.Verify(dto.Password.ToString(), user.Password));
                return BadRequest(new {message = "Invalid Credentials"});
            }
            
            return Ok(user);
        }
    }
}