using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IMarcacaoInicialService
    {
        Task<IList<MarcacaoInicial>> GetAllAsync();
        Task<MarcacaoInicial> GetAsync(Guid id);
        Task<MarcacaoInicial> AddAsync(MarcacaoInicial marcacaoInicial);
        Task<MarcacaoInicial> UpdateAsync(MarcacaoInicial marcacaoInicial);
        Task<MarcacaoInicial> DeleteAsync(MarcacaoInicial marcacaoInicial);
    }

    public class MarcacaoInicialService : IMarcacaoInicialService
    {
        private readonly ApplicationDbContext _db;

        public MarcacaoInicialService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<MarcacaoInicial>> GetAllAsync()
        {
            try
            {
                return await _db.MarcacoesIniciais.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MarcacaoInicial> GetAsync(Guid id)
        {
            try
            {
                MarcacaoInicial marcacaoInicial = await _db.MarcacoesIniciais.FindAsync(id);
                return marcacaoInicial;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MarcacaoInicial> AddAsync(MarcacaoInicial marcacaoInicial)
        {
            try
            {
                _ = _db.MarcacoesIniciais.Add(marcacaoInicial);
                _ = await _db.SaveChangesAsync();
                return marcacaoInicial;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MarcacaoInicial> UpdateAsync(MarcacaoInicial marcacaoInicial)
        {
            try
            {
                _db.Entry(marcacaoInicial).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return marcacaoInicial;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<MarcacaoInicial> DeleteAsync(MarcacaoInicial marcacaoInicial)
        {
            try
            {
                _ = _db.MarcacoesIniciais.Remove(marcacaoInicial);
                _ = await _db.SaveChangesAsync();
                return marcacaoInicial;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
