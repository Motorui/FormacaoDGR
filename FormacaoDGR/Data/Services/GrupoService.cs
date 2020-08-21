using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface IGrupoService
    {
        Task<IList<Grupo>> GetAllGruposAsync();
        Task<Grupo> GetGrupoAsync(Guid id);
        Task<Grupo> AddGrupoAsync(Grupo grupo);
        Task<Grupo> UpdateGrupoAsync(Grupo grupo);
        Task<Grupo> DeleteGrupoAsync(Grupo grupo);
    }

    public class GrupoService : IGrupoService
    {
        private readonly ApplicationDbContext _db;

        public GrupoService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Grupo>> GetAllGruposAsync()
        {
            try
            {
                IList<Grupo> grupos = await _db.Grupos.ToListAsync();
                return grupos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Grupo> GetGrupoAsync(Guid id)
        {
            try
            {
                Grupo grupo = await _db.Grupos.FindAsync(id);
                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Grupo> AddGrupoAsync(Grupo grupo)
        {
            try
            {
                _ = _db.Grupos.Add(grupo);
                _ = await _db.SaveChangesAsync();
                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Grupo> UpdateGrupoAsync(Grupo grupo)
        {
            try
            {
                _db.Entry(grupo).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return grupo;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Grupo> DeleteGrupoAsync(Grupo grupo)
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
