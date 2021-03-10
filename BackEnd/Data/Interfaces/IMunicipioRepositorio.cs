using System.Threading.Tasks;
using BackEnd.Models;

namespace BackEnd.Data.Interfaces
{
    public interface IMunicipioRepositorio : IRepositorio
    {
        Task<Municipio[]> ObterTodos();
        Task<Municipio[]> ObterTodosPeloEstadoId(int estadoId);
        Task<Municipio> ObterPeloId(int municipioId);
    }
}