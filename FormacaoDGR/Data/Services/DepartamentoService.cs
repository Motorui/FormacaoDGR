using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IDepartamentoService
    {
        Task<IList<Departamento>> GetAllAsync();
        Task<Departamento> GetAsync(string id);
        Task<Departamento> AddAsync(Departamento dep);
        Task<Departamento> UpdateAsync(Departamento dep);
        Task<Departamento> DeleteAsync(Departamento dep);
    }

    public class DepartamentoService : IDepartamentoService
    {
        private readonly ApplicationDbContext _db;

        public DepartamentoService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Departamento>> GetAllAsync()
        {
            try
            {
                return await _db.Departamentos.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Departamento> GetAsync(string id)
        {
            try
            {
                Departamento dep = await _db.Departamentos.FindAsync(id);
                return dep;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Departamento> AddAsync(Departamento dep)
        {
            try
            {
                _ = _db.Departamentos.Add(dep);
                _ = await _db.SaveChangesAsync();
                return dep;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Departamento> UpdateAsync(Departamento dep)
        {
            try
            {
                _db.Entry(dep).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return dep;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Departamento> DeleteAsync(Departamento dep)
        {
            try
            {
                _ = _db.Departamentos.Remove(dep);
                _ = await _db.SaveChangesAsync();
                return dep;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
