﻿namespace ProdutosAPI.Models
{
    public class ProdutoModel(int id, string nome, string categoria, decimal preco, int quantidade)
    {
        public int Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public string Categoria { get; set; } = categoria;
        public decimal Preco { get; set; } = preco;
        public int Quantidade { get; set; } = quantidade;
        public DateTime DataInclusao { get;} = DateTime.Now;

        public bool Disponivel => Quantidade > 0;

    }
}
