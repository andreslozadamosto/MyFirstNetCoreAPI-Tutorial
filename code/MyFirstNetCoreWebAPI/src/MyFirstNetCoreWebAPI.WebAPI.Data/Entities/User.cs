using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstNetCoreWebAPI.WebAPI.Data.Entities
{
    public class User
    {
        public string Name { get; set; }

        public User() { }

        public User(string name)
        {
            Name = name;
        }
    }
}
