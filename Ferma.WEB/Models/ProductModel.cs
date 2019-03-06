using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferma.Models
{
    public class ProductModel
    {
        public int IdProduct { get; set; }
        public int IdTypeProduct { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public double BuildTime { get; set; }
    }
}
