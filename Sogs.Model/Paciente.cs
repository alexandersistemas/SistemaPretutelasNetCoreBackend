using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Paciente
{
    public int IdPaciente { get; set; }

    public int IdTipoDocumento { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public int? IdSexo { get; set; }

    public int? IdGrupoPob { get; set; }

    public int? IdEtnia { get; set; }

    public string Correo { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Celular { get; set; }

    public string? TelefonoFijo { get; set; }

    public int? IdPoblacionPrioritaria { get; set; }

    public int? IdParentesco { get; set; }

    public int? IdRegimen { get; set; }

    public int? IdIdentidadGenero { get; set; }

    public int? IdDiscapacidad { get; set; }

    public int? IdMomentoCursoVida { get; set; }

    public string? OtroParentesco { get; set; }

    public string? OtroRegimen { get; set; }

    public int? IdTipoDocumentoRepresentado { get; set; }

    public string? NumeroDocumentoRepresentado { get; set; }

    public string? NombresRepresentado { get; set; }

    public string? ApellidosRepresentado { get; set; }

    public virtual Discapacidad? IdDiscapacidadNavigation { get; set; }

    public virtual Etnia? IdEtniaNavigation { get; set; }

    public virtual GrupoPoblacional? IdGrupoPobNavigation { get; set; }

    public virtual IdentidadGenero? IdIdentidadGeneroNavigation { get; set; }

    public virtual MomentoCursoVida? IdMomentoCursoVidaNavigation { get; set; }

    public virtual Parentesco? IdParentescoNavigation { get; set; }

    public virtual PoblacionPrioritaria? IdPoblacionPrioritariaNavigation { get; set; }

    public virtual Regimen? IdRegimenNavigation { get; set; }

    public virtual Sexo? IdSexoNavigation { get; set; }

    public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; } = null!;

    public virtual TipoDocumento? IdTipoDocumentoRepresentadoNavigation { get; set; }

    public virtual ICollection<Pretutela> Pretutelas { get; set; } = new List<Pretutela>();
}
