using ProdutosAPI.Domain.Entities;

namespace xUnitTestesProdutos
{
    public class ProdutoTests
    {
        [Fact]
        public void Produto_DeveCriarComSucesso_QuandoDadosValidos()
        {
            // Arrange & Act
            Produto produto = new (1,"Notebook", "Informática", 3500.00m, 10);

            // Assert
            Assert.Equal(1, produto.Id);
            Assert.Equal("Notebook", produto.Nome);
            Assert.Equal("Informática", produto.Categoria);
            Assert.Equal(3500.00m, produto.Preco);
            Assert.Equal(10, produto.Quantidade);
            Assert.True(produto.Data <= DateTime.Now);
        }

        [Fact]
        public void Disponivel_DeveRetornarTrue_QuandoQuantidadeMaiorQueZero()
        {
            // Arrange
            Produto produto = new (1, "Mouse", "Acessórios", 50.00m, 5);

            // Act
            bool disponivel = produto.Disponivel;
          
            // Assert
            Assert.True(disponivel);
        }

        [Fact]
        public void Disponivel_DeveRetornarFalse_QuandoQuantidadeIgualAZero()
        {
            // Arrange
            Produto produto = new(1, "Teclado", "Acessórios", 150.00m, 0);

            // Act
            bool disponivel = produto.Disponivel;

            // Assert
            Assert.False(disponivel);
        }

        [Fact]
        public void Disponivel_DeveAtualizarAutomaticamente_QuandoQuantidadeMuda()
        {
            // Arrange
            Produto produto = new (1, "Monitor", "Informática", 899.00m, 5);

            // Act - Produto inicialmente disponível
            Assert.True(produto.Disponivel);

            // Act - Zera quantidade
            produto.Quantidade = 0;

            // Assert - Produto não deve estar mais disponível
            Assert.False(produto.Disponivel);
        }

        [Fact]
        public void DataInclusao_DeveSerGeradaAutomaticamente()
        {
            // Arrange
            DateTime dataAntes = DateTime.Now;

            // Act
            Produto produto = new Produto(1, "Produto Teste", "Categoria Teste", 100.00m, 1);
            DateTime dataDepois = DateTime.Now;

            // Assert
            Assert.True(produto.Data >= dataAntes && produto.Data <= dataDepois);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(10)]
        [InlineData(100)]
        public void Disponivel_DeveRetornarTrue_ParaQualquerQuantidadePositiva(int quantidade)
        {
            // Arrange
            Produto produto = new (1, "Produto", "Categoria", 50.00m, quantidade);

            // Act & Assert
            Assert.True(produto.Disponivel);
        }

        [Fact]
        public void Produto_DevePermitirAlterarPropriedades()
        {
            // Arrange
            Produto produto = new(1, "Nome Original", "Categoria Original", 100.00m, 5);

            // Act
            produto.Nome = "Nome Atualizado";
            produto.Categoria = "Categoria Atualizada";
            produto.Preco = 200.00m;
            produto.Quantidade = 15;

            // Assert
            Assert.Equal("Nome Atualizado", produto.Nome);
            Assert.Equal("Categoria Atualizada", produto.Categoria);
            Assert.Equal(200.00m, produto.Preco);
            Assert.Equal(15, produto.Quantidade);
            Assert.True(produto.Disponivel);
        }
    }
}