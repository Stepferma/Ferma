using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.BLL.DTO
{
    public class ProductDTO
    {
        public int IdProduct { get; set; }
        public int IdTypeProduct { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public double BuildTime { get; set; }
    }
}
