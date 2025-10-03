using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Domain.Entities;
using ProdutosAPI.Domain.Exceptions;
using ProdutosAPI.DTOs;
using ProdutosAPI.Services;

namespace ProdutosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly ProdutoService _servicos;

        public ProdutosController()
        {
            _servicos = new ProdutoService();
        }

        [HttpGet(Name = "ObtenhaTodos")]
        public ActionResult<IEnumerable<Produto>> Get()
        {
            IEnumerable <Produto> produtos = _servicos.ObtenhaTodos();
            return Ok(produtos);
        }

        [HttpGet("{id}", Name = "Obtenha")]
        public ActionResult<Produto> GetById(int id)
        {
            Produto? produto = _servicos.Obtenha(id);

            if (produto is null)
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
                _servicos.Crie(produto);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

            return CreatedAtRoute("Obtenha", new { id = produto.Id }, produto);
        }

        [HttpPut("{id}", Name = "Atualize")]
        public ActionResult<Produto> Put(int id, [FromBody] ProdutoDto produtoDto)
        {
            Produto produto = new()
            {
                Id = id,
                Nome = produtoDto.Nome,
                Categoria = produtoDto.Categoria,
                Quantidade = produtoDto.Quantidade,
                Preco = produtoDto.Preco
            };

            try
            {
                produto = _servicos.Atualize(produto);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

            return Ok(produto);
        }

        [HttpDelete("{id}", Name = "Remova")]
        public ActionResult Delete(int id)
        {
            Produto produto = _servicos.ObtenhaTodos().FirstOrDefault(p => p.Id == id);

            if (produto is null)
            {
                return NotFound(new { mensagem = $"Produto com ID {id} não encontrado." });
            }

            _servicos.Remova(id);

            return NoContent();
        }

    }
}