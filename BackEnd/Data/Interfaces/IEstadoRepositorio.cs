using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Data.Interfaces
{
    public interface IEstadoRepositorio : IRepositorio
    {
        Task<Estado[]> ObterTodos();
        Task<Estado> ObterPeloMunicipioId(int municipioId);
        Task<Estado> ObterPeloId(int estadoId);
    }
}