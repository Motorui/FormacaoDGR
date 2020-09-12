using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface ISalaService
    {
        Task<IList<Sala>> GetAllAsync();
        Task<Sala> GetAsync(Guid id);
        Task<Sala> AddAsync(Sala sala);
        Task<Sala> UpdateAsync(Sala sala);
        Task<Sala> DeleteAsync(Sala sala);
    }

    public class SalaService : ISalaService
    {
        private readonly ApplicationDbContext _db;

        public SalaService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Sala>> GetAllAsync()
        {
            try
            {
                return await _db.Salas.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Sala> GetAsync(Guid id)
        {
            try
            {
                Sala sala = await _db.Salas.FindAsync(id);
                return sala;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Sala> AddAsync(Sala sala)
        {
            try
            {
                _ = _db.Salas.Add(sala);
                _ = await _db.SaveChangesAsync();
                return sala;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Sala> UpdateAsync(Sala sala)
        {
            try
            {
                _db.Entry(sala).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return sala;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Sala> DeleteAsync(Sala sala)
        {
            try
            {
                _ = _db.Salas.Remove(sala);
                _ = await _db.SaveChangesAsync();
                return sala;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
