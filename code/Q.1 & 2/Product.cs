using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductMVC.Models
{
    public class Product
    {
        public int ProductId { set; get; }
        public string ProductName { set; get; }
        public decimal Rate { set; get; }
        public string Description { set; get; }
        public string CategoryName { set; get; }
    }
}