using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Regimen
{
    public int IdRegimen { get; set; }

    public string? NombreRegimen { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
        
}
