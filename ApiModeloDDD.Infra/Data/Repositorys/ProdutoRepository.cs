﻿using ApiModeloDDD.Domain.Core.Interfaces.Repositorys;
using ApiModeloDDD.Domain.Entitys;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.IO;
using OfficeOpenXml;
using System.Threading.Tasks;

namespace ApiModeloDDD.Infra.Data.Repositorys
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private readonly SqlContext _sqlContext;

        public ProdutoRepository(IConfiguration configuration, SqlContext sqlContext) : base(configuration)
        {
            _sqlContext = sqlContext;
        }

        public async void Importar(IFormFile file)
        {
            try
            {
                var listaProdutos = new List<Produto>();

                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream).ConfigureAwait(false);

                    using (var package = new ExcelPackage(memoryStream))
                    {
                        for (int i = 1; i <= package.Workbook.Worksheets.Count; i++)
                        {
                            var totalRows = package.Workbook.Worksheets[i].Dimension?.Rows;
                            var totalCollumns = package.Workbook.Worksheets[i].Dimension?.Columns;
                            for (int linha = 2; linha <= totalRows.Value; linha++)
                            {
                                var produto = new Produto();

                                for (int coluna = 1; coluna <= totalCollumns.Value; coluna++)
                                {
                                    if (coluna == 1)
                                    {
                                        if (Validador(null, Convert.ToDateTime(package.Workbook.Worksheets[i].Cells[linha, coluna].Value)))
                                            produto.dataEntrega = Convert.ToDateTime(package.Workbook.Worksheets[i].Cells[linha, coluna].Value);
                                        else
                                            throw new Exception("A data de entrega não deve ser menor ou igual a data atual");
                                    }
                                    else if (coluna == 2)
                                    {
                                        if (Validador(package.Workbook.Worksheets[i].Cells[linha, coluna].Value.ToString()))
                                            produto.descricao = package.Workbook.Worksheets[i].Cells[linha, coluna].Value.ToString();
                                        else
                                            throw new Exception("A descrição não pode ser maior que 50");
                                    }
                                    else if (coluna == 3)
                                    {
                                        if (Validador(null, null, Convert.ToInt32(package.Workbook.Worksheets[i].Cells[linha, coluna].Value)))
                                            produto.quantidade = Convert.ToInt32(package.Workbook.Worksheets[i].Cells[linha, coluna].Value);
                                        else
                                            throw new Exception("A quantidade deve ser maior que 0");
                                    }
                                    else
                                    {
                                        if (Validador(null, null, null, Convert.ToDecimal(package.Workbook.Worksheets[i].Cells[linha, coluna].Value)))
                                            produto.valorUnitario = Convert.ToDecimal(package.Workbook.Worksheets[i].Cells[linha, coluna].Value);
                                        else
                                            throw new Exception("A valor unitário deve ser maior que 0");
                                    }
                                }
                                listaProdutos.Add(produto);
                            }
                        }
                        foreach (var item in listaProdutos)
                        {
                            item.valorTotal = (item.valorUnitario * item.quantidade);

                            var sql = $@"INSERT INTO [dbo].[Produtos]
                                                           ([id]
                                                           ,[dataEntrega]
                                                           ,[descricao]
                                                           ,[quantidade]
                                                           ,[valorUnitario]
                                                           ,[dataImportacao]
                                                           ,[valorTotal]
                                                           ,[ativo])
                                                     VALUES
                                                           (NEWID()
                                                           ,@dataEntrega
                                                           ,@descricao
                                                           ,@quantidade
                                                           ,@valorUnitario
                                                           ,GETDATE()
                                                           ,@valorTotal
                                                           ,'1')
                            ";

                            using (var conexao = new SqlConnection(GetConnection))
                            {
                                conexao.Open();
                                conexao.Execute(sql, new { item.dataEntrega
                                                          ,item.descricao
                                                          ,item.quantidade
                                                          ,item.valorUnitario
                                                          ,item.valorTotal });
                                conexao.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public IEnumerable<ResumoProduto> GetImportacoes()
        {
            try
            {
                var sql = $@"SELECT  [id]
                                    ,[dataImportacao]
                                    ,[dataEntrega]
                                    ,[quantidade]
                                    ,[valorTotal]
                                    ,[ativo]
                             FROM [dbo].[Produtos]
                             ORDER BY [dataEntrega] ASC
                ";

                using (var conexao = new SqlConnection(GetConnection))
                {
                    conexao.Open();
                    var produtos = conexao.Query<ResumoProduto>(sql).ToList();
                    conexao.Close();

                    if (produtos.Count > 0)
                        return produtos;
                    else
                        throw new Exception("Nenhum produto encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public Produto GetImportacao(Guid Id)
        {
            try
            {
                var sql = $@"SELECT  [id]
                                    ,[descricao]
                                    ,[dataImportacao]
                                    ,[dataEntrega]
                                    ,[quantidade]
                                    ,[valorUnitario]
                                    ,[valorTotal]
                                    ,[ativo]
                                FROM [dbo].[Produtos]
                                WHERE [id] = @Id
                ";

                using (var conexao = new SqlConnection(GetConnection))
                {
                    conexao.Open();
                    var produto = conexao.QueryFirstOrDefault<Produto>(string.Format(sql), new { Id });
                    conexao.Close();

                    if (produto != null)
                        return produto;
                    else
                        throw new Exception("Nenhum produto encontrado");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AtualizarProduto(Produto produto)
        {
            try
            {
                if (Validador(produto.descricao
                             ,produto.dataEntrega
                             ,produto.quantidade
                             ,produto.valorUnitario))
                {
                    produto.valorTotal = (produto.valorUnitario * produto.quantidade);

                    var sql = $@"UPDATE [dbo].[Produtos]
                               SET [dataEntrega] = @dataEntrega
                                  ,[descricao] = @descricao
                                  ,[quantidade] = @quantidade
                                  ,[valorUnitario] = @valorUnitario
                                  ,[valorTotal] = @valorTotal
                                  ,[ativo] = @ativo
                            WHERE [id] = @Id
                    ";

                    using (var conexao = new SqlConnection(GetConnection))
                    {
                        conexao.Open();
                        conexao.Execute(sql, produto);
                        conexao.Close();
                    }
                }
                else
                    throw new Exception("Revise os campos para atualizar o produto");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        private bool Validador(string descricao, DateTime? dataEntrega = null, int? quantidade = null, decimal? valorUnitario = null)
        {
            try
            {
                var isValido = true;

                if (dataEntrega != null)
                    if (dataEntrega <= DateTime.Now)
                        isValido = false;

                if (!string.IsNullOrEmpty(descricao))
                    if (descricao.Length > 50)
                        isValido = false;

                if (quantidade != null)
                    if (quantidade < 0)
                        isValido = false;

                if (valorUnitario != null)
                    if (valorUnitario < 0)
                        isValido = false;

                return isValido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}