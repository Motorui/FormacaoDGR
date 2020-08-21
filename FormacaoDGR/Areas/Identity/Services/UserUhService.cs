using FormacaoDGR.Areas.Identity.Models;
using FormacaoDGR.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormacaoDGR.Areas.Identity.Services
{
    public interface IUserUhService
    {
        Task<IList<UserUh>> GetAllUserUhsAsync();
        Task<UserUh> GetUserUhAsync(Guid id);
        Task<UserUh> AddUserUhAsync(UserUh userUh);
        Task<UserUh> UpdateUserUhAsync(UserUh userUh);
        Task<UserUh> DeleteUserUhAsync(UserUh userUh);
        Task<List<UserUh>> GetOwnedUserUhsAsync(string uid);
        Task<UserUh> DeleteAllUserUhAsync(string uid);
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
        public async Task<IList<UserUh>> GetAllUserUhsAsync()
        {
            try
            {
                IList<UserUh> userUhsList = await _db.UsersUhs.ToListAsync();
                return userUhsList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserUh> GetUserUhAsync(Guid id)
        {
            try
            {
                UserUh userUh = await _db.UsersUhs.FindAsync(id);
                return userUh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserUh> AddUserUhAsync(UserUh userUh)
        {
            try
            {
                _ = _db.UsersUhs.Add(userUh);
                _ = await _db.SaveChangesAsync();
                return userUh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserUh> UpdateUserUhAsync(UserUh userUh)
        {
            try
            {
                _ = _db.Entry(userUh).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return userUh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UserUh> DeleteUserUhAsync(UserUh userUh)
        {
            try
            {
                _ = _db.UsersUhs.Remove(userUh);
                _ = await _db.SaveChangesAsync();
                return userUh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<UserUh>> GetOwnedUserUhsAsync(string uid)
        {
            var userUhsList = await _db.UsersUhs
                .Include(u=>u.Uh)
                .Where(i => i.UserId == uid)
                .ToListAsync();

            return userUhsList;
        }

        public async Task<UserUh> DeleteAllUserUhAsync(string uid)
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
