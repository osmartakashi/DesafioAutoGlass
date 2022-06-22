using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos.ProdutoDtos;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private IProdutoGestor _produtoGestor;
        public ProdutoController(IProdutoGestor produtoGestor)
        {
            _produtoGestor = produtoGestor;
        }
        /// <summary>
        /// Obtém um produto pelo seu código.
        /// Para o exemplo, pode-se usar o código = 1
        /// </summary>
        /// <param name="codigo"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]        
        public IActionResult ObterPorCodigo(int codigo)
        {
            var produto = _produtoGestor.ObterPorCodigo(codigo);
            if (produto != null)
                return Ok(produto);
            return NoContent();
        }

        /// <summary>
        /// Lista os produtos com paginação. Os parâmetros são pagina e itensPorPagina ambos como query string
        /// O valor default para itensPorPagina é 5
        /// </summary>
        /// <param name="pagina"></param>
        /// <param name="itensPorPagina"></param>
        /// <returns></returns>
        [HttpGet("listar")]
        public IActionResult Listar([FromQuery] int pagina,[FromQuery] int itensPorPagina = 5)
        {
            var produtos = _produtoGestor.Listar(pagina, itensPorPagina);
            return Ok(produtos);
        }

        /// <summary>
        /// Filtra produtos com base nos parâmetros passado via dto
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        [HttpPost("filtrar")]
        public IActionResult Filtrar(SelectProdutoDto filtro)
        {
            if (ModelState.IsValid)
            {
                return Ok(_produtoGestor.Filtrar(filtro));
            }
            return BadRequest();
        }

        /// <summary>
        /// Cria um novo produto
        /// </summary>
        /// <param name="produtoDto"></param>
        /// <returns></returns>
        [HttpPost("novo")]
        public IActionResult Inserir(CreateProdutoDto produtoDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(_produtoGestor.Inserir(produtoDto));
            }
            return BadRequest();
        }

        /// <summary>
        /// Edita um produto
        /// </summary>
        /// <param name="produtoDto"></param>
        /// <returns></returns>
        [HttpPost("editar")]
        public IActionResult Editar(UpdateProdutoDto produtoDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(_produtoGestor.Editar(produtoDto));
            }
            return BadRequest();
        }

        /// <summary>
        /// Excluir um produto. A exclusão é apenas lógica, setando o campo Situacao como Inativo
        /// </summary>
        /// <param name="produtoDto"></param>
        /// <returns></returns>
        [HttpPost("excluir")]
        public IActionResult Excluir(UpdateProdutoDto produtoDto)
        {
            if (ModelState.IsValid)
            {
                return Ok(_produtoGestor.Excluir(produtoDto));
            }
            return BadRequest();
        }
    }
}
