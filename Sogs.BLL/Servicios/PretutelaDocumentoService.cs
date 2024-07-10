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
    public class PretutelaDocumentoService: IPretutelaDocumentoService
    {
        private readonly IGenericRepository<PretutelaDocumento> _pretuteladocumentoRepositorio;
        private readonly IMapper _mapper;

        public PretutelaDocumentoService(IGenericRepository<PretutelaDocumento> pretuteladocumentoRepositorio, IMapper mapper)
        {
            _pretuteladocumentoRepositorio = pretuteladocumentoRepositorio;
            _mapper = mapper;
        }


        public async Task<List<PretutelaDocumentoDTO>> lista()
        {
            try
            {
                var queryDocumento = await _pretuteladocumentoRepositorio.Consultar();
                var listaDocumento = queryDocumento
                    .ToList();
                return _mapper.Map<List<PretutelaDocumentoDTO>>(listaDocumento);
            }
            catch
            {
                throw;
            }
        }


        public async Task<PretutelaDocumentoDTO> Crear(PretutelaDocumentoDTO modelo)
        {
            try
            {
                var pretuteladocumentoCreado = await _pretuteladocumentoRepositorio.Crear(_mapper.Map<PretutelaDocumento>(modelo));

                if (pretuteladocumentoCreado.IdPretutelaDocumento == 0)
                    throw new TaskCanceledException("No se pudo crear la pretutela documento");

                return _mapper.Map<PretutelaDocumentoDTO>(pretuteladocumentoCreado);
            }
            catch
            {
                throw;
            }
        }

   

        public async Task<bool> Eliminar(int id)
        {
            try
            {
                var pretuteladocumentoEncontrado = await _pretuteladocumentoRepositorio.Obtener(u => u.IdPretutelaDocumento == id);

                if (pretuteladocumentoEncontrado == null)
                    throw new TaskCanceledException("La pretutela documento no existe");

                bool respuesta = await _pretuteladocumentoRepositorio.Eliminar(pretuteladocumentoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;

            }
            catch
            {
                throw;
            }
        }


        
    }
}
