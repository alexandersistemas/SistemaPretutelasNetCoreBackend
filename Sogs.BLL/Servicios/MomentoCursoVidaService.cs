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
    public class MomentoCursoVidaService:IMomentoCursoVidaService
    {
        private readonly IGenericRepository<MomentoCursoVida> _momentocursovidaRepositorio;
        private readonly IMapper _mapper;

        public MomentoCursoVidaService(IGenericRepository<MomentoCursoVida> momentocursovidaRepositorio, IMapper mapper)
        {
            _momentocursovidaRepositorio = momentocursovidaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<MomentoCursoVidaDTO>> Lista()
        {
            try
            {
                var listaMomentoCursoVida = await _momentocursovidaRepositorio.Consultar();
                return _mapper.Map<List<MomentoCursoVidaDTO>>(listaMomentoCursoVida.ToList());

            }
            catch
            {
                throw;
            }
        }


    }
}
