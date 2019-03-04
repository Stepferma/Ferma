using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Entities
{
    public class Stocks
    {
        [Key]
        public int IdStock { get; set; }
        public int IdPlayer { get; set; }
        public int Millet { get; set; }
        public int Meat { get; set; }
        public int Corn { get; set; }
        public int Eggs { get; set; }
    }
}
