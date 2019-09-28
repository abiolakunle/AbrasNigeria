using AbrasNigeria.Data.DTO;
using AbrasNigeria.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        }
    }
}
