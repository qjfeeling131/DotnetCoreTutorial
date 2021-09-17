using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCoreTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetCoreTutorial
{
    public class EFDbContext : DbContext
    {
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }

        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
        }
    }
}
