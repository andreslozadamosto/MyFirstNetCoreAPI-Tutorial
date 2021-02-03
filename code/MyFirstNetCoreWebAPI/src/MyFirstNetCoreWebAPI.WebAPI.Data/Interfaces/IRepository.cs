using MyFirstNetCoreWebAPI.WebAPI.Data.Entities;
using System.Collections.Generic;

namespace MyFirstNetCoreWebAPI.WebAPI.Data.Interfaces
{
    public interface IRepository<T>
    {
        ICollection<T> GetAll();

        T Get(string name);

        bool Exists(string name);

        void Add(T user);
    }
}
