using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Entities
{
    public class Buildings
    {
        [Key]
        public int IdBuilding { get; set; }
        public int? IdTypeBuilding { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? DateStart { get; set; }
    }
}
