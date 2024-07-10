using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sogs.Model;

public partial class SubCategoria
{
    [Key] // Esto define la propiedad Id como clave primaria
    public int IdSubCategoria { get; set; }

    public int IdCategoria { get; set; }

    public string NombreSubCategoria { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual ICollection<Pretutela> Pretutelas { get; set; } = new List<Pretutela>();

}
