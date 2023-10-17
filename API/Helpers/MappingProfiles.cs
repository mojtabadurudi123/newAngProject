using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Products,ProductToReturnDto>()
            .ForMember(d=> d.ProductBrands,o=>o.MapFrom(s=>s.ProductBrands.ProductBrandTitle))
            .ForMember(d=>d.ProductTypes,o=> o.MapFrom(s=>s.ProductTypes.ProductTypeTitle))
            .ForMember(d=>d.PictureUrl,o=>o.MapFrom<ProductUrlResolver>());

        
        }
    }
}