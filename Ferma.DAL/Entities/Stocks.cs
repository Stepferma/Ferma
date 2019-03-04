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
        public int? Grass { get; set; }
        public int? Seed { get; set; }
        public int? Pork { get; set; }
        public int? Eggs { get; set; }
    }
}
