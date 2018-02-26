using System.Collections.Generic;
using Entity.Concrete;

namespace WebApp.Models
{
    public class CategoryListViewModel
    {
        public List<Category> Categories { get; internal set; }
        public int CurrentCategory { get; internal set; }
    }
}
