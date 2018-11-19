namespace TreinamentoWeb.Dominio.Entidades
{
    public class Produto : Entidade
    {
        public string Nome { get; set; }
        public int IdMarca { get; set; }
        public Marca Marca { get; set; }
    }
}
