using AutoMapper;
using DotnetCoreTutorial.Core.Repositories;
using DotnetCoreTutorial.Core.Services.Interface;
using DotnetCoreTutorial.Dtos;
using DotnetCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Core.Services
{
    public class BasketService : IBasketService
    {
        private readonly EFDbContext _eFDbContext;
        private readonly IMapper _mapper;
        private readonly IRepository<Basket> _repository;
        public BasketService(EFDbContext eFDbContext,
            IMapper mapper,
            IRepository<Basket> repository)
        {
            _eFDbContext = eFDbContext;
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<BasketDto> GetBasketByIdAsync(int basketId)
        {
            var basket = await _eFDbContext.Baskets.FirstOrDefaultAsync(b => b.Id == basketId);
            var result = _mapper.Map<BasketDto>(basket);
            return result;
        }
    }
}
