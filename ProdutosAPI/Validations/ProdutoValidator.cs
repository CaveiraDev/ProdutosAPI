using FluentValidation;
using ProdutosAPI.Models;

namespace ProdutosAPI.Validations
{
    public class ProdutoValidator : AbstractValidator<ProdutoModel>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("Nome não pode ser nulo ou vazio.")
                .NotNull()
                .WithMessage("Nome é obrigatório.")
                .MaximumLength(200)
                .WithMessage("Nome não pode ter mais de 200 caracteres.");

            RuleFor(p => p.Categoria)
                .NotEmpty()
                .WithMessage("Categoria não pode ser nula ou vazia.")
                .NotNull()
                .WithMessage("Categoria é obrigatória.")
                .MaximumLength(100)
                .WithMessage("Categoria não pode ter mais de 100 caracteres.");

            RuleFor(p => p.Preco)
                .GreaterThan(0)
                .WithMessage("Preço deve ser maior que 0.")
                .LessThanOrEqualTo(999999.99m)
                .WithMessage("Preço não pode ser maior que 999999.99.");

            RuleFor(p => p.Quantidade)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Quantidade deve ser maior ou igual a 0.")
                .LessThanOrEqualTo(100000)
                .WithMessage("Quantidade não pode ser maior que 100000.");
        }
    }
 }
