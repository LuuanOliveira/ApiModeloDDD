using ApiModeloDDD.Domain.Entitys;
using System;
using System.Collections.Generic;

namespace ApiModeloDDD.Domain.Core.Interfaces.Repositorys
{
    public interface IProdutoRepository /*: IRepository<Produto>*/
    {
        //void Importar(Produto produto);
        IEnumerable<ResumoProduto> GetImportacoes();
        Produto GetImportacao(Guid Id);
    }
}