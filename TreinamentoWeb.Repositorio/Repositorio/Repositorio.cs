using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Dominio.Entidades;
using TreinamentoWeb.Dominio.Interfaces.Repositorio;
using TreinamentoWeb.Infraestrutura.Context;

namespace TreinamentoWeb.Repositorio.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : Entidade
    {
        public void Atualizar(T entidade)
        {
            using (var contexto = new TreinamentoWebDbContext())
            {
                contexto.Set<T>().Attach(entidade);
                contexto.Entry(entidade).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }

        public T BuscarPorId(int id)
        {
            using (var contexto = new TreinamentoWebDbContext())
            {
                return contexto.Set<T>().Find(id);
            }
        }

        public Task<List<T>> BuscarTodos()
        {
            return Task.Run(() =>
            {
                using (var contexto = new TreinamentoWebDbContext())
                {
                    return contexto.Set<T>().ToList();
                }
            });
        }

        public void Excluir(T entidade)
        {
            using (var contexto = new TreinamentoWebDbContext())
            {
                contexto.Set<T>().Attach(entidade);
                contexto.Entry(entidade).State = EntityState.Deleted;
                contexto.SaveChanges();
            }
        }

        public void Inserir(T entidade)
        {
            using (var contexto = new TreinamentoWebDbContext())
            {
                contexto.Set<T>().Add(entidade);
                contexto.SaveChanges();
            }
        }
    }
}