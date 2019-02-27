using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Entities
{
    public class TypeProducts
    {
        [Key]
        public int IdTypeProduct { get; set; }
        [StringLength(40)]
        public string Name { get; set; }
        public int Price { get; set; }
        public bool IsActive { get; set; }
        public DateTime BuildTime { get; set; }
    }
}
