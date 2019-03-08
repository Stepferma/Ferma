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
        public int IdTypeProducts { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
    }
}
