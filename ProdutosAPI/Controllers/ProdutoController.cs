using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Domain.Entities;
using ProdutosAPI.Domain.Exceptions;
using ProdutosAPI.DTOs;
using ProdutosAPI.Services;
using ProdutosAPI.Validations;

namespace ProdutosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutosController : ControllerBase
    {
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
                _validador.AssineRegrasInclusao();
                _validador.Valide(produto);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }

            Produto novoProduto = produto;

            _servicos.Crie(novoProduto);

            return CreatedAtRoute("ObtenhaProdutoPorId", new { id = novoProduto.Id }, novoProduto);
        }

        [HttpPut("{id}", Name = "Atualize")]
        public ActionResult<Produto> Put(int id, [FromBody] ProdutoDto produtoDto)
        {
            Produto produtoE = Converta(produtoDto);
            produtoE.Id = id;
            try
            {
                _validador.AssineRegrasAtualizacao();
                _validador.Valide(produtoE);
            }
            catch (ValidacaoException ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }


            Produto produto = _servicos.Atualize(produtoE);
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

        public Produto Converta(ProdutoDto dto) => new()
        {
            Id = dto.Id,
            Nome = dto.Nome,
            Categoria = dto.Categoria,
            Preco = dto.Preco,
            Quantidade = dto.Quantidade
        };
    }
}