using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface ICodigoPostalService
    {
        Task<IList<CodigoPostal>> GetAllCodigosPostaisAsync();
        Task<CodigoPostal> GetCodigoPostalAsync(Guid id);
        Task<CodigoPostal> AddCodigoPostalAsync(CodigoPostal codigoPostal);
        Task<CodigoPostal> UpdateCodigoPostalAsync(CodigoPostal codigoPostal);
        Task<CodigoPostal> DeleteCodigoPostalAsync(CodigoPostal codigoPostal);
    }

    public class CodigoPostalService : ICodigoPostalService
    {
        private readonly ApplicationDbContext _db;

        public CodigoPostalService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<CodigoPostal>> GetAllCodigosPostaisAsync()
        {
            try
            {
                return await _db.CodigosPostais.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CodigoPostal> GetCodigoPostalAsync(Guid id)
        {
            try
            {
                CodigoPostal codigoPostal = await _db.CodigosPostais.FindAsync(id);
                return codigoPostal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CodigoPostal> AddCodigoPostalAsync(CodigoPostal codigoPostal)
        {
            try
            {
                _ = _db.CodigosPostais.Add(codigoPostal);
                _ = await _db.SaveChangesAsync();
                return codigoPostal;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<CodigoPostal> UpdateCodigoPostalAsync(CodigoPostal codigoPostal)
        {
            try
            {
                _db.Entry(codigoPostal).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return codigoPostal;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CodigoPostal> DeleteCodigoPostalAsync(CodigoPostal codigoPostal)
        {
            try
            {
                _ = _db.CodigosPostais.Remove(codigoPostal);
                _ = await _db.SaveChangesAsync();
                return codigoPostal;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
