using ApiModeloDDD.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        //void Importar(Produto produto);
        IEnumerable<Produto> GetImportacoes();
        Produto GetImportacao(Guid Id);
    }
}