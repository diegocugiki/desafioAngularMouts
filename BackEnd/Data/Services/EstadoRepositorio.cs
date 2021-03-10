using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data.Interfaces;
using BackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEnd.Data.Services
{
    public class EstadoRepositorio : IEstadoRepositorio
    {
        private readonly DataContext _context;

        public EstadoRepositorio(DataContext context)
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

        public async Task<Estado> ObterPeloId(int estadoId)
        {
            IQueryable<Estado> query = _context.Estado;

            return await query
                .AsNoTracking()
                .Where(e => e.Id == estadoId)
                .OrderBy(e => e.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<Estado[]> ObterTodos()
        {
            IQueryable<Estado> query = _context.Estado;

            return await query
                .AsNoTracking()
                .OrderBy(e => e.Id)
                .ToArrayAsync();
        }

        public async Task<Estado> ObterPeloMunicipioId(int municipioId)
        {
            IQueryable<Estado> query = _context.Estado;

            return await query
                .AsNoTracking()
                .Where(e => e.Municipios.Any(m => m.Id == municipioId))
                .OrderBy(e => e.Id)
                .FirstOrDefaultAsync();
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