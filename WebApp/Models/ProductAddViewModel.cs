using System.Collections.Generic;
using Entity.Concrete;

namespace WebApp.Models
{
    public class ProductAddViewModel
    {
        public Product Product { get; set; }
        public List<Category> Categories { get; internal set; }
    }
}
