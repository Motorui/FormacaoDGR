using Microsoft.EntityFrameworkCore;
using MyWaySO.Areas.Identity.Models;
using MyWaySO.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWaySO.Areas.Identity.Services
{
    public interface IAppUserService
    {
        IList<ApplicationUser> GetAllUsers();
        ApplicationUser GetUser(string id);
        ApplicationUser AddUser(ApplicationUser appUser);
        ApplicationUser UpdateUser(ApplicationUser appUser);
        ApplicationUser DeleteUser(ApplicationUser appUser);
    }
    public class AppUserService : IAppUserService
    {
        private readonly ApplicationDbContext _db;

        public AppUserService(ApplicationDbContext context)
        {
            _db = context;
        }

        public IList<ApplicationUser> GetAllUsers()
        {
            IList<ApplicationUser> usersList = _db.ApplicationUsers
                .Include(r => r.ApplicationUserRoles)
                .Include(u=>u.UserUhs).ToList();
            return usersList;
        }

        public ApplicationUser GetUser(string id)
        {
            ApplicationUser appUser = _db.ApplicationUsers.Find(id);
            return appUser;
        }

        public ApplicationUser AddUser(ApplicationUser appUser)
        {
            _db.ApplicationUsers.Add(appUser);
            _db.SaveChanges();
            return appUser;
        }

        public ApplicationUser UpdateUser(ApplicationUser appUser)
        {
            _db.Entry(appUser).State = EntityState.Modified;
            _db.SaveChanges();
            return appUser;
        }

        public ApplicationUser DeleteUser(ApplicationUser appUser)
        {
            _db.ApplicationUsers.Remove(appUser);
            _db.SaveChanges();
            return appUser;
        }
    }
}
