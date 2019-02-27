using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Entities
{
    public class TypeBuildings
    {
        [Key]
        public int IdTypeBuilding { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime BuildTime { get; set; }
    }
}
