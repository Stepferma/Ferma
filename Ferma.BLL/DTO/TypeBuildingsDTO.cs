using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.BLL.DTO
{
    public class TypeBuildingsDTO
    {
        public int IdTypeBuilding { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public DateTime BuildTime { get; set; }
    }
}
