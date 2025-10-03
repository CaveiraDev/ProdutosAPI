using FluentValidation.Results;

namespace ProdutosAPI.Exceptions
{
    public class ValidacaoException(FluentValidation.Results.ValidationResult validationResult) : ApplicationException
    {
        public IList<ValidationFailure> Errors { get; } = validationResult.Errors;

        public override string Message => string.Join("\n", Errors.Select(x => x.ErrorMessage));

        public string FirstErrorMessage =>
            Errors[0]
                .ErrorMessage;
    }
}
