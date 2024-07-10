using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class PoblacionPrioritaria
{
    public int IdPoblacionPrioritaria { get; set; }

    public string NombrePoblacionPrioritaria { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
    

}
