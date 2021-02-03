using MyFirstNetCoreWebAPI.WebAPI.Data.Entities;

namespace MyFirstNetCoreWebAPI.WebAPI.Models
{
    public class UserDto
    {
        public string Name { get; init; }

        public UserDto(string name)
        {
            Name = name;
        }

        public static UserDto FromModel(User model) => new UserDto(model.Name);
    }
}
