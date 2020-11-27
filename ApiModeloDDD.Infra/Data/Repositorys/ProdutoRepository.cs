using ApiModeloDDD.Domain.Core.Interfaces.Repositorys;
using ApiModeloDDD.Domain.Entitys;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace ApiModeloDDD.Infra.Data.Repositorys
{
    public class ProdutoRepository : BaseRepository, IProdutoRepository
    {
        private readonly SqlContext _sqlContext;

        public ProdutoRepository(IConfiguration configuration, SqlContext sqlContext) : base(configuration)
        {
            _sqlContext = sqlContext;
        }

        public IEnumerable<Produto> GetImportacoes()
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
                ";

                using (var conexao = new SqlConnection(GetConnection))
                {
                    conexao.Open();
                    var produtos = conexao.Query<Produto>(sql).ToList();
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
                var sql = $@"
                
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
    }
}