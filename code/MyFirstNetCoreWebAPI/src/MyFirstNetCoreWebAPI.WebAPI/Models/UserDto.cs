using MyFirstNetCoreWebAPI.WebAPI.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace MyFirstNetCoreWebAPI.WebAPI.Models
{
    public class UserDto
    {
        [Required]
        public string Name { get; init; }

        public UserDto(string name)
        {
            Name = name;
        }

        public static UserDto FromModel(User model) => new UserDto(model.Name);
    }
}
