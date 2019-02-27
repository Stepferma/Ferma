using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Entities
{
    public class Cells
    {
        [Key]
        public int IdCell { get; set; }
        public int IdField { get; set; }
        public int IdProduct { get; set; }
    }
}
