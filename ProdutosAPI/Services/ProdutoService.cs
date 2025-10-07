using ProdutosAPI.Domain.Entities;
using ProdutosAPI.Repository;
using ProdutosAPI.Services.Interfaces;
using ProdutosAPI.Validations;

namespace ProdutosAPI.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoRepository _repository;
        private readonly ValidadorProduto _validador;

        public ProdutoService() 
        {
            _repository = new ProdutoRepository();
            _validador = new ValidadorProduto();

        }

        public void Crie(Produto produto)
        {
            _validador.AssineRegrasInclusao();
            _validador.Valide(produto);

            _repository.Crie(produto);
        }

        public Produto? Obtenha(int id) => _repository.Obtenha(id);

        public List<Produto> ObtenhaTodos() => _repository.ObtenhaTodos();

        public Produto Atualize(Produto produto)
        {
            _validador.AssineRegrasAtualizacao();
            _validador.Valide(produto);

            return _repository.Atualize(produto);
        }

        public void Remova(int id)
        {
            _repository.Remova(id);
        }
    }
}
