using AutoMapper;
using Loja.Core.Models;
using LojaVirtual.API.Models;
using LojaVirtual.API.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LojaVirtual.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<ImagemProdutoViewModel, ImagemProduto>();
            CreateMap<ProdutoViewModel, Produto>();
            CreateMap<PagedResult<Produto>, PagedResult<ProdutoViewModel>>();

            CreateMap<Produto, ProdutoViewModel>()
                .ForMember(dest => dest.NomeMarca, opt => opt.MapFrom(src => src.Marca.Nome))
                .ForMember(dest => dest.NomeTipoProduto, opt => opt.MapFrom(src => src.TipoProduto.Nome))
                .ForMember(dest => dest.NomeCor, opt => opt.MapFrom(src => src.Cor.Nome))
                .ForMember(dest => dest.NomeTamanho, opt => opt.MapFrom(src => src.Tamanho.Nome));
        }
    }
}
