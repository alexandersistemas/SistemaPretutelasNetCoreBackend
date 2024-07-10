using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class TipoDocumentoDTO
    {
        public int IdTipoDocumento { get; set; }
        public string NombreTipoDocumento { get; set; } = null!;
        public bool Estado { get; set; }
    }
}
