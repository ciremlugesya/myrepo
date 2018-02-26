using Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public ActionResult Index(int page = 1, int categoryId = 0)
        {
            int pageSize = 10;
            //var products = _productService.GetAll(); // encapsulation yapmak gerekir best practice acisindan
            // product nesnesini view modele cevirip modele basacagiz

            var products = _productService.GetByCategory(categoryId); // kategoriye bagli urunleri getiriyoruz simdi
            var model = new ProductListViewModel
            {
                Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                PageCount = (int)Math.Ceiling(products.Count / (double)pageSize),
                PageSize = pageSize,
                CurrentCategory = categoryId,
                CurrentPage = page
            };
            return View(model);
        }
    }
}