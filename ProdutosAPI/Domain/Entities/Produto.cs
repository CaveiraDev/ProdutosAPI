namespace ProdutosAPI.Domain.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataInclusao { get; } = DateTime.Now;

        public bool Disponivel => Quantidade > 0;

        public Produto(int id, string nome, string categoria, decimal preco, int quantidade)
        {
            Id = id;
            Nome = nome;
            Categoria = categoria;
            Preco = preco;
            Quantidade = quantidade;
        }

        public Produto() : this(0, string.Empty, string.Empty, 0m, 0) { }
    }
}
