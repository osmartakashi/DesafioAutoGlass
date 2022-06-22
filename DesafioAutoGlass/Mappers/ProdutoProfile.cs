using AutoMapper;
using Models;
using Models.Dtos.ProdutoDtos;

namespace Api.Mappers
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {          
            CreateMap<CreateProdutoDto, Produto>();
            CreateMap<UpdateProdutoDto, Produto>();
            //CreateMap<Produto, CreateProdutoDto>();
            //CreateMap<Produto, UpdateProdutoDto>();
        }
    }
}
