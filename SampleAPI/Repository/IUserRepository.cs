using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SampleAPI.Models;

namespace SampleAPI.Repository
{
    //Contains signatures for database operations
    interface IUserRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllUser();
        Task<T> GetUserByID(int id);
        Task<T> GetUserByUsername(string username);

        bool IsExistByUsername(string username);

        Task AddUser(T obj);
        Task SaveUser();

        Task<User> UpdateUser(string id, string item);
    }
}
