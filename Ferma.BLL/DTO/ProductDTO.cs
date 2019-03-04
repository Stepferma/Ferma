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
        public DateTime? DateStart { get; set; }
    }
}
