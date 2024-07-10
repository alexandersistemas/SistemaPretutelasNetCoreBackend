using Sogs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.BLL.Servicios.Contrato
{
    public interface IPretutelaDocumentoService
    {
        Task<List<PretutelaDocumentoDTO>> lista();
        Task<PretutelaDocumentoDTO> Crear(PretutelaDocumentoDTO modelo);
        Task<bool> Eliminar(int id);
    }
}
