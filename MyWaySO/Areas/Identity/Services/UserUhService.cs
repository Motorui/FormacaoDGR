using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyWaySO.Areas.Identity.Models;
using MyWaySO.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWaySO.Areas.Identity.Services
{
    public interface IUserUhService
    {
        IList<UserUh> GetAllUserUhs();
        UserUh GetUserUh(Guid id);
        UserUh AddUserUh(UserUh userUh);
        UserUh UpdateUserUh(UserUh userUh);
        UserUh DeleteUserUh(UserUh userUh);
        IList<UserUh> GetOwnedUserUhs(string uid);
        Task<List<UserUh>> GetOwnedUserUhsAsync(string uid);
        Task<UserUh> DeleteAllUserUh(string uid);
    }
    public class UserUhService : IUserUhService
    {
        protected readonly IServiceScopeFactory _ServiceScopeFactory;
        private readonly ApplicationDbContext _db;
        public UserUhService(ApplicationDbContext context, IServiceScopeFactory serviceScopeFactory)
        {
            _db = context;
            _ServiceScopeFactory = serviceScopeFactory;
        }
        public IList<UserUh> GetAllUserUhs()
        {
            IList<UserUh> userUhsList = _db.UsersUhs.ToList();
            return userUhsList;
        }
        public UserUh GetUserUh(Guid id)
        {
            UserUh userUh = _db.UsersUhs.Find(id);
            return userUh;
        }
        public UserUh AddUserUh(UserUh userUh)
        {
            _db.UsersUhs.Add(userUh);
            _db.SaveChanges();
            return userUh;
        }
        public UserUh UpdateUserUh(UserUh userUh)
        {
            _db.Entry(userUh).State = EntityState.Modified;
            _db.SaveChanges();
            return userUh;
        }
        public UserUh DeleteUserUh(UserUh userUh)
        {
            _db.UsersUhs.Remove(userUh);
            _db.SaveChanges();
            return userUh;
        }

        public IList<UserUh> GetOwnedUserUhs(string uid)
        {
            IList<UserUh> userUhsList = _db.UsersUhs.Where(i => i.UserId == uid).Include(u=>u.Uh).ToList();
            return userUhsList;
        }

        public async Task<List<UserUh>> GetOwnedUserUhsAsync(string uid)
        {
            var userUhsList = await _db.UsersUhs.Where(i => i.UserId == uid).ToListAsync();
            return userUhsList;
        }

        public async Task<UserUh> DeleteAllUserUh(string uid)
        {
            IList<UserUh> userUhsList = await _db.UsersUhs.Where(i => i.UserId == uid).ToListAsync();
            foreach (var userUhs in userUhsList)
            {
               _db.UsersUhs.Remove(userUhs);
            }            
            await _db.SaveChangesAsync();

            return null;
        }
    }
}
