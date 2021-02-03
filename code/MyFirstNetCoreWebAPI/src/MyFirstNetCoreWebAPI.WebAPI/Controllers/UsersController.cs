using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstNetCoreWebAPI.WebAPI.Data.Entities;
using MyFirstNetCoreWebAPI.WebAPI.Data.Interfaces;
using MyFirstNetCoreWebAPI.WebAPI.Models;

namespace MyFirstNetCoreWebAPI.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet()]
        public ActionResult<List<UserDto>> GetAllUsers() 
            => Ok(_userRepository
                .GetAll()
                .Select(x => UserDto.FromModel(x)).ToList());

        [HttpGet("{name}")]
        public ActionResult<UserDto> GetUser(string name)
        {
            var user = _userRepository.Get(name);
            if (user == null)
                return Problem(
                    "User not found",
                    HttpContext.Request.Path,
                    StatusCodes.Status404NotFound,
                    "Bad parameters");

            return Ok(UserDto.FromModel(user));
        }

        [HttpPost()]
        public ActionResult<UserDto> AddUser([FromBody] UserDto newUserToCreate)
        {
            if (string.IsNullOrEmpty(newUserToCreate.Name))
                return BadRequest(new ProblemDetails()
                {
                    Title = "Bad parameters",
                    Detail = "The name of the new user cannot be empty or null",
                    Instance = HttpContext.Request.Path
                });

            var userAlreadyExists = _userRepository.Exists(newUserToCreate.Name);
            if (userAlreadyExists)
                return Conflict(new ProblemDetails()
                {
                    Detail = "User already exists",
                    Title = "Bad parameters",
                    Instance = HttpContext.Request.Path
                });

            var newUser = new User(newUserToCreate.Name);

            _userRepository.Add(newUser);

            return Created($"/users/{newUserToCreate.Name}", UserDto.FromModel(newUser));
        }
    }
}