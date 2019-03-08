using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferma.Models
{
    public class TypeProductsModel
    {
        public int IdTypeProducts { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime BuildTime { get; set; }
        public bool IsActive { get; set; }
    }
}