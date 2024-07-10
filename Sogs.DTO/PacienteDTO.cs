using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.DTO
{
    public class PacienteDTO
    {
        public int IdPaciente { get; set; }
        public int IdTipoDocumento { get; set; }
        public string? NombreTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; } = null!;
        public string PrimerNombre { get; set; } = null!;
        public string? SegundoNombre { get; set; }
        public string PrimerApellido { get; set; } = null!;
        public string? SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string FechaNacimientoFormatted => FechaNacimiento.ToString("dd/MM/yyyy");
        public int? IdSexo { get; set; }
        public string? NombreSexo { get; set; }
        public int? IdGrupoPob { get; set; }
        public string? NombreGrupoPob { get; set; }
        public int? IdEtnia { get; set; }
        public string? NombreEtnia { get; set; }
        public string Correo { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string? Celular { get; set; }
        public string? TelefonoFijo { get; set; }
        public int? IdPoblacionPrioritaria { get; set; }
        public string? NombrePoblacionPrioritaria { get; set; }
        public int? IdParentesco { get; set; }
        public string? NombreParentesco { get; set; }
        public int? IdRegimen { get; set; }
        public string? NombreRegimen { get; set; }
        public int? IdIdentidadGenero { get; set; }
        public string? NombreIdentidadGenero { get; set; }
        public int? IdDiscapacidad { get; set; }
        public string? NombreDiscapacidad { get; set; }
        public int? IdMomentoCursoVida { get; set; }
        public string? NombreMomentoCursoVida { get; set; }
        public string? OtroParentesco { get; set; }
        public string? OtroRegimen { get; set; }
        public int? IdTipoDocumentoRepresentado { get; set; }
        public string? NombreTipoDocumentoRepresentado { get; set; }
        public string? NumeroDocumentoRepresentado { get; set; }
        public string? NombresRepresentado { get; set; }
        public string? ApellidosRepresentado { get; set; }

    }
}
