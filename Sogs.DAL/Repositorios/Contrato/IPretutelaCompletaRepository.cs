using Sogs.DTO;
using Sogs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sogs.DAL.Repositorios.Contrato
{
    public interface IPretutelaCompletaRepository : IGenericRepository<PretutelaPacienteRepresentadoDocDTO>
    {
        Task<bool> GuardarPretutelaCompleta(PretutelaPacienteRepresentadoDocDTO modelo);
    }
}
