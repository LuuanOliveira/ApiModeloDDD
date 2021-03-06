﻿using ApiModeloDDD.Domain.Entitys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApiModeloDDD.Application.Interfaces
{
    public interface IApplicationServiceProduto
    {
        void Importar(IFormFile file);
        IEnumerable<ResumoProduto> GetImportacoes();
        Produto GetImportacao(Guid Id);
        void AtualizarProduto(Produto produto);
    }
}