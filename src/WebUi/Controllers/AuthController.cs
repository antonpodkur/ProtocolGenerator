using System;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using WebUi.Dtos;
using WebUi.Helpers;
using BC = BCrypt.Net.BCrypt;


namespace WebUi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _repository;
        private readonly JwtService _jwtService;

        public AuthController(IUserRepository repository, JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
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

            var jwt = _jwtService.Generate(user.Id);
            
            Response.Cookies.Append("jwt",jwt, new CookieOptions()
            {
                HttpOnly = true
            });
            
            return Ok(new
            {
                message = "success"
            });
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            try
            {
                var jwt = Request.Cookies["jwt"];

                var token = _jwtService.Verify(jwt);

                int userId = int.Parse(token.Issuer);

                var user = _repository.GetById(userId);

                return Ok(user);
            }
            catch (Exception e)
            {
                return Unauthorized();
            }
           
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");

            return Ok(new
            {
                message = "success"
            });
        }
    }
}