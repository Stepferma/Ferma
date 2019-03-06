using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.BLL.DTO
{
    public class CellDTO
    {
        public int IdCell { get; set; }
        public int IdField { get; set; }
        public int IdProduct { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateStart { get; set; }
    }
}
