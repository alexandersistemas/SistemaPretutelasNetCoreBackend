using Sogs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sogs.DTO;

namespace Sogs.BLL.Servicios.Contrato
{
    public interface IPretutelaService
    {
        Task<List<PretutelaDTO>> lista();
        Task<PretutelaDTO> Crear(PretutelaDTO modelo);
        Task<bool> Editar(PretutelaDTO modelo);
        Task<bool> Eliminar(int id);
        Task<List<PretutelaDTO>> Historial(string buscarPor, string? numeroRadicado, string? fechaInicio, string? fechaFin, string? numeroDocumento);
    }
}
