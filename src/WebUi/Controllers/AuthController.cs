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
    }
}