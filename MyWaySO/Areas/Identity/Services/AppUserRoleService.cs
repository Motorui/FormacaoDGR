using Microsoft.EntityFrameworkCore;
using MyWaySO.Areas.Identity.Models;
using MyWaySO.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace MyWaySO.Areas.Identity.Services
{
    public interface IAppUserRoleService
    {
        IList<ApplicationUserRole> GetAllUserRoles();
        ApplicationUserRole GetUserRole(string id);
        ApplicationUserRole AddUserRole(ApplicationUserRole appUserRole);
        ApplicationUserRole UpdateUserRole(ApplicationUserRole appUserRole);
        ApplicationUserRole DeleteUserRole(ApplicationUserRole appUserRole);
        ApplicationUserRole DeleteAllUserRoles(string uid);
    }

    public class AppUserRoleService : IAppUserRoleService
    {
        private readonly ApplicationDbContext _db;

        public AppUserRoleService(ApplicationDbContext context)
        {
            _db = context;
        }
        public IList<ApplicationUserRole> GetAllUserRoles()
        {
            IList<ApplicationUserRole> userRolesList = _db.ApplicationUserRoles.ToList();
            return userRolesList;
        }
        public ApplicationUserRole GetUserRole(string id)
        {
            ApplicationUserRole appUserRole = _db.ApplicationUserRoles.Where(i => i.UserId == id).FirstOrDefault();
            return appUserRole;
        }
        public ApplicationUserRole AddUserRole(ApplicationUserRole appUserRole)
        {
            _db.ApplicationUserRoles.Add(appUserRole);
            _db.SaveChanges();
            return appUserRole;
        }
        public ApplicationUserRole UpdateUserRole(ApplicationUserRole appUserRole)
        {
            _db.Entry(appUserRole).State = EntityState.Modified;
            _db.SaveChanges();
            return appUserRole;
        }
        public ApplicationUserRole DeleteUserRole(ApplicationUserRole appUserRole)
        {
            _db.ApplicationUserRoles.Remove(appUserRole);
            _db.SaveChanges();
            return appUserRole;
        }

        public ApplicationUserRole DeleteAllUserRoles(string uid)
        {
            IList<ApplicationUserRole> userRolesList = _db.ApplicationUserRoles.Where(i => i.UserId == uid).ToList();
            foreach (var userRoles in userRolesList)
            {
                _db.ApplicationUserRoles.Remove(userRoles);
            }
            _db.SaveChanges();

            return null;
        }
    }
}
