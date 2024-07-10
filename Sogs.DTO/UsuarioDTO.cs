using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }
        public string? Telefono { get; set; }
        public string Correo { get; set; } = null!;
        public int IdRol { get; set; }
        public string? Clave { get; set; } = null!;
        public int? Estado { get; set; }

    }
}
