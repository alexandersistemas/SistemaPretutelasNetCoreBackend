using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Documento
{
    public int IdDocumento { get; set; }

    public string NombreDocumento { get; set; } = null!;

    public DateTime? FechaRegistro { get; set; }

    public string RutaDocumento { get; set; } = null!;

    public virtual ICollection<PretutelaDocumento> PretutelaDocumentos { get; set; } = new List<PretutelaDocumento>();
}
