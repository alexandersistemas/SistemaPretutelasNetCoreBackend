﻿using Sogs.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.BLL.Servicios.Contrato
{
    public interface ISexoService
    {
        Task<List<SexoDTO>> Lista();
    }
}
