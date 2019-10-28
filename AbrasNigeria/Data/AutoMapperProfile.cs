using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;
using AutoMapper;

namespace AbrasNigeria.Data
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<StockProduct, StockProductDTO>();
            CreateMap<StockProductDTO, StockProduct>();

            CreateMap<Document, DocumentDTO>();
            CreateMap<DocumentDTO, Document>();

            CreateMap<DocumentItem, DocumentItemDTO>();
            CreateMap<DocumentItemDTO, DocumentItem>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<DescriptionDTO, Description>();
            CreateMap<Description, DescriptionDTO>();

            CreateMap<BrandDTO, Brand>();
            CreateMap<Brand, BrandDTO>();

            CreateMap<MachineDTO, Machine>();
            CreateMap<Machine, MachineDTO>();

            CreateMap<SectionDTO, Section>();
            CreateMap<Section, SectionDTO>();

            CreateMap<SectionGroupDTO, SectionGroup>();
            CreateMap<SectionGroup, SectionGroupDTO>();

        }
    }
}
