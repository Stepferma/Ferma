using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferma.DAL.Entities
{
    public class Players
    {
        [Key]
        public int IdPlayer { get; set; }
        public int Money { get; set; }
        public string IdUser { get; set; }
    }
}
