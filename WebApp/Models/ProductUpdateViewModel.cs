using Entity.Concrete;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class ProductUpdateViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; internal set; }
    }
}
