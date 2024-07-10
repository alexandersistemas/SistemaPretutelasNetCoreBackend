using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Parentesco
{
    public int IdParentesco { get; set; }

    public string? NombreParentesco { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
