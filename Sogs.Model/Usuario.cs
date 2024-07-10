using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdTipoDocumento { get; set; }

    public string NumeroDocumento { get; set; } = null!;

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string? Telefono { get; set; }

    public string Correo { get; set; } = null!;

    public int IdRol { get; set; }

    public string Clave { get; set; } = null!;

    public bool Estado { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual TipoDocumento IdTipoDocumentoNavigation { get; set; } = null!;

    public virtual ICollection<Pretutela> Pretutelas { get; set; } = new List<Pretutela>();
}
