using AutoMapper;
using ProdutoApi.Model;
using Produtos.Domain.Entities;

namespace ProdutoApi.AutoMapper
{
    public class ConfigurationMapping : Profile
    {
        public ConfigurationMapping()
        {
            CreateMap<Produto, ProdutoModel>();
            CreateMap<ProdutoModel, Produto>();
            CreateMap<CategoriaProduto, CategoriaProdutoModel>();
            CreateMap<CategoriaProdutoModel,CategoriaProduto>().ForMember(p => p.Produtos, x => x.Ignore());
        }
    }
}
