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
        public async Task<IActionResult> ImportarProduto(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                    throw new Exception("Arquivo inválido");
                else
                    return new ObjectResult("Importados: " + await _applicationServiceProduto.Importar(file));
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
    }
}