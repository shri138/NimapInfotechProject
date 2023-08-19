using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NimapInfotechProject.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Nullable<int> CategoryId { get; set; }
    }
}