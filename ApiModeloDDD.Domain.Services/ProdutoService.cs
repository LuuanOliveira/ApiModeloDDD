using ApiModeloDDD.Domain.Core.Interfaces.Repositorys;
using ApiModeloDDD.Domain.Core.Interfaces.Services;
using ApiModeloDDD.Domain.Entitys;
using System;
using System.Collections.Generic;

namespace ApiModeloDDD.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        public IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository) => _produtoRepository = produtoRepository;
        public IEnumerable<ResumoProduto> GetImportacoes() => _produtoRepository.GetImportacoes();
        public Produto GetImportacao(Guid Id) => _produtoRepository.GetImportacao(Id);
    }
}