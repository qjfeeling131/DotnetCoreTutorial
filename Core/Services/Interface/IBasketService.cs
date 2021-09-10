using DotnetCoreTutorial.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Core.Services.Interface
{
    public interface IBasketService
    {
        Task<BasketDto> GetBasketByIdAsync(int basketId);
    }
}
