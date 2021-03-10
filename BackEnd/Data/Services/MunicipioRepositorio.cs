using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Services
{
    public class MunicipioRepositorio : IMunicipioRepositorio
    {
        private readonly DataContext _context;
        public MunicipioRepositorio(DataContext context)
        {
            this._context = context;
        }

        public void Adcionar<T>(T entidade) where T : class
        {
            this._context.Add(entidade);
        }

        public void Atualizar<T>(T entidade) where T : class
        {
            this._context.Update(entidade);
        }

        public async Task<Municipio> ObterPeloId(int municipioId)
        {
            IQueryable<Municipio> query = _context.Municipio;

            return await query
                .AsNoTracking()
                .Where(m => m.Id == municipioId)
                .OrderBy(m => m.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Municipio[]> ObterTodos()
        {
            IQueryable<Municipio> query = _context.Municipio;

            return await query
                .Include(m => m.Estado)
                .AsNoTracking()
                .OrderBy(m => m.Id)
                .ToArrayAsync();
        }

        public async Task<Municipio[]> ObterTodosPeloEstadoId(int estadoId)
        {
            IQueryable<Municipio> query = _context.Municipio;

            return await query
                .Include(m => m.Estado)
                .AsNoTracking()
                .Where(m => m.EstadoId == estadoId)
                .OrderBy(m => m.Id)
                .ToArrayAsync();
        }

        public void Remover<T>(T entidade) where T : class
        {
            this._context.Remove(entidade);
        }

        public async Task<bool> EfetuouAlteracaoNaBase()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}