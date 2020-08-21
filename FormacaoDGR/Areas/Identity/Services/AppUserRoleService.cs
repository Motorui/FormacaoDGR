using FormacaoDGR.Areas.Identity.Models;
using FormacaoDGR.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormacaoDGR.Areas.Identity.Services
{
    public interface IAppUserRoleService
    {
        Task<IList<ApplicationUserRole>> GetAllUserRolesAsync();
        Task<ApplicationUserRole> GetUserRoleAsync(string id);
        Task<ApplicationUserRole> AddUserRoleAsync(ApplicationUserRole appUserRole);
        Task<ApplicationUserRole> UpdateUserRoleAsync(ApplicationUserRole appUserRole);
        Task<ApplicationUserRole> DeleteUserRoleAsync(ApplicationUserRole appUserRole);
        Task<ApplicationUserRole> DeleteAllUserRolesAsync(string uid);
    }

    public class AppUserRoleService : IAppUserRoleService
    {
        private readonly ApplicationDbContext _db;

        public AppUserRoleService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<ApplicationUserRole>> GetAllUserRolesAsync()
        {
            try
            {
                IList<ApplicationUserRole> userRolesList = await _db.ApplicationUserRoles.ToListAsync();
                return userRolesList;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationUserRole> GetUserRoleAsync(string id)
        {
            try
            {
                ApplicationUserRole appUserRole = await _db.ApplicationUserRoles.Where(i => i.UserId == id).FirstOrDefaultAsync();
                return appUserRole;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationUserRole> AddUserRoleAsync(ApplicationUserRole appUserRole)
        {
            try
            {
                _ = _db.ApplicationUserRoles.Add(appUserRole);
                _ = await _db.SaveChangesAsync();
                return appUserRole;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationUserRole> UpdateUserRoleAsync(ApplicationUserRole appUserRole)
        {
            try
            {
                _ = _db.Entry(appUserRole).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return appUserRole;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationUserRole> DeleteUserRoleAsync(ApplicationUserRole appUserRole)
        {
            try
            {
                _ = _db.ApplicationUserRoles.Remove(appUserRole);
                _ = await _db.SaveChangesAsync();
                return appUserRole;
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationUserRole> DeleteAllUserRolesAsync(string uid)
        {
            try
            {
                IList<ApplicationUserRole> userRolesList = await _db.ApplicationUserRoles.Where(i => i.UserId == uid).ToListAsync();
                foreach (var userRoles in userRolesList)
                {
                    _db.ApplicationUserRoles.Remove(userRoles);
                }
                _ = await _db.SaveChangesAsync();

                return null;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}
