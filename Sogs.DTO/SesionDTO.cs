using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class SesionDTO
    {
        public int IdUsuario { get; set; }
        public string PrimerNombre { get; set; } = null!;
        public string NombreRol { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Clave { get; set; } = null!;


    }
}
