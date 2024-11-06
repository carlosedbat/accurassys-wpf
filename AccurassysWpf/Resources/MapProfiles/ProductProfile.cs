using AccurassysWpf.Models.DTOs;
using AccurassysWpf.Models.DTOs.Products;
using AutoMapper;

namespace AccurassysWpf.Resources.MapProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<CreateProductDto, ProductsDTO>().ReverseMap();
        }
    }
}