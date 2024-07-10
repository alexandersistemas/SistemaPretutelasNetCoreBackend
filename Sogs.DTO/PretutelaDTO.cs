using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class PretutelaDTO
    {
        public int IdPretutela { get; set; }
        public int IdEapb { get; set; }
        public string? NombreEapb { get; set; }
        public DateTime FechaRecepcion { get; set; }
        public string FechaRecepcionFormatted => FechaRecepcion.ToString("dd/MM/yyyy");        
        public int IdCategoria { get; set; }
        public string? NombreCategoria { get; set; }
        public string? Descripcion { get; set; }
        public int? IdPaciente { get; set; }
        public string NumeroRadicado { get; set; } = null!;
        public string NumeroDocumento { get; set; } = null!;
        public int IdSubCategoria { get; set; }
        public string? NombreSubCategoria { get; set; }
        public int? IdRespuesta { get; set; }
        public string? NombreRespuesta { get; set; }
        public int? IdUsuario { get; set; }
        public bool Estado { get; set; }
    }
}
