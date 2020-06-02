using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MyWaySO.Areas.Identity.Models;
using System;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;

namespace MyWaySO.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
     ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #region set DbSet
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; }
        public DbSet<Uh> Uhs { get; set; }   
        public DbSet<UserUh> UsersUhs { get; set; }
        #endregion

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeSaving();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        private void OnBeforeSaving()
        {
            IEnumerable entries = ChangeTracker.Entries();
            foreach (EntityEntry entry in entries)
            {
                if (entry.Entity is IBaseEntity baseEntity)
                {
                    DateTime now = DateTime.UtcNow;
                    string user = "";
                    try
                    {
                        user = _httpContextAccessor.HttpContext.User.Identity.Name;
                    }
                    catch (NullReferenceException ex)
                    {
                        NullReferenceException erro = ex;
                        user = "SISTEMA";
                    }

                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            baseEntity.LastUpdatedAt = now;
                            baseEntity.LastUpdatedBy = user;
                            break;

                        case EntityState.Added:
                            baseEntity.CreatedAt = now;
                            baseEntity.CreatedBy = user;
                            baseEntity.LastUpdatedAt = null;
                            baseEntity.LastUpdatedBy = null;
                            break;
                    }
                }
            }
        }
    }
}
