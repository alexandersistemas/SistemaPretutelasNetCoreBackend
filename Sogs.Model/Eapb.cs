using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Eapb
{
    public int IdEapb { get; set; }

    public string NombreEapb { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public bool? Estado { get; set; }

    public virtual ICollection<Pretutela> Pretutelas { get; set; } = new List<Pretutela>();
}
