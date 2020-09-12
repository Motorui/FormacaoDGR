using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IRefrescamentoService
    {
        Task<IList<Refrescamento>> GetAllAsync();
        Task<Refrescamento> GetAsync(Guid id);
        Task<Refrescamento> AddAsync(Refrescamento refresh);
        Task<Refrescamento> UpdateAsync(Refrescamento refresh);
        Task<Refrescamento> DeleteAsync(Refrescamento refresh);
    }

    public class RefrescamentoService : IRefrescamentoService
    {
        private readonly ApplicationDbContext _db;

        public RefrescamentoService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Refrescamento>> GetAllAsync()
        {
            try
            {
                IList<Refrescamento> refresh = await _db.Refrescamentos.ToListAsync();
                return refresh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Refrescamento> GetAsync(Guid id)
        {
            try
            {
                Refrescamento refresh = await _db.Refrescamentos.FindAsync(id);
                return refresh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Refrescamento> AddAsync(Refrescamento refresh)
        {
            try
            {
                _ = _db.Refrescamentos.Add(refresh);
                _ = await _db.SaveChangesAsync();

                _db.Entry(refresh).State = EntityState.Detached;
                return refresh;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Refrescamento> UpdateAsync(Refrescamento refresh)
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

        public async Task<Refrescamento> DeleteAsync(Refrescamento refresh)
        {
            try
            {
                _ = _db.Refrescamentos.Remove(refresh);
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
