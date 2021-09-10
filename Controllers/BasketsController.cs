using DotnetCoreTutorial.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class BasketsController : ControllerBase
    {
        private readonly ILogger<BasketsController> _logger;

        public BasketsController(ILogger<BasketsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<BasketDto>> GetBaskets()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new BasketDto
            {
                Name = "test",
                Created = DateTime.Now.ToString("MM/dd/yyyy"),
                CreatedBy = $"Test",
                TotalPrice = "111"
            })
            .ToArray();
        }
    }
}
