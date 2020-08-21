using FormacaoDGR.Areas.Identity.Models;
using FormacaoDGR.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Areas.Identity.Services
{
    public interface IAppUserService
    {
        Task<IList<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserAsync(string id);
        Task<ApplicationUser> AddUserAsync(ApplicationUser appUser);
        Task<ApplicationUser> UpdateUserAsync(ApplicationUser appUser);
        Task<ApplicationUser> DeleteUserAsync(ApplicationUser appUser);
    }
    public class AppUserService : IAppUserService
    {
        private readonly ApplicationDbContext _db;

        public AppUserService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<ApplicationUser>> GetAllUsersAsync()
        {
            try
            {
                IList<ApplicationUser> usersList = await _db.ApplicationUsers
                    .Include(r => r.ApplicationUserRoles)
                    .Include(u => u.UserUhs).ToListAsync();
                return usersList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationUser> GetUserAsync(string id)
        {
            try
            {
                ApplicationUser appUser = await _db.ApplicationUsers.FindAsync(id);
                return appUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationUser> AddUserAsync(ApplicationUser appUser)
        {
            try
            {
                _ = _db.ApplicationUsers.Add(appUser);
                _ = await _db.SaveChangesAsync();
                return appUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationUser> UpdateUserAsync(ApplicationUser appUser)
        {
            try
            {
                _ = _db.Entry(appUser).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return appUser;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationUser> DeleteUserAsync(ApplicationUser appUser)
        {
            try
            {
                _ = _db.ApplicationUsers.Remove(appUser);
                _ = await _db.SaveChangesAsync();
                return appUser;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
