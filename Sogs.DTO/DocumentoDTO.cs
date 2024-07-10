using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class DocumentoDTO
    {
        public int IdDocumento { get; set; }
        public string NombreDocumento { get; set; } = null!;
        public string RutaDocumento { get; set; } = null!;
        public DateTime? FechaRegistro { get; set; }
    }
}
