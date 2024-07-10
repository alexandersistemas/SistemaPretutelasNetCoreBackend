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
    public class IdentidadGeneroService : IIdentidadGeneroService
    {
        private readonly IGenericRepository<IdentidadGenero> _identidadgeneroRepositorio;
        private readonly IMapper _mapper;

        public IdentidadGeneroService(IGenericRepository<IdentidadGenero> identidadgeneroRepositorio, IMapper mapper)
        {
            _identidadgeneroRepositorio = identidadgeneroRepositorio;
            _mapper = mapper;
        }

        public async Task<List<IdentidadGeneroDTO>> Lista()
        {
            try
            {
                var listaIdentidadGenero = await _identidadgeneroRepositorio.Consultar();
                return _mapper.Map<List<IdentidadGeneroDTO>>(listaIdentidadGenero.ToList());

            }
            catch
            {
                throw;
            }
        }
    }
}
