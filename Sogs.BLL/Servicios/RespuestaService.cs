using AutoMapper;
using Sogs.BLL.Servicios.Contrato;
using Sogs.DAL.Repositorios.Contrato;
using Sogs.DTO;
using Sogs.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.BLL.Servicios
{
    public class RespuestaService : IRespuestaService
    {
        private readonly IGenericRepository<Respuesta> _respuestaRepositorio;
        private readonly IMapper _mapper;

        public RespuestaService(IGenericRepository<Respuesta> respuestaRepositorio, IMapper mapper)
        {
            _respuestaRepositorio = respuestaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<RespuestaDTO>> Lista()
        {
            try
            {
                var listaRespuesta = await _respuestaRepositorio.Consultar();
                return _mapper.Map<List<RespuestaDTO>>(listaRespuesta.ToList());

            }
            catch
            {
                throw;
            }
        }
    }
}
