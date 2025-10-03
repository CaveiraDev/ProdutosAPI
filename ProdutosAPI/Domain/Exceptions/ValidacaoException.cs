using FluentValidation.Results;

namespace ProdutosAPI.Domain.Exceptions
{
    public class ValidacaoException(ValidationResult validationResult) : ApplicationException
    {
        public IList<ValidationFailure> Errors { get; } = validationResult.Errors;

        public override string Message => string.Join("\n", Errors.Select(x => x.ErrorMessage));

        public string FirstErrorMessage =>
            Errors[0]
                .ErrorMessage;
    }
}
