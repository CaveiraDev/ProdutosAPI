using FluentValidation;
using ProdutosAPI.Domain.Entities;
using ProdutosAPI.Repository;

namespace ProdutosAPI.Validations
{
    public class ValidadorProduto : ValidadorAbstratoCadastro<Produto>
    {

        public override void AssineRegrasInclusao()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage(CAMPO_NULO_OU_VAZIO)
                .NotNull()
                .WithMessage(CAMPO_OBRIGATORIO_NAO_INFORMADO)
                .MaximumLength(200)
                .WithMessage("Nome não pode ter mais de 100 caracteres.");

            RuleFor(p => p.Categoria)
                .NotEmpty()
                .WithMessage(CAMPO_NULO_OU_VAZIO)
                .NotNull()
                .WithMessage(CAMPO_OBRIGATORIO_NAO_INFORMADO)
                .MaximumLength(100)
                .WithMessage("Categoria não pode ter mais de 100 caracteres.");

            RuleFor(p => p.Preco)
                .GreaterThan(0)
                .WithMessage(CAMPO_DEVE_SER_MAIOR_QUE_ZERO)
                .LessThanOrEqualTo(999999.99m)
                .OverridePropertyName("Preço")
                .WithMessage("Preço não pode ser maior que 999999.99.");

            RuleFor(p => p.Quantidade)
                .GreaterThanOrEqualTo(0)
                .WithMessage(CAMPO_DEVE_SER_MAIOR_QUE_ZERO)
                .LessThanOrEqualTo(100000)
                .WithMessage("Quantidade não pode ser maior que 100000.");

            RuleFor(p => p)
               .Custom((m, context) =>
               {
                   bool possuiRegistro = new ProdutoRepository().Obtenha(m.Id) != null;
                   if (possuiRegistro)
                   {
                       context.AddFailure($"Produto com ID {m.Id} já cadastrado.");
                   }
               });
        }

        public override void AssineRegrasAtualizacao()
        {
            AssineRegrasInclusao();

            RuleFor(p => p)
               .Custom((m, context) =>
               {
                   bool possuiRegistro = new ProdutoRepository().Obtenha(m.Id) != null;
                   if (!possuiRegistro)
                   {
                       context.AddFailure($"Produto com ID {m.Id} não encontrado.");
                   }
               });
        }

        public override void AssineRegrasExclusao()
        {
            RuleFor(p => p.Id)
            .GreaterThan(0)
            .WithMessage(CAMPO_DEVE_SER_MAIOR_QUE_ZERO);

            RuleFor(p => p)
                .Custom((m, context) =>
                {
                    bool possuiRegistro = new ProdutoRepository().Obtenha(m.Id) != null;
                    if (!possuiRegistro)
                    {
                        context.AddFailure($"Produto com ID {m.Id} não encontrado.");
                    }
                });
        }

    }
}
