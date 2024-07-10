using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sogs.BLL.Servicios.Contrato;
using Sogs.DAL.Repositorios.Contrato;
using Sogs.DTO;
using Sogs.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sogs.BLL.Servicios
{
    public class DocumentoService: IDocumentoService
    {
        private readonly IGenericRepository<Documento> _documentoRepositorio;
        private readonly IGenericRepository<PretutelaDocumento> _pretutelaDocumentoRepositorio;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public DocumentoService(IGenericRepository<Documento> documentoRepositorio,
                                IGenericRepository<PretutelaDocumento> pretutelaDocumentoRepositorio,
                                IMapper mapper, IConfiguration configuration)
        {
            _documentoRepositorio = documentoRepositorio;
            _pretutelaDocumentoRepositorio = pretutelaDocumentoRepositorio;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<List<DocumentoDTO>> lista()
        {
            try
            {
                var queryDocumento = await _documentoRepositorio.Consultar();
                var listaDocumento = queryDocumento              
                    .ToList();
                return _mapper.Map<List<DocumentoDTO>>(listaDocumento);
            }
            catch
            {
                throw;
            }
        }

        public async Task<DocumentoDTO> Crear(DocumentoDTO modelo)
        {
            try
            {
                var documentoCreado = await _documentoRepositorio.Crear(_mapper.Map<Documento>(modelo));

                if (documentoCreado.IdDocumento == 0)
                    throw new TaskCanceledException("No se pudo crear el documento");

                return _mapper.Map<DocumentoDTO>(documentoCreado);
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
                var documentoEncontrado = await _documentoRepositorio.Obtener(u => u.IdDocumento == id);

                if (documentoEncontrado == null)
                    throw new TaskCanceledException("El documento no existe");

                bool respuesta = await _documentoRepositorio.Eliminar(documentoEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;

            }
            catch
            {
                throw;
            }
        }




        public async Task<List<DocumentoDTO>> GetDocumentsByPretutela(int pretutelaId)
        {         
            
            var basePath = _configuration["DocumentSettings:BasePath"];

            try
            {


                // Obtener PretutelaDocumentos
                var pretutelaDocumentos = await _pretutelaDocumentoRepositorio.Consultar();
                var filteredPretutelaDocumentos = await pretutelaDocumentos
                    .Where(pd => pd.IdPretutela == pretutelaId)
                    .ToListAsync();

                var documentoIds = filteredPretutelaDocumentos.Select(pd => pd.IdDocumento).ToList();

                // Obtener Documentos correspondientes a los IDs
                var documentos = await _documentoRepositorio.Consultar();
                var filteredDocumentos = await documentos
                    .Where(d => documentoIds.Contains(d.IdDocumento))
                    .ToListAsync();

                // Crear DocumentoDTO con la URL completa
                var documentoDTOs = filteredDocumentos.Select(d => new DocumentoDTO
                {
                    IdDocumento = d.IdDocumento,
                    NombreDocumento = d.NombreDocumento,
                    FechaRegistro = d.FechaRegistro,
                    RutaDocumento = $"{basePath}{d.RutaDocumento}" // Formar la URL completa
                }).ToList();

                return documentoDTOs;


            }
            catch
            {
                throw;
            }

        }







    }
}
