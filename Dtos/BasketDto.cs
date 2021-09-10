using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Dtos
{
    public class BasketDto
    {
        public string Name { get; set; }
        public string Created { get; set; }
        public string CreatedBy { get; set; }
        public string TotalPrice { get; set; }
    }

    public class BasketItemDto
    {
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public string Quantity { get; set; }
        public string UnitPrice { get; set; }
    }
}
