using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IGrupoService
    {
        Task<IList<Grupo>> GetAllAsync();
        Task<Grupo> GetAsync(Guid id);
        Task<Grupo> AddAsync(Grupo grupo);
        Task<Grupo> UpdateAsync(Grupo grupo);
        Task<Grupo> DeleteAsync(Grupo grupo);
    }

    public class GrupoService : IGrupoService
    {
        private readonly ApplicationDbContext _db;

        public GrupoService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Grupo>> GetAllAsync()
        {
            try
            {
                return await _db.Grupos.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Grupo> GetAsync(Guid id)
        {
            try
            {
                return await _db.Grupos.FindAsync(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Grupo> AddAsync(Grupo grupo)
        {
            try
            {
                _ = _db.Grupos.Add(grupo);
                _ = await _db.SaveChangesAsync();

                _db.Entry(grupo).State = EntityState.Detached;
                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Grupo> UpdateAsync(Grupo grupo)
        {
            try
            {
                _db.Entry(grupo).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();

                _db.Entry(grupo).State = EntityState.Detached;
                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Grupo> DeleteAsync(Grupo grupo)
        {
            try
            {
                _ = _db.Grupos.Remove(grupo);
                _ = await _db.SaveChangesAsync();
                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
