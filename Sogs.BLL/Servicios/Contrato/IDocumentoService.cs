using Sogs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.BLL.Servicios.Contrato
{
    public interface IDocumentoService
    {
        Task<List<DocumentoDTO>> lista();
        Task<DocumentoDTO> Crear(DocumentoDTO modelo);
        Task<bool> Eliminar(int id);
        Task<List<DocumentoDTO>> GetDocumentsByPretutela(int id);
    }
}
