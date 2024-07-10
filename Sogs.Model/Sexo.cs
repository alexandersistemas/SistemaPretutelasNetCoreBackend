using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Sexo
{
    public int IdSexo { get; set; }

    public string NombreSexo { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();
}
