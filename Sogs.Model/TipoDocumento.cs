using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class TipoDocumento
{
    public int IdTipoDocumento { get; set; }

    public string NombreTipoDocumento { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Paciente> PacienteIdTipoDocumentoNavigations { get; set; } = new List<Paciente>();

    public virtual ICollection<Paciente> PacienteIdTipoDocumentoRepresentadoNavigations { get; set; } = new List<Paciente>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
