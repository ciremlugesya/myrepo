﻿using Entity.Concrete;
using System.Collections.Generic;

namespace WebApp.Models
{
    public class ProductListViewModel
    {
        public List<Product> Products { get; set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int CurrentPage { get; internal set; }
    }
}