using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class PretutelaPacienteRepresentadoDocDTO
    {

        
        public PacienteDTO Form2 { get; set; }
        public PretutelaDTO Form3 { get; set; }
        public DocumentoDTO? Form4 { get; set; } // Permitir nulo
        public PretutelaDocumentoDTO? Form5 { get; set; } // Permitir nulo
        public List<VectorArchivosDTO> VectorItems { get; set; } // Vector de elementos

    }

}
