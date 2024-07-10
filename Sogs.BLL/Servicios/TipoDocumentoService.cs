using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sogs.BLL.Servicios.Contrato;
using Sogs.DAL.Repositorios.Contrato;
using Sogs.DTO;
using Sogs.Model;

namespace Sogs.BLL.Servicios
{
    public class TipoDocumentoService : ITipoDocumentoService
    {
        private readonly IGenericRepository<TipoDocumento> _tipoDocumentoRepositorio;
        private readonly IMapper _mapper;

        public TipoDocumentoService(IGenericRepository<TipoDocumento> tipoDocumentoRepositorio, IMapper mapper)
        {
            _tipoDocumentoRepositorio = tipoDocumentoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<TipoDocumentoDTO>> Lista()
        {
            try
            {
                var listaTipoDocumentos = await _tipoDocumentoRepositorio.Consultar();
                return _mapper.Map<List<TipoDocumentoDTO>>(listaTipoDocumentos.ToList());

            }
            catch
            {
                throw;
            }
        }
    }
}
