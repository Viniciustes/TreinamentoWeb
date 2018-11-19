using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TreinamentoWeb.Dominio.Entidades;
using TreinamentoWeb.Infraestrutura.Context;

namespace TreinamentoWeb.Repositorio.Repositorio
{
    public class RepositorioProduto : Repositorio<Produto>
    {
        public new Task<List<Produto>> BuscarTodos()
        {
            return Task.Run(() =>
            {
                using (var contexto = new TreinamentoWebDbContext())
                {
                    return contexto.Produtos.Include("Marca").ToList();
                }
            });
        }

        public new Produto BuscarPorId(int id)
        {
            using (var contexto = new TreinamentoWebDbContext())
            {
                return contexto.Produtos.Include("Marca").FirstOrDefault(x => x.Id == id);
            }
        }

        public new void Inserir(Produto entidade)
        {
            using (var contexto = new TreinamentoWebDbContext())
            {
                var marca = contexto.Marcas.Find(entidade.IdMarca);
                entidade.Marca = marca;

                contexto.Produtos.Add(entidade);
                contexto.SaveChanges();
            }
        }

        public new void Atualizar(Produto entidade)
        {
            using (var contexto = new TreinamentoWebDbContext())
            {
                var marca = contexto.Marcas.Find(entidade.IdMarca);
                entidade.Marca = marca;

                contexto.Produtos.Attach(entidade);
                contexto.Entry(entidade).State = EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}