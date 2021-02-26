using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyFirstNetCoreWebAPI.WebAPI.Data.Entities;
using MyFirstNetCoreWebAPI.WebAPI.Data.Interfaces;
using MyFirstNetCoreWebAPI.WebAPI.Models;

namespace MyFirstNetCoreWebAPI.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all the Users
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<List<UserDto>> GetAllUsers() 
            => Ok(_userRepository
                .GetAll()
                .Select(x => UserDto.FromModel(x)).ToList());

        /// <summary>
        /// Gets a User
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     curl http://localhost/api/users/andres
        /// 
        /// </remarks>
        /// <param name="name">Name of the user (is de id)</param>
        /// <returns></returns>
        [HttpGet("{name}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

        /// <summary>
        /// Adds a new user into the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST /
        ///     {
        ///         "name" = "Monica"
        ///     }
        /// 
        /// </remarks>
        /// <param name="newUserToCreate">User information for the new user</param>
        /// <returns></returns>
        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        [ProducesResponseType(StatusCodes.Status201Created)]
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