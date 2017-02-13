using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SampleAPI.Repository;
using SampleAPI.Models;
using System.Threading.Tasks;
using SampleAPI.DataAccessLayer;
using System.Data.Entity;

namespace SampleAPI.Repository
{
    //This class defines the methods of IUserRepository interface.
    public class UserRepository<T> : IUserRepository<T> where T : class
    {
        private CRMContext db;
        private DbSet<T> dbSet;

        public UserRepository()
        {
            db = new CRMContext();
            dbSet = db.Set<T>();
        }

        public async Task AddUser(T obj)
        {
            await Task.Run(() => dbSet.Add(obj));
        }

        public async Task<IEnumerable<T>> GetAllUser()
        {
            return await Task.Run(() => dbSet.ToList());
        }

        public async Task<T> GetUserByID(int id)
        {
            return await Task.Run(() => dbSet.Find(id));
        }

        public bool IsExistByUsername(string username)
        {
            return db.Users.Where(u => u.username == username).Any();
        }

        public Task<T> GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public async Task SaveUser()
        {
            await Task.Run(() => db.SaveChanges());
        }

        public Task<User> UpdateUser(string id, string item)
        {
            throw new NotImplementedException();
        }
    }
}