using System;
using Xunit;
using ApiModeloDDD.Domain.Entitys;

namespace ApiModeloDDD.Domain.Test.Test
{
    public class Test
    {
        

        [Fact]
        public void Produto_CriarProduto_RetornaProduto()
        {
            #region Criar um produto com os seguintes dados: id, descricao, dataImportacao, dataEntrega, quantidade, valorUnitario, valorTotal, ativo

            var produtoEsperado = new Produto()
            {
                id = (Guid) Guid.NewGuid(),
                descricao = "Soja",
                dataImportacao = (DateTime) DateTime.Now,
                dataEntrega = (DateTime) DateTime.Now,
                quantidade = (int) 1,
                valorUnitario = (decimal) 50,
                valorTotal = (decimal) 100,
                ativo = (bool) true
            };

            var produto = new Produto();
            produto = produtoEsperado;

            Assert.Equal(produtoEsperado, produto);
            #endregion
        }

        [Fact]
        public void ResumoProduto_CriarResumoProduto_RetornaResumoProduto()
        {
            #region Criar um resumo de produto com os seguintes dados: id, dataImportacao, dataEntrega, quantidade, valorTotal, ativo

            var resumoEsperado = new ResumoProduto()
            {
                id = (Guid)Guid.NewGuid(),
                dataImportacao = (DateTime)DateTime.Now,
                dataEntrega = (DateTime)DateTime.Now,
                quantidade = (int)1,
                valorTotal = (decimal)100,
                ativo = (bool)false
            };

            var resumoProduto = new ResumoProduto();
            resumoProduto = resumoEsperado;

            Assert.Equal(resumoEsperado, resumoProduto);
            #endregion
        }
    }
}