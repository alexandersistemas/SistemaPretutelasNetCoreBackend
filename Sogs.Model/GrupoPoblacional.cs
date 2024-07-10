using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class GrupoPoblacional
{
    public int IdGrupoPob { get; set; }

    public string? NombreGrupoPob { get; set; }

    public bool? Estado { get; set; }

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
