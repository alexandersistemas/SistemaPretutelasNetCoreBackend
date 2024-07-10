using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public bool Estado { get; set; }

    public virtual ICollection<Pretutela> Pretutelas { get; set; } = new List<Pretutela>();

    public virtual ICollection<SubCategoria> SubCategoria { get; set; } = new List<SubCategoria>();




}
