using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Entities
{
    public class Farms
    {
        [Key]
        public int IdFarm { get; set; }
        public int IdPlayer { get; set; }
        public int IdStock { get; set; }
    }
}
