using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
   // [Authorize]
    public class AdminController : Controller
    {
        private ICategoryService _categoryService;
        private IProductService _productService;

        public AdminController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public ActionResult Index()
        {
            var products = _productService.GetAll();
            var model = new ProductListViewModel
            {
                Products = products
            };

            return View(model);
        }

        public ActionResult Add()
        {
            var model = new ProductAddViewModel
            {
                Product = new Product(),
                Categories = _categoryService.GetAll()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Add(product);
                TempData.Add("message", "Product was successfully added.");
            }

            return RedirectToAction("Add");
        }

        public ActionResult Update(int productId)
        {
            var model = new ProductUpdateViewModel { Product = _productService.GetById(productId), Categories = _categoryService.GetAll() };
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.Update(product);
                TempData.Add("message", "Product was successfully updated.");
            }

            return RedirectToAction("Update");
        }

        public ActionResult Delete(int productId)
        {
            _productService.Delete(productId);
            TempData.Add("message", "Product was successfully deleted.");
            return RedirectToAction("Index");
        }
    }
}