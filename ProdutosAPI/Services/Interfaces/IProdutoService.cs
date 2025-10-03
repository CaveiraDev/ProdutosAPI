using ProdutosAPI.Domain.Entities;

namespace ProdutosAPI.Services.Interfaces
{
    public interface IProdutoService 
    {
        Produto Obtenha(int id);
        IEnumerable<Produto> ObtenhaTodos();
        void Crie(Produto produto);
        void Atualize(Produto produto);
        void Remova(int id);

    }
}
