using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProdutoApi.Model;
using Produtos.Domain.Entities;
using Produtos.Domain.Services.Interfaces;
using System.Threading.Tasks;

namespace ProdutoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly ILogger<ProdutoController> _logger;
        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(ILogger<ProdutoController> logger, IProdutoService produtoService,IMapper mapper)
        {
            _logger = logger;
            _produtoService = produtoService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Lista de produto
        /// </summary>
        /// <returns>Objetos contendo valores de produto</returns>
        [HttpGet]
        [Route("list")]
        public async Task<ActionResult> GetProdutos() {
            var produtos = await _produtoService.ListarProdutos();
            return Ok(produtos);        
        }

        /// <summary>
        /// Get Lista de produto por categoria
        /// </summary>
        /// <returns>Objetos contendo valores de produto</returns>
        [HttpGet]
        [Route("list/{idCategoria}")]
        public async Task<ActionResult> GetProdutosIdCategoria(int idCategoria)
        {
            var produtos = await _produtoService.ListarProdutosPorCategoria(idCategoria);
            return Ok(produtos);
        }

        /// <summary>
        /// Editar produto
        /// </summary>
        /// <returns>Objetos contendo valores de produto</returns>
        [HttpPut]
        [Route("edit/{id}")]
        public async Task<ActionResult> EditProduto(int id, [FromBody] ProdutoModel model) {
            var result = await _produtoService.UpdateProduto(id,_mapper.Map<Produto>(model));
            return Ok(result);
        }

        /// <summary>
        /// Excluir logicamente o produto
        /// </summary>
        /// <returns>Messagem de texto</returns>
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> DeleteProduto(int id)
        {
            var result = await _produtoService.DeletarProduto(id);
            if (result)
                return Ok("Produto excluido com sucesso");

            return BadRequest("Não foi possivel excluir produto");
        }

        /// <summary>
        /// Create produto
        /// </summary>
        /// <returns>Result</returns>
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> CreateProduto([FromBody] ProdutoModel model)
        {
            var result = await _produtoService.InserirProduto(_mapper.Map<Produto>(model));
            if (result != null)
                return Ok(result);

            return BadRequest("Não foi possivel salvar produto produto");
        }

    }
}
