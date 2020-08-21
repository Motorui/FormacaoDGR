using FormacaoDGR.Areas.Identity.Models;
using FormacaoDGR.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Areas.Identity.Services
{
    public interface IUhService
    {
        Task<IList<Uh>> GetAllUhsAsync();
        Task<Uh> GetUhAsync(Guid id);
        Task<Uh> AddUhAsync(Uh uh);
        Task<Uh> UpdateUhAsync(Uh uh);
        Task<Uh> DeleteUhAsync(Uh uh);
    }

    public class UhService : IUhService
    {
        private readonly ApplicationDbContext _db;

        public UhService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Uh>> GetAllUhsAsync()
        {
            try
            {
                IList<Uh> uhs = await _db.Uhs.ToListAsync();
                return uhs;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Uh> GetUhAsync(Guid id)
        {
            try
            {
                Uh uh = await _db.Uhs.FindAsync(id);
                return uh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Uh> AddUhAsync(Uh uh)
        {
            try
            {
                _ = _db.Uhs.Add(uh);
                _ = await _db.SaveChangesAsync();
                return uh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Uh> UpdateUhAsync(Uh uh)
        {
            try
            {
                _ = _db.Entry(uh).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return uh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Uh> DeleteUhAsync(Uh uh)
        {
            try
            {
                _ = _db.Uhs.Remove(uh);
                _ = await _db.SaveChangesAsync();
                return uh;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
