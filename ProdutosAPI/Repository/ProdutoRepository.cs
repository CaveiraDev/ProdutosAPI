using ProdutosAPI.Domain.Entities;
using ProdutosAPI.Repository.Insterfaces;

namespace ProdutosAPI.Repository
{
    public class ProdutoRepository : IRepository
    {
        private static List<Produto>? _cache;
        private static int _proximoId = _cache?.Count ?? 0;

        private List<Produto> ObtenhaCache()
        {
            if (_cache is null or [])
            {
                _cache =
                [
                    new Produto(1, "Notebook Dell", "Informática", 3500.00m, 10),
                    new Produto(2, "Smartphone Samsung", "Eletrônicos", 2500.00m, 5),
                    new Produto(3, "Cafeteira", "Eletrodomésticos", 199.99m, 20),
                    new Produto(4, "Fone de Ouvido", "Acessórios", 149.90m, 0),
                    new Produto(5, "Monitor LG", "Informática", 899.00m, 7)
                ];
            }
            return _cache;
        }

        public List<Produto> ObtenhaTodos() => ObtenhaCache();

        public Produto? Obtenha(int id) => ObtenhaCache().FirstOrDefault(p => p.Id == id);

        public void Crie(Produto produto)
        {
            produto.Id = _proximoId++;
            ObtenhaCache().Add(produto);
        }

        public Produto Atualize(Produto produto)
        {
            var produtoExistente = Obtenha(produto.Id)
                ?? throw new KeyNotFoundException($"Produto com ID {produto.Id} não encontrado");

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Categoria = produto.Categoria;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.Quantidade = produto.Quantidade;

            return produtoExistente;
        }

        public void Remova(int id)
        {
            var produto = Obtenha(id)
                ?? throw new KeyNotFoundException($"Produto com ID {id} não encontrado");

            ObtenhaCache().Remove(produto);
        }
    }
}