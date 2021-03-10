using System.Threading.Tasks;

namespace BackEnd.Data.Interfaces
{
    public interface IRepositorio
    {
        void Adcionar<T>(T entidade) where T : class;
        void Atualizar<T>(T entidade) where T : class;
        void Remover<T>(T entidade) where T : class;
        Task<bool> EfetuouAlteracaoNaBase();
    }
}