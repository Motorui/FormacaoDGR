using Microsoft.EntityFrameworkCore;
using FormacaoDGR.Areas.Identity.Models;
using FormacaoDGR.Data;
using System;
using System.Collections.Generic;
using System.Linq;


namespace FormacaoDGR.Areas.Identity.Services
{
    public interface IAppRoleService
    {
        IList<ApplicationRole> GetAllRoles();
        ApplicationRole GetRole(Guid id);
        ApplicationRole AddRole(ApplicationRole appRole);
        ApplicationRole UpdateRole(ApplicationRole appRole);
        ApplicationRole DeleteRole(ApplicationRole appRole);
    }

    public class AppRoleService : IAppRoleService
    {
        private readonly ApplicationDbContext _db;

        public AppRoleService(ApplicationDbContext context)
        {
            _db = context;
        }

        public IList<ApplicationRole> GetAllRoles()
        {
            IList<ApplicationRole> rolesList = _db.ApplicationRoles.ToList();
            return rolesList;
        }
        public ApplicationRole GetRole(Guid id)
        {
            ApplicationRole appRole = _db.ApplicationRoles.Find(id);
            return appRole;
        }
        public ApplicationRole AddRole(ApplicationRole appRole)
        {
            _db.ApplicationRoles.Add(appRole);
            _db.SaveChanges();
            return appRole;
        }
        public ApplicationRole UpdateRole(ApplicationRole appRole)
        {
            _db.Entry(appRole).State = EntityState.Modified;
            _db.SaveChanges();
            return appRole;
        }
        public ApplicationRole DeleteRole(ApplicationRole appRole)
        {
            _db.ApplicationRoles.Remove(appRole);
            _db.SaveChanges();
            return appRole;
        }
    }
}
