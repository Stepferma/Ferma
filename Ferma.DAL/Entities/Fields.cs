using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Entities
{
    public class Fields
    {
        [Key]
        public int IdField { get; set; }
        public int? IdBuilding { get; set; }
        public int? IdFarm { get; set; }
    }
}
