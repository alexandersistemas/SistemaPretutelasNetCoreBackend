using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class EapbDTO
    {
        public int IdEapb { get; set; }
        public string NombreEapb { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public bool? Estado { get; set; }
    }
}
