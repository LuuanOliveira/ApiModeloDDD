using ApiModeloDDD.Application.Interfaces;
using ApiModeloDDD.Application.Interfaces.Mappers;
using ApiModeloDDD.Domain.Core.Interfaces.Repositorys;
using ApiModeloDDD.Domain.Entitys;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ApiModeloDDD.Application
{
    public class ApplicationServiceProduto : IApplicationServiceProduto
    {
        IProdutoRepository _produtoRepository;

        public ApplicationServiceProduto(IProdutoRepository produtoRepository) => _produtoRepository = produtoRepository;

        public void Importar(IFormFile file) => _produtoRepository.Importar(file);
        public IEnumerable<ResumoProduto> GetImportacoes() => _produtoRepository.GetImportacoes();
        public Produto GetImportacao(Guid Id) => _produtoRepository.GetImportacao(Id);
    }
}