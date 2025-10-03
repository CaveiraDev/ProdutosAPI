using ProdutosAPI.Domain.Entities;

namespace ProdutosAPI.Repository.Insterfaces
{
    public interface IRepository
    {
        void Crie(Produto produto);
        Produto? Obtenha(int id);
        List<Produto> ObtenhaTodos();
        Produto Atualize(Produto produto);
        void Remova(int id);
    }
}
