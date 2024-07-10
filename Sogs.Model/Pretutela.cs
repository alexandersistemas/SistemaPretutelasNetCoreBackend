using System;
using System.Collections.Generic;

namespace Sogs.Model;

public partial class Pretutela
{
    public int IdPretutela { get; set; }

    public int IdEapb { get; set; }

    public DateTime? FechaRecepcion { get; set; }

    public int IdCategoria { get; set; }

    public string Descripcion { get; set; } = null!;

    public int? IdPaciente { get; set; }

    public string NumeroRadicado { get; set; } = null!;

    public int IdSubCategoria { get; set; }

    public bool Estado { get; set; }

    public int? IdRespuesta { get; set; }

    public int? IdUsuario { get; set; }

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Eapb IdEapbNavigation { get; set; } = null!;

    public virtual Paciente? IdPacienteNavigation { get; set; }

    public virtual Respuesta? IdRespuestaNavigation { get; set; }

    public virtual SubCategoria IdSubCategoriaNavigation { get; set; } = null!;

    public virtual Usuario? IdUsuarioNavigation { get; set; }

    public virtual ICollection<PretutelaDocumento> PretutelaDocumentos { get; set; } = new List<PretutelaDocumento>();
}
