using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class PretutelaDocumento
{
    public int IdPretutelaDocumento { get; set; }

    public int IdDocumento { get; set; }

    public int IdPretutela { get; set; }

    public virtual Documento IdDocumentoNavigation { get; set; } = null!;

    public virtual Pretutela IdPretutelaNavigation { get; set; } = null!;
}
