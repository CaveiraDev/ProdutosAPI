using FluentValidation;
using FluentValidation.Results;
using ProdutosAPI.Domain.Exceptions;
using ProdutosAPI.Validations.Interfaces;

namespace ProdutosAPI.Validations
{
    public abstract class ValidadorAbstrato<T> : AbstractValidator<T>, IValidador<T>
        where T : class
    {
        public const string CAMPO_DEVE_SER_MAIOR_QUE_ZERO = "{PropertyName} deve ser maior que zero.";
        public const string CAMPO_OBRIGATORIO_NAO_INFORMADO = "{PropertyName} é de preenchimento obrigatório.";
        public const string CAMPO_NULO_OU_VAZIO = "{PropertyName} não pode ser nulo ou vazio..";


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
