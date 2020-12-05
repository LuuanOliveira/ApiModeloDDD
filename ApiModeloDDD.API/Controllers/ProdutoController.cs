using ApiModeloDDD.Application.Interfaces;
using ApiModeloDDD.Domain.Entitys;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ApiModeloDDD.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IApplicationServiceProduto _applicationServiceProduto;
        public ProdutoController(IApplicationServiceProduto applicationServiceProduto)
        {
            _applicationServiceProduto = applicationServiceProduto;
        }

        /// <summary>
        /// Realiza a importação do produto.
        /// </summary>
        /// <response code="200">Importação realizada com sucesso.</response>
        /// <response code="400">O modelo da importação enviado é inválido.</response>
        [HttpPost]
        [Route("Importar")]
        public IActionResult ImportarProduto(IFormFile file)
        {
            try
            {
                _applicationServiceProduto.Importar(file);
                return new ObjectResult("Importação realizada");
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 400 };
            }
        }

        /// <summary>
        /// Retorna uma lista com todos os produtos cadastrados.
        /// </summary>
        /// <response code="200">A lista de importações foi obtida com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao obter a lista de importações.</response>
        [HttpGet]
        [Route("GetImportacoes")]
        public IActionResult GetImportacoes()
        {
            try
            {
                return new ObjectResult(_applicationServiceProduto.GetImportacoes());
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 400 };
            }
        }

        /// <summary>
        /// Retorna um produto específico por ID.
        /// </summary>
        /// <response code="200">A importação foi obtido com sucesso.</response>
        /// <response code="404">Não foi encontrada importação com ID especificado.</response>
        [HttpGet]
        [Route("GetImportacao")]
        public IActionResult GetImportacao(Guid Id)
        {
            try
            {
                return new ObjectResult(_applicationServiceProduto.GetImportacao(Id));
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 404 };
            }
        }

        /// <summary>
        /// Atualiza um produto específico por ID.
        /// </summary>
        /// <response code="200">Atualização realizada com sucesso.</response>
        /// <response code="400">Não foi possível atualizar produto com ID especificado.</response>
        [HttpPut]
        [Route("Atualizar")]
        public IActionResult AtualizarProduto([FromBody] Produto produto)
        {
            try
            {
                _applicationServiceProduto.AtualizarProduto(produto);
                return new ObjectResult("Atualização realizada");
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 404 };
            }
        }
    }
}