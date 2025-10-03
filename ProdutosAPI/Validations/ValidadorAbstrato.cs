using FluentValidation;
using FluentValidation.Results;
using ProdutosAPI.Exceptions;

namespace ProdutosAPI.Validations
{
    public abstract class ValidadorAbstrato<T> : AbstractValidator<T>, IValidador<T>
        where T : class
    {
        public void Valide(T instancia)
        {
            ValidationResult validationResult = Validate(instancia);

            if (!validationResult.IsValid)
            {
                throw new ValidacaoException(validationResult);
            }
        }
    }
}
