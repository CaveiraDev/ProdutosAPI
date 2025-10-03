namespace ProdutosAPI.Validations.Interfaces
{
    public interface IValidador<T>
    where T : class
    {
        void Valide(T instancia);
    }
}
