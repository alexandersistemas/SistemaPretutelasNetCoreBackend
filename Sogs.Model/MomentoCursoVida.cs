using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sogs.Model;

public partial class MomentoCursoVida
{
    [Key] // Esto define la propiedad Id como clave primaria
    public int IdMomentoCursoVida { get; set; }

    public string NombreMomentoCursoVida { get; set; } = null!;

    public virtual ICollection<Paciente> Pacientes { get; set; } = new List<Paciente>();

    
}
