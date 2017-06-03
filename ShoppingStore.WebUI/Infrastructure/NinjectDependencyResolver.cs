using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

// add 

using Moq;
using Ninject;

using ShoppingStore.Domain.Abstract;
using ShoppingStore.Domain.Entities;

namespace ShoppingStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver :IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver (IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();//add
          
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.Products).Returns(
                    new List<Product>
                    {
                        new Product {Name ="Football" , Price =25 },
                        new Product {Name ="Surf" , Price =179 },
                        new Product {Name ="Rinning shores" , Price =179 },
                        new Product {Name ="basketball" , Price =95 },
                    }

                );
            kernel.Bind<IProductsRepository>().ToConstant(mock.Object);
        }

    }
}