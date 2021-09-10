using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Models
{
    public class Basket : BaseEntity
    {

        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Updated { get; set; }
        public decimal TotalPrice { get; set; }
        public string Comment { get; set; }
    }

    [Index(nameof(BasketId), Name = "Index_BasketId")]
    public class BasketItem : BaseEntity
    {

        public int BasketId { get; set; }
        public string Name { get; set; }
        public string PictureUrl { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }
    }
}
