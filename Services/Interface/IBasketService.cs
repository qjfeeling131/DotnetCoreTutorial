using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Services.Interface
{
    public interface IBasketService
    {
        Task GetBasketByIdAsync();
    }
}
