using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Sogs.BLL.Servicios.Contrato;
using Sogs.DAL.Repositorios.Contrato;
using Sogs.DTO;
using Sogs.Model;

namespace Sogs.BLL.Servicios
{
    public class PoblacionPrioritariaService :IPoblacionPrioritariaService
    {
        private readonly IGenericRepository<PoblacionPrioritaria> _poblacionprioritariaRepositorio;
        private readonly IMapper _mapper;

        public PoblacionPrioritariaService(IGenericRepository<PoblacionPrioritaria> poblacionprioritariaRepositorio, IMapper mapper)
        {
            _poblacionprioritariaRepositorio = poblacionprioritariaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<PoblacionPrioritariaDTO>> Lista()
        {
            try
            {
                var listaPoblacionPrioritaria = await _poblacionprioritariaRepositorio.Consultar();
                return _mapper.Map<List<PoblacionPrioritariaDTO>>(listaPoblacionPrioritaria.ToList());

            }
            catch
            {
                throw;
            }
        }


    }
}
