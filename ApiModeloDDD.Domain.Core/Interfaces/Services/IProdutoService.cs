using ApiModeloDDD.Domain.Entitys;
using System;
using System.Collections.Generic;

namespace ApiModeloDDD.Domain.Core.Interfaces.Services
{
    public interface IProdutoService
    {
        //void Importar(Produto produto);
        IEnumerable<ResumoProduto> GetImportacoes();
        Produto GetImportacao(Guid Id);
    }
}