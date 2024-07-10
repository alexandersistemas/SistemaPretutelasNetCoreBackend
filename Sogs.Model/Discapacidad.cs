using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Discapacidad
{
    public int IdDiscapacidad { get; set; }

    public string NombreDiscapacidad { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
