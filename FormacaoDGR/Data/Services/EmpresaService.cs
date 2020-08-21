using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IEmpresaService
    {
        Task<IList<Empresa>> GetAllEmpresasAsync();
        Task<Empresa> GetEmpresaAsync(Guid id);
        Task<Empresa> AddEmpresaAsync(Empresa empresa);
        Task<Empresa> UpdateEmpresaAsync(Empresa empresa);
        Task<Empresa> DeleteEmpresaAsync(Empresa empresa);
    }

    public class EmpresaService : IEmpresaService
    {
        private readonly ApplicationDbContext _db;

        public EmpresaService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Empresa>> GetAllEmpresasAsync()
        {
            try
            {
                return await _db.Empresas.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Empresa> GetEmpresaAsync(Guid id)
        {
            try
            {
                Empresa empresa = await _db.Empresas.FindAsync(id);
                return empresa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Empresa> AddEmpresaAsync(Empresa empresa)
        {
            try
            {
                _ = _db.Empresas.Add(empresa);
                _ = await _db.SaveChangesAsync();
                return empresa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Empresa> UpdateEmpresaAsync(Empresa empresa)
        {
            try
            {
                _db.Entry(empresa).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return empresa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Empresa> DeleteEmpresaAsync(Empresa empresa)
        {
            try
            {
                _ = _db.Empresas.Remove(empresa);
                _ = await _db.SaveChangesAsync();
                return empresa;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
