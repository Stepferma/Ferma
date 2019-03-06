using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferma.Models
{
    public class StockModel
    {
        public int IdStock { get; set; }
        public int IdPlayer { get; set; }
        public int Millet { get; set; }
        public int Meat { get; set; }
        public int Corn { get; set; }
        public int Eggs { get; set; }
    }
}