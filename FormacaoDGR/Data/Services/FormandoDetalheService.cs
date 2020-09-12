using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IFormandoDetalheService
    {
        Task<IList<FormandoDetalhe>> GetAllAsync();
        Task<FormandoDetalhe> GetAsync(Guid id);
        Task<FormandoDetalhe> AddAsync(FormandoDetalhe formandoDetalhe);
        Task<FormandoDetalhe> UpdateAsync(FormandoDetalhe formandoDetalhe);
        Task<FormandoDetalhe> DeleteAsync(FormandoDetalhe formandoDetalhe);
    }

    public class FormandoDetalheService : IFormandoDetalheService
    {
        private readonly ApplicationDbContext _db;

        public FormandoDetalheService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<FormandoDetalhe>> GetAllAsync()
        {
            try
            {
                return await _db.FormandosDetalhes.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FormandoDetalhe> GetAsync(Guid id)
        {
            try
            {
                FormandoDetalhe formandoDetalhe = await _db.FormandosDetalhes.FindAsync(id);
                return formandoDetalhe;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FormandoDetalhe> AddAsync(FormandoDetalhe formandoDetalhe)
        {
            try
            {
                _ = _db.FormandosDetalhes.Add(formandoDetalhe);
                _ = await _db.SaveChangesAsync();
                return formandoDetalhe;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FormandoDetalhe> UpdateAsync(FormandoDetalhe formandoDetalhe)
        {
            try
            {
                _db.Entry(formandoDetalhe).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return formandoDetalhe;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<FormandoDetalhe> DeleteAsync(FormandoDetalhe formandoDetalhe)
        {
            try
            {
                _ = _db.FormandosDetalhes.Remove(formandoDetalhe);
                _ = await _db.SaveChangesAsync();
                return formandoDetalhe;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
