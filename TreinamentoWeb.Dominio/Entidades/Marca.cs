using System.Collections.Generic;

namespace TreinamentoWeb.Dominio.Entidades
{
    public class Marca : Entidade
    {
        public string Nome { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}
