using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface ICursosFormandoService
    {
        Task<IList<CursosFormando>> GetAllAsync();
        Task<CursosFormando> GetAsync(string id);
        Task<CursosFormando> AddAsync(CursosFormando cf);
        Task<CursosFormando> UpdateAsync(CursosFormando cf);
        Task<CursosFormando> DeleteAsync(CursosFormando cf);
    }

    public class CursosFormandoService : ICursosFormandoService
    {
        private readonly ApplicationDbContext _db;

        public CursosFormandoService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<CursosFormando>> GetAllAsync()
        {
            try
            {
                return await _db.CursosFormandos.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CursosFormando> GetAsync(string id)
        {
            try
            {
                CursosFormando cf = await _db.CursosFormandos.FindAsync(id);
                return cf;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CursosFormando> AddAsync(CursosFormando cf)
        {
            try
            {
                _ = _db.CursosFormandos.Add(cf);
                _ = await _db.SaveChangesAsync();
                return cf;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CursosFormando> UpdateAsync(CursosFormando cf)
        {
            try
            {
                _db.Entry(cf).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return cf;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CursosFormando> DeleteAsync(CursosFormando cf)
        {
            try
            {
                _ = _db.CursosFormandos.Remove(cf);
                _ = await _db.SaveChangesAsync();
                return cf;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
