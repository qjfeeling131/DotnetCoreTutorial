using DotnetCoreTutorial.Core.Repositories;
using DotnetCoreTutorial.Models;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotnetCoreTutorial.Infrastructure.StructureMap
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {

            For<IOrderRepository>().Use<OrderRepository>();
            Scan(x =>
            {
                x.TheCallingAssembly();
                x.AddAllTypesOf(typeof(Repository<>));
                x.ConnectImplementationsToTypesClosing(typeof(IRepository<>));
              
            });
        }
    }

    public interface IOrderRepository: IRepository<BaseEntity>
    {
        void CreateOrderByUser();
    }
    public class OrderRepository :Repository<BaseEntity>, IOrderRepository
    {
        public OrderRepository(EFDbContext eFDbContext):base(eFDbContext)
        {

        }

        public void CreateOrderByUser()
        {
            throw new NotImplementedException();
        }

        public void test()
        {
        

        }
    }

    public interface SqlHandler
    {

    }
}
