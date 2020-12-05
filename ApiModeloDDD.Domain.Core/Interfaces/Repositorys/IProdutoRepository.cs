using ApiModeloDDD.Domain.Entitys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiModeloDDD.Domain.Core.Interfaces.Repositorys
{
    public interface IProdutoRepository /*: IRepository<Produto>*/
    {
        void Importar(IFormFile file);
        IEnumerable<ResumoProduto> GetImportacoes();
        Produto GetImportacao(Guid Id);
        void AtualizarProduto(Produto produto);
    }
}