namespace ProdutosAPI.DTOs
{
    public class ProdutoDto(string nome,string categoria,decimal preco, int quantidade)
    {
        public int Id { get; set; }
        public string Nome { get; set; } = nome;
        public string Categoria { get; set; } = categoria;
        public decimal Preco { get; set; } = preco;
        public int Quantidade { get; set; } = quantidade;
    }
}
