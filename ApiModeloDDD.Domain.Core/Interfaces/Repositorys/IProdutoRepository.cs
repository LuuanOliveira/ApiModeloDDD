using ApiModeloDDD.Domain.Entitys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Domain.Core.Interfaces.Repositorys
{
    public interface IProdutoRepository /*: IRepository<Produto>*/
    {
        Task<Produto> Importar(IFormFile file);
        IEnumerable<ResumoProduto> GetImportacoes();
        Produto GetImportacao(Guid Id);
    }
}