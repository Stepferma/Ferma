using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.BLL.DTO
{
    public class StockDTO
    {
        public int IdStock { get; set; }
        public int IdPlayer { get; set; }
        public int Millet { get; set; }
        public int Meat { get; set; }
        public int Corn { get; set; }
        public int Eggs { get; set; }
    }
}
