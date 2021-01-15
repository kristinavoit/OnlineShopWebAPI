using AutoMapper;
using OnlineShopWebAPI.API.Resources;
using OnlineShopWebAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopWebAPI.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductResource>();
            CreateMap<Product, SaveProductResource>();

            CreateMap<ProductResource, Product>();
            CreateMap<SaveProductResource, Product>();
        }
    }
}
