using ApiModeloDDD.Application;
using ApiModeloDDD.Application.Interfaces;
using ApiModeloDDD.Application.Interfaces.Mappers;
using ApiModeloDDD.Application.Mappers;
using ApiModeloDDD.Domain.Core.Interfaces.Repositorys;
using ApiModeloDDD.Domain.Core.Interfaces.Services;
using ApiModeloDDD.Domain.Services;
using ApiModeloDDD.Infra.Data.Repositorys;
using Autofac;

namespace ApiModeloDDD.Infra.CrossCutting.IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder buider)
        {
            #region IOC

            buider.RegisterType<ApplicationServiceProduto>().As<IApplicationServiceProduto>();
            buider.RegisterType<ProdutoService>().As<IProdutoService>();
            buider.RegisterType<ProdutoRepository>().As<IProdutoRepository>();
            buider.RegisterType<MapperProduto>().As<IMapperProduto>();

            #endregion
        }
    }
}