using AutoMapper;
using DotnetCoreTutorial.Dtos;
using DotnetCoreTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Infrastructure.Configuration.AutoMapper
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<Basket, BasketDto>();
            CreateMap<BasketItem, BasketItemDto>();
        }
    }
}
