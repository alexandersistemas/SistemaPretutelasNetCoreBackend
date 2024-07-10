using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class PoblacionPrioritariaDTO
    {
        public int IdPoblacionPrioritaria { get; set; }
        public string NombrePoblacionPrioritaria { get; set; } = null!;
        public bool? Estado { get; set; }
    }
}
