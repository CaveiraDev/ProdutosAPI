using ProdutosAPI.Validations.Interfaces;

namespace ProdutosAPI.Validations
{
    public abstract class ValidadorAbstratoCadastro<T> : ValidadorAbstrato<T>, IValidador<T>
        where T : class
    {
        public abstract void AssineRegrasInclusao();
        public abstract void AssineRegrasAtualizacao();
        public abstract void AssineRegrasExclusao();
    }
}