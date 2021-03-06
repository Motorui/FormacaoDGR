﻿using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IEmpresaService
    {
        Task<IList<Empresa>> GetAllAsync();
        Task<Empresa> GetAsync(Guid id);
        Task<Empresa> AddAsync(Empresa empresa);
        Task<Empresa> UpdateAsync(Empresa empresa);
        Task<Empresa> DeleteAsync(Empresa empresa);
    }

    public class EmpresaService : IEmpresaService
    {
        private readonly ApplicationDbContext _db;

        public EmpresaService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Empresa>> GetAllAsync()
        {
            try
            {
                return await _db.Empresas.Include(g => g.Grupo).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Empresa> GetAsync(Guid id)
        {
            try
            {
                Empresa empresa = await _db.Empresas.Include(g => g.Grupo).FirstOrDefaultAsync(i => i.ID == id);
                return empresa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Empresa> AddAsync(Empresa empresa)
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

        public async Task<Empresa> UpdateAsync(Empresa empresa)
        {
            try
            {
                _ = _db.Entry(empresa).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return empresa;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Empresa> DeleteAsync(Empresa empresa)
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
