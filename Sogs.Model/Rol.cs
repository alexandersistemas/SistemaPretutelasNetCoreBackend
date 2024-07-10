using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Rol
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
