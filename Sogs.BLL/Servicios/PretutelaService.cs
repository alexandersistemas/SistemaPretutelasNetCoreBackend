
using System;
using System.Collections.Generic;
using System.Globalization;
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
    public class PretutelaService : IPretutelaService
    {
        private readonly IGenericRepository<Pretutela> _pretutelaRepositorio;
        private readonly IMapper _mapper;

        public PretutelaService(IGenericRepository<Pretutela> pretutelaRepositorio, IMapper mapper)
        {
            _pretutelaRepositorio = pretutelaRepositorio;
            _mapper = mapper;
        }
        
        public async Task<List<PretutelaDTO>> lista()
        {
            try
            {
                var queryPretutela = await _pretutelaRepositorio.Consultar();
                var listaPretutela = queryPretutela
                    .Include(Categoria => Categoria.IdCategoriaNavigation)
                    .Include(Eapb => Eapb.IdEapbNavigation)
                    .Include(Paciente => Paciente.IdPacienteNavigation)
                    .Include(Subcategoria => Subcategoria.IdSubCategoriaNavigation)
                    .Include(Respuesta => Respuesta.IdRespuestaNavigation)
                    .ToList();
                return _mapper.Map<List<PretutelaDTO>>(listaPretutela);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PretutelaDTO> Crear(PretutelaDTO modelo)
        {
            try
            {
                var pretutelaCreada = await _pretutelaRepositorio.Crear(_mapper.Map<Pretutela>(modelo));

                if (pretutelaCreada.IdPretutela == 0)
                    throw new TaskCanceledException("No se pudo crear la pretutela");

                return _mapper.Map<PretutelaDTO>(pretutelaCreada);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PretutelaDTO modelo)
        {
            try
            {
                var pretutelaModelo = _mapper.Map<Pretutela>(modelo);
                var pretutelaEncontrado = await _pretutelaRepositorio.Obtener(u =>
                u.IdPretutela == pretutelaModelo.IdPretutela
                );

                if (pretutelaEncontrado == null)
                    throw new TaskCanceledException("La pretutela no existe");

                pretutelaEncontrado.NumeroRadicado = pretutelaModelo.NumeroRadicado;
                pretutelaEncontrado.IdEapb = pretutelaModelo.IdEapb;
                pretutelaEncontrado.FechaRecepcion = pretutelaModelo.FechaRecepcion;
                pretutelaEncontrado.IdCategoria = pretutelaModelo.IdCategoria;
                pretutelaEncontrado.IdSubCategoria = pretutelaModelo.IdSubCategoria;
                pretutelaEncontrado.Descripcion= pretutelaModelo.Descripcion;
                pretutelaEncontrado.IdPaciente = pretutelaModelo.IdPaciente;
                pretutelaEncontrado.IdUsuario = pretutelaModelo.IdUsuario;
                pretutelaEncontrado.Estado = pretutelaModelo.Estado;
                pretutelaEncontrado.IdRespuesta = pretutelaModelo.IdRespuesta;

                bool respuesta = await _pretutelaRepositorio.Editar(pretutelaEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo editar el paciente");

                return respuesta;


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
                var pretutelaEncontrado = await _pretutelaRepositorio.Obtener(u => u.IdPretutela == id);

                if (pretutelaEncontrado == null)
                    throw new TaskCanceledException("La pretutela no existe");

                bool respuesta = await _pretutelaRepositorio.Eliminar(pretutelaEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;

            }
            catch
            {
                throw;
            }
        }

        public async Task<List<PretutelaDTO>> Historial(string buscarPor, string? numeroRadicado, string? fechaInicio, string? fechaFin, string? numeroDocumento)
        {
            IQueryable<Pretutela> query = await _pretutelaRepositorio.Consultar();
            var ListaResultado = new List<Pretutela>();

            try
            {
                if (buscarPor == "fecha")
                {
                    DateTime fech_Inicio = DateTime.ParseExact(fechaInicio, "dd/MM/yyyy", new CultureInfo("es-COL"));
                    DateTime fech_Fin = DateTime.ParseExact(fechaFin, "dd/MM/yyyy", new CultureInfo("es-COL"));

                    ListaResultado = await query.Where(v =>
                        v.FechaRecepcion.Value.Date >= fech_Inicio.Date &&
                        v.FechaRecepcion.Value.Date <= fech_Fin.Date
                   ).Include(e => e.IdEapbNavigation)
                   .Include(c => c.IdCategoriaNavigation)
                   .Include(s => s.IdSubCategoriaNavigation)
                   .Include(r => r.IdRespuestaNavigation)
                   .Include(p => p.IdPaciente)
                   .ToListAsync(); 
                }
                else if (buscarPor == "numeroRadicado") { 

                    ListaResultado = await query.Where(v => v.NumeroRadicado == numeroRadicado
                  ).Include(e => e.IdEapbNavigation)
                  .Include(c => c.IdCategoriaNavigation)
                  .Include(s => s.IdSubCategoriaNavigation)
                  .Include(r => r.IdRespuestaNavigation)
                  .Include(p => p.IdPaciente)
                  .ToListAsync();

                }
                else if (buscarPor == "numeroDocumento")
                {
                    ListaResultado = await query.Where(v => v.IdPacienteNavigation.NumeroDocumento == numeroDocumento
                    ).Include(e => e.IdEapbNavigation)
                    .Include(c => c.IdCategoriaNavigation)
                    .Include(s => s.IdSubCategoriaNavigation)
                    .Include(r => r.IdRespuestaNavigation)
                    .Include(p => p.IdPacienteNavigation)
                    .ToListAsync();
                }

            }
            catch
            {
                throw;
            }

            return _mapper.Map<List<PretutelaDTO>>(ListaResultado);

            
        }







    }
}
