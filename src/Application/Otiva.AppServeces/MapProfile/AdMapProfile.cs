using AutoMapper;
using Otiva.Contracts.AdDto;
using Otiva.Contracts.SelectedAdDto;
using Otiva.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otiva.AppServeces.MapProfile
{
    public class AdMapProfile : Profile
    {
        public AdMapProfile() 
        {
            CreateMap<Product, InfoAdResponse>().ReverseMap();
            CreateMap<Product, CreateOrUpdateAdRequest>().ReverseMap();
            CreateMap<ItemShoppingCart, InfoSelectedResponse>().ReverseMap();
        }   
       
    }
}
