using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Entities
{
    public class Products
    {
        [Key]
        public int IdProduct { get; set; }
        public int IdTypeProduct { get; set; }
        public int Price { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public double BuildTime { get; set; }
    }
}
