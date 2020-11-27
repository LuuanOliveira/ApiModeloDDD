using ApiModeloDDD.Application.Dtos;
using ApiModeloDDD.Application.Interfaces.Mappers;
using ApiModeloDDD.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ApiModeloDDD.Application.Mappers
{
    public class MapperProduto : IMapperProduto
    {
        public Produto MapperDtoToEntity(ProdutoDto produtoDto)
        {
            var produto = new Produto()
            {
                id = produtoDto.id
                ,
                descricao = produtoDto.descricao
                ,
                dataImportacao = produtoDto.dataImportacao
                ,
                dataEntrega = produtoDto.dataEntrega
                ,
                quantidade = produtoDto.quantidade
                ,
                valorUnitario = produtoDto.valorUnitario
                ,
                valorTotal = produtoDto.valorTotal
                ,
                ativo = produtoDto.ativo
            };

            return produto;
        }

        public ProdutoDto MapperEntityToDto(Produto produto)
        {
            var produtoDto = new ProdutoDto()
            {
                id = produto.id
                ,
                descricao = produto.descricao
                ,
                dataImportacao = produto.dataImportacao
                ,
                dataEntrega = produto.dataEntrega
                ,
                quantidade = produto.quantidade
                ,
                valorUnitario = produto.valorUnitario
                ,
                valorTotal = produto.valorTotal
                ,
                ativo = produto.ativo
            };

            return produtoDto;
        }

        public IEnumerable<ProdutoDto> MapperListProdutosDto(IEnumerable<Produto> produtos)
        {
            var dto = produtos.Select(c => new ProdutoDto
            {
                id = c.id
                                                            ,
                descricao = c.descricao
                                                            ,
                dataImportacao = c.dataImportacao
                                                            ,
                dataEntrega = c.dataEntrega
                                                            ,
                quantidade = c.quantidade
                                                            ,
                valorUnitario = c.valorUnitario
                                                            ,
                valorTotal = c.valorTotal
                                                            ,
                ativo = c.ativo
            })
            ;

            return dto;
        }
    }
}