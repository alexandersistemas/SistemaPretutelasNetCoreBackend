using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sogs.DTO;

namespace Sogs.BLL.Servicios.Contrato
{
    public interface IParentescoService
    {
        Task<List<ParentescoDTO>> Lista();
    }
}
