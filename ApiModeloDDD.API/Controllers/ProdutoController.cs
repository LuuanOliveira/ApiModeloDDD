using ApiModeloDDD.Application.Interfaces;
using ApiModeloDDD.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;
using System;

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
        /// Realizar uma importação.
        /// </summary>
        /// <param name="importar">Modelo de importação.</param>
        /// <response code="200">Importação realizada com sucesso.</response>
        /// <response code="400">O modelo da importação enviado é inválido.</response>
        [HttpPost]
        [Route("Importar")]
        public IActionResult ImportarProduto([FromBody] Produto produto)
        {
            try
            {
                return new ObjectResult("OK") { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 400 };
            }
        }

        /// <summary>
        /// Obter todas as importações.
        /// </summary>
        /// <response code="200">A lista de importações foi obtida com sucesso.</response>
        /// <response code="400">Ocorreu um erro ao obter a lista de importações.</response>
        [HttpGet]
        [Route("GetImportacoes")]
        public IActionResult GetImportacoes()
        {
            try
            {
                _applicationServiceProduto.GetImportacoes();
                return new ObjectResult("OK") { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 400 };
            }
        }

        /// <summary>
        /// Obter uma importação específica por ID.
        /// </summary>
        /// <param name="id">ID da importação.</param>
        /// <response code="200">A importação foi obtido com sucesso.</response>
        /// <response code="400">Não foi encontrada importação com ID especificado.</response>
        [HttpGet]
        [Route("GetImportacao")]
        public IActionResult GetImportacao(Guid Id)
        {
            try
            {
                _applicationServiceProduto.GetImportacao(Id);
                return new ObjectResult("OK") { StatusCode = 200 };
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = 400 };
            }
        }
    }
}