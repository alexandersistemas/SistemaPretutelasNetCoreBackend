using Sogs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.BLL.Servicios.Contrato
{
    public interface IPacienteService
    {
        Task<List<PacienteDTO>> lista();
        Task<PacienteDTO> Crear(PacienteDTO modelo);
        Task<bool> Editar(PacienteDTO modelo);
        Task<bool> Eliminar(int id);
        Task<List<PacienteDTO>> Obtener(int id);
    }
}
