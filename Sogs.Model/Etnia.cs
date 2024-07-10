using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Etnia
{
    public int IdEtnia { get; set; }

    public string? NombreEtnia { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    
}
