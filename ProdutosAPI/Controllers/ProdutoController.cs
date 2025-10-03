using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Domain.Entities;
using ProdutosAPI.Domain.Exceptions;
using ProdutosAPI.Services;
using ProdutosAPI.Validations;

namespace ProdutosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private static List<Produto> _produtos =
        [
            new (1,"Notebook Dell", "Informática", 3500.00m, 10),
            new (2, "Smartphone Samsung", "Eletrônicos", 2500.00m, 5),
            new (3, "Cafeteira", "Eletrodomésticos", 199.99m, 20),
            new (4, "Fone de Ouvido", "Acessórios", 149.90m, 0),
            new (5, "Monitor LG", "Informática", 899.00m, 7)
        ];

        private readonly ValidadorProduto _validador;
        private readonly ProdutoService _servicos;

        public ProdutosController()
        {
            _validador = new ValidadorProduto();
            _servicos = new ProdutoService();
        }

        [HttpGet(Name = "ObtenhaTodos")]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            return Ok(_produtos);
        }

        [HttpGet("{id}", Name = "Obtenha")]
        public ActionResult<Produto> GetById(int id)
        {
            Produto produto = _produtos.FirstOrDefault(p => p.Id == id);

            if (produto == null)
            {
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado." });
            }

            return Ok(produto);
        }

        [HttpPost(Name = "Crie")]
        public ActionResult<Produto> Post([FromBody] Produto produto)
        {

            try
            {
                _validador.AssineRegrasInclusao();
                _validador.Valide(produto);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

            Produto novoProduto = produto;

            _produtos.Add(novoProduto);

            return CreatedAtRoute("ObtenhaProdutoPorId", new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}", Name = "Atualize")]
        public ActionResult<Produto> Put(int id, [FromBody] Produto produto)
        {
            Produto produtoExistente = _produtos.FirstOrDefault(p => p.Id == id);

            if (produtoExistente == null)
            {
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado." });
            }

            try
            {
                _validador.AssineRegrasAtualizacao();
                _validador.Valide(produto);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

            produtoExistente.Nome = produto.Nome;
            produtoExistente.Categoria = produto.Categoria;
            produtoExistente.Preco = produto.Preco;
            produtoExistente.Quantidade = produto.Quantidade;

            return Ok(produtoExistente);
        }

        [HttpDelete("{id}", Name = "Remova")]
        public ActionResult Delete(int id)
        {
            Produto produto = _produtos.FirstOrDefault(p => p.Id == id);

            if (produto is null)
            {
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado." });
            }

            _produtos.Remove(produto);

            return NoContent();
        }

    }
}