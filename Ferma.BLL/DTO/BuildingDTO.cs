using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.BLL.DTO
{
    public class BuildingDTO
    {
        public int IdBuilding { get; set; }
        public int IdTypeBuilding { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateStart { get; set; }
    }
}
