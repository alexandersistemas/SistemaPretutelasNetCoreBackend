using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Respuesta
{
    public int IdRespuesta { get; set; }

    public string NombreRespuesta { get; set; } = null!;

    public virtual ICollection<Pretutela> Pretutelas { get; set; } = new List<Pretutela>();
}
