using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class IdentidadGenero
{
    public int IdIdentidadGenero { get; set; }

    public string NombreIdentidadGenero { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
