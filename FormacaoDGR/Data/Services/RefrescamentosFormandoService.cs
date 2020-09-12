using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IRefrescamentosFormandoService
    {
        Task<IList<RefrescamentosFormando>> GetAllAsync();
        Task<RefrescamentosFormando> GetAsync(Guid id);
        Task<RefrescamentosFormando> AddAsync(RefrescamentosFormando refresh);
        Task<RefrescamentosFormando> UpdateAsync(RefrescamentosFormando refresh);
        Task<RefrescamentosFormando> DeleteAsync(RefrescamentosFormando refresh);
    }

    public class RefrescamentosFormandoService : IRefrescamentosFormandoService
    {
        private readonly ApplicationDbContext _db;

        public RefrescamentosFormandoService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<RefrescamentosFormando>> GetAllAsync()
        {
            try
            {
                IList<RefrescamentosFormando> refresh = await _db.RefrescamentosFormandos.ToListAsync();
                return refresh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RefrescamentosFormando> GetAsync(Guid id)
        {
            try
            {
                RefrescamentosFormando refresh = await _db.RefrescamentosFormandos.FindAsync(id);
                return refresh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RefrescamentosFormando> AddAsync(RefrescamentosFormando refresh)
        {
            try
            {
                _ = _db.RefrescamentosFormandos.Add(refresh);
                _ = await _db.SaveChangesAsync();

                _db.Entry(refresh).State = EntityState.Detached;
                return refresh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RefrescamentosFormando> UpdateAsync(RefrescamentosFormando refresh)
        {
            try
            {
                _db.Entry(refresh).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();

                _db.Entry(refresh).State = EntityState.Detached;
                return refresh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<RefrescamentosFormando> DeleteAsync(RefrescamentosFormando refresh)
        {
            try
            {
                _ = _db.RefrescamentosFormandos.Remove(refresh);
                _ = await _db.SaveChangesAsync();
                return refresh;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
