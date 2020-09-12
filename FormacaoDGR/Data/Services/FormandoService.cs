using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IFormandoService
    {
        Task<IList<Formando>> GetAllAsync();
        Task<Formando> GetAsync(Guid id);
        Task<Formando> AddAsync(Formando formando);
        Task<Formando> UpdateAsync(Formando formando);
        Task<Formando> DeleteAsync(Formando formando);
    }

    public class FormandoService : IFormandoService
    {
        private readonly ApplicationDbContext _db;

        public FormandoService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Formando>> GetAllAsync()
        {
            try
            {
                return await _db.Formandos
                                .Include(e => e.Empresa)
                                .Include(d => d.Departamento)
                                .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Formando> GetAsync(Guid id)
        {
            try
            {
                Formando formando = await _db.Formandos.FindAsync(id);
                return formando;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Formando> AddAsync(Formando formando)
        {
            try
            {
                _ = _db.Formandos.Add(formando);
                _ = await _db.SaveChangesAsync();

                _db.Entry(formando).State = EntityState.Detached;
                return formando;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Formando> UpdateAsync(Formando formando)
        {
            try
            {
                _db.Entry(formando).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();

                _db.Entry(formando).State = EntityState.Detached;
                await Task.Delay(1);
                return formando;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Formando> DeleteAsync(Formando formando)
        {
            try
            {
                _ = _db.Formandos.Remove(formando);
                _ = await _db.SaveChangesAsync();
                return formando;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
