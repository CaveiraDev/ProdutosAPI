using ProdutosAPI.Domain.Entities;
using ProdutosAPI.Repository.Insterfaces;

namespace ProdutosAPI.Repository
{
    public class ProdutoRepository : IRepository
    {

        public void Crie(Produto produto)
        {
            List<Produto> produtos = [.. ObtenhaTodos()];

            produtos.Add(produto);
        }

        public Produto? Obtenha(int id) => ObtenhaTodos().FirstOrDefault(p => p.Id == id);

        public List<Produto> ObtenhaTodos() =>
            [
                new Produto(1,"Notebook Dell", "Informática", 3500.00m, 10),
                new Produto(2,"Smartphone Samsung", "Eletrônicos", 2500.00m, 5),
                new Produto(3,"Cafeteira", "Eletrodomésticos", 199.99m, 20),
                new Produto(4,"Fone de Ouvido", "Acessórios", 149.90m, 0),
                new Produto(5,"Monitor LG", "Informática", 899.00m, 7)
            ];

        public Produto Atualize(Produto produto)
        {
            Produto produtoExistente = Obtenha(produto.Id)!;

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Categoria = produto.Categoria;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.Quantidade = produto.Quantidade;

            return produtoExistente;
        }

        public void Remova(int id)
        {
            ObtenhaTodos().RemoveAll(p => p.Id == id);
        }
    }
}
