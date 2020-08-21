using FormacaoDGR.Areas.Identity.Models;
using FormacaoDGR.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Areas.Identity.Services
{
    public interface IAppRoleService
    {
        Task<IList<ApplicationRole>> GetAllRolesAsync();
        Task<ApplicationRole> GetRoleAsync(Guid id);
        Task<ApplicationRole> AddRoleAsync(ApplicationRole appRole);
        Task<ApplicationRole> UpdateRoleAsync(ApplicationRole appRole);
        Task<ApplicationRole> DeleteRoleAsync(ApplicationRole appRole);
    }

    public class AppRoleService : IAppRoleService
    {
        private readonly ApplicationDbContext _db;

        public AppRoleService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<ApplicationRole>> GetAllRolesAsync()
        {
            try
            {
                IList<ApplicationRole> rolesList = await _db.ApplicationRoles.ToListAsync();
                return rolesList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationRole> GetRoleAsync(Guid id)
        {
            try
            {
                ApplicationRole appRole = await _db.ApplicationRoles.FindAsync(id);
                return appRole;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationRole> AddRoleAsync(ApplicationRole appRole)
        {
            try
            {
                _ = _db.ApplicationRoles.Add(appRole);
                _ = await _db.SaveChangesAsync();
                return appRole;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationRole> UpdateRoleAsync(ApplicationRole appRole)
        {
            try
            {
                _ = _db.Entry(appRole).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return appRole;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ApplicationRole> DeleteRoleAsync(ApplicationRole appRole)
        {
            try
            {
                _ = _db.ApplicationRoles.Remove(appRole);
                _ = await _db.SaveChangesAsync();
                return appRole;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
