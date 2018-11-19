using System.Collections.Generic;
using System.Threading.Tasks;

namespace TreinamentoWeb.Dominio.Interfaces.Repositorio
{
    public interface IRepositorio<T>
    {
        Task<List<T>> BuscarTodos();
        T BuscarPorId(int id);
        void Inserir(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
    }
}
