using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface ICodigoPostalService
    {
        Task<IList<CodigoPostal>> GetAllAsync();
        IEnumerable<string> GetArray();
        Task<IList<CodigoPostal>> GetLikeAsync(string search);
        Task<CodigoPostal> GetAsync(string id);
        Task<CodigoPostal> AddAsync(CodigoPostal cp);
        Task<CodigoPostal> UpdateAsync(CodigoPostal cp);
        Task<CodigoPostal> DeleteAsync(CodigoPostal cp);
    }

    public class CodigoPostalService : ICodigoPostalService
    {
        private readonly ApplicationDbContext _db;

        public CodigoPostalService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<CodigoPostal>> GetAllAsync()
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

        IEnumerable<string> ICodigoPostalService.GetArray()
        {
            try
            {
                return _db.CodigosPostais.Select(c => c.Cod_postal).ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<CodigoPostal>> GetLikeAsync(string search)
        {
            try
            {
                return await _db.CodigosPostais.Where(s => s.Cod_postal.Contains(search)).Take(1000).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CodigoPostal> GetAsync(string id)
        {
            try
            {
                CodigoPostal cp = await _db.CodigosPostais.FindAsync(id);
                return cp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CodigoPostal> AddAsync(CodigoPostal cp)
        {
            try
            {
                _ = _db.CodigosPostais.Add(cp);
                _ = await _db.SaveChangesAsync();
                return cp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CodigoPostal> UpdateAsync(CodigoPostal cp)
        {
            try
            {
                _db.Entry(cp).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return cp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CodigoPostal> DeleteAsync(CodigoPostal cp)
        {
            try
            {
                _ = _db.CodigosPostais.Remove(cp);
                _ = await _db.SaveChangesAsync();
                return cp;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
