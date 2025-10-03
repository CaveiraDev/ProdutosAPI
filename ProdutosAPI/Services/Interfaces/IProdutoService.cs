using ProdutosAPI.Domain.Entities;

namespace ProdutosAPI.Services.Interfaces
{
    public interface IProdutoService 
    {
        Produto? Obtenha(int id);
        List<Produto> ObtenhaTodos();
        void Crie(Produto produto);
        Produto Atualize(Produto produto);
        void Remova(int id);

    }
}
