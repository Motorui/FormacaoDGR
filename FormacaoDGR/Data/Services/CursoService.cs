using FormacaoDGR.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormacaoDGR.Data.Services
{
    public interface ICursoService
    {
        Task<IList<Curso>> GetAllAsync();
        IEnumerable<string> GetArray();
        Task<IList<Curso>> GetLikeAsync(string search);
        Task<Curso> GetAsync(string id);
        Task<Curso> AddAsync(Curso curso);
        Task<Curso> UpdateAsync(Curso curso);
        Task<Curso> DeleteAsync(Curso curso);
    }

    public class CursoService : ICursoService
    {
        private readonly ApplicationDbContext _db;

        public CursoService(ApplicationDbContext context)
        {
            _db = context;
        }

        public async Task<IList<Curso>> GetAllAsync()
        {
            try
            {
                IList<Curso> cursos = await _db.Cursos.ToListAsync();
                return cursos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<string> GetArray()
        {
            try
            {
                return _db.Cursos.Select(c => c.Nome).ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<Curso>> GetLikeAsync(string search)
        {
            try
            {
                return await _db.Cursos.Where(s => s.Nome.Contains(search)).Take(1000).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Curso> GetAsync(string id)
        {
            try
            {
                Curso curso = await _db.Cursos.FindAsync(id);
                return curso;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Curso> AddAsync(Curso curso)
        {
            try
            {
                _ = _db.Cursos.Add(curso);
                _ = await _db.SaveChangesAsync();
                return curso;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Curso> UpdateAsync(Curso curso)
        {
            try
            {
                _db.Entry(curso).State = EntityState.Modified;
                _ = await _db.SaveChangesAsync();
                return curso;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Curso> DeleteAsync(Curso curso)
        {
            try
            {
                _ = _db.Cursos.Remove(curso);
                _ = await _db.SaveChangesAsync();
                return curso;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
