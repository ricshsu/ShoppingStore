using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingStore.Domain.Abstract;
using ShoppingStore.Domain.Entities;

namespace ShoppingStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository; 

        public ProductController(IProductsRepository productRepository)
        {
            this.repository = productRepository;
        }
        // GET: Product
        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}