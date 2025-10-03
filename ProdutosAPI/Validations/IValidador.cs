namespace ProdutosAPI.Validations
{
    public interface IValidador<T>
    where T : class
    {
        void Valide(T instancia);
    }
}
