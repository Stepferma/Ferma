using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ferma.Models
{
    public class BuildingModel
    {
        public int IdBuilding { get; set; }
        public int IdTypeBuilding { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateStart { get; set; }
    }
}