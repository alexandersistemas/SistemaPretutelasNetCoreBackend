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
    public class GrupoPoblacionalService:IGrupoPoblacionalService
    {
        private readonly IGenericRepository<GrupoPoblacional> _grupopoblacionalRepositorio;
        private readonly IMapper _mapper;

        public GrupoPoblacionalService(IGenericRepository<GrupoPoblacional> grupopoblacionalRepositorio, IMapper mapper)
        {
            _grupopoblacionalRepositorio = grupopoblacionalRepositorio;
            _mapper = mapper;
        }

        public async Task<List<GrupoPoblacionalDTO>> Lista()
        {
            try
            {
                var listaGrupoPoblacional = await _grupopoblacionalRepositorio.Consultar();
                return _mapper.Map<List<GrupoPoblacionalDTO>>(listaGrupoPoblacional.ToList());

            }
            catch
            {
                throw;
            }
        }
    }
}
