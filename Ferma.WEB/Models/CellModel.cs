using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferma.Models
{
    public class CellModel
    {
        public int IdCell { get; set; }
        public int IdField { get; set; }
        public int IdProduct { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateStart { get; set; }
    }
}