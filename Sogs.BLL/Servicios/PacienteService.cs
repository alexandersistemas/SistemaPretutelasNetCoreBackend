using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class PacienteService : IPacienteService
    {

        private readonly IGenericRepository<Paciente> _pacienteRepositorio;
        private readonly IMapper _mapper;

        public PacienteService(IGenericRepository<Paciente> pacienteRepositorio, IMapper mapper)
        {
            _pacienteRepositorio = pacienteRepositorio;
            _mapper = mapper;
        }

        public async Task<List<PacienteDTO>> lista()
        {
            try
            {
                var queryPaciente = await _pacienteRepositorio.Consultar();
                var listaPaciente = queryPaciente
                    .Include(TipoDocumento => TipoDocumento.IdTipoDocumentoNavigation)
                    .Include(Sexo => Sexo.IdSexoNavigation)
                    .Include(identGenero => identGenero.IdIdentidadGeneroNavigation)
                    .Include(GPoblacional => GPoblacional.IdGrupoPobNavigation)
                    .Include(PoblPrioritaria => PoblPrioritaria.IdPoblacionPrioritariaNavigation)
                    .Include(Etnia => Etnia.IdEtniaNavigation)
                    .Include(Regimen => Regimen.IdRegimenNavigation)
                    .Include(Discapacidad => Discapacidad.IdDiscapacidadNavigation)
                    .Include(Parentesco => Parentesco.IdParentescoNavigation)
                    .Include(MomentoCursoVida => MomentoCursoVida.IdMomentoCursoVidaNavigation)
                    .ToList();
                return _mapper.Map<List<PacienteDTO>>(listaPaciente);
            }
            catch
            {
                throw;
            }
        }

        public async Task<PacienteDTO> Crear(PacienteDTO modelo)
        {
            try
            {
                var pacienteCreado = await _pacienteRepositorio.Crear(_mapper.Map<Paciente>(modelo));

                if (pacienteCreado.IdPaciente == 0)
                    throw new TaskCanceledException("No se pudo crear el paciente");

                return _mapper.Map<PacienteDTO>(pacienteCreado);
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Editar(PacienteDTO modelo)
        {
            try
            {
                var pacienteModelo = _mapper.Map<Paciente>(modelo);
                var pacienteEncontrado = await _pacienteRepositorio.Obtener(u =>
                u.IdPaciente == pacienteModelo.IdPaciente
                );

                if (pacienteEncontrado == null)
                    throw new TaskCanceledException("El paciente no existe");

                pacienteEncontrado.IdTipoDocumento = pacienteModelo.IdTipoDocumento;
                pacienteEncontrado.NumeroDocumento = pacienteModelo.NumeroDocumento;
                pacienteEncontrado.PrimerNombre = pacienteModelo.PrimerNombre;
                pacienteEncontrado.SegundoNombre = pacienteModelo.SegundoNombre;
                pacienteEncontrado.PrimerApellido = pacienteModelo.PrimerApellido;
                pacienteEncontrado.SegundoApellido = pacienteModelo.SegundoApellido;
                pacienteEncontrado.IdSexo = pacienteModelo.IdSexo;
                pacienteEncontrado.IdIdentidadGenero = pacienteModelo.IdIdentidadGenero;
                pacienteEncontrado.FechaNacimiento = pacienteModelo.FechaNacimiento;
                pacienteEncontrado.IdGrupoPob = pacienteModelo.IdGrupoPob;
                pacienteEncontrado.IdPoblacionPrioritaria = pacienteModelo.IdPoblacionPrioritaria;
                pacienteEncontrado.IdEtnia = pacienteModelo.IdEtnia;
                pacienteEncontrado.IdRegimen = pacienteModelo.IdRegimen;
                pacienteEncontrado.OtroRegimen = pacienteModelo.OtroRegimen;
                pacienteEncontrado.IdDiscapacidad = pacienteModelo.IdDiscapacidad;
                pacienteEncontrado.IdParentesco = pacienteModelo.IdParentesco;
                pacienteEncontrado.OtroParentesco = pacienteModelo.OtroRegimen;
                pacienteEncontrado.IdMomentoCursoVida = pacienteModelo.IdMomentoCursoVida;
                pacienteEncontrado.Correo = pacienteModelo.Correo;
                pacienteEncontrado.Direccion = pacienteModelo.Direccion;
                pacienteEncontrado.TelefonoFijo = pacienteModelo.TelefonoFijo;
                pacienteEncontrado.IdTipoDocumentoRepresentado = pacienteModelo.IdTipoDocumentoRepresentado;
                pacienteEncontrado.NumeroDocumentoRepresentado = pacienteModelo.NumeroDocumentoRepresentado;
                pacienteEncontrado.NombresRepresentado = pacienteModelo.NombresRepresentado;
                pacienteEncontrado.ApellidosRepresentado = pacienteModelo.ApellidosRepresentado;

                bool respuesta = await _pacienteRepositorio.Editar(pacienteEncontrado);

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
                var pacienteEncontrado = await _pacienteRepositorio.Obtener(u => u.IdPaciente == id);

                if (pacienteEncontrado == null)
                    throw new TaskCanceledException("El paciente no existe");

                bool respuesta = await _pacienteRepositorio.Eliminar(pacienteEncontrado);

                if (!respuesta)
                    throw new TaskCanceledException("No se pudo eliminar");

                return respuesta;

            }
            catch
            {
                throw;
            }
        }



        public async Task<List<PacienteDTO>> Obtener(int id)
        {
            try
            {
                var queryPaciente = await _pacienteRepositorio.Consultar(u => u.IdPaciente == id);
                var listaPaciente = queryPaciente
                    .Include(TipoDocumento => TipoDocumento.IdTipoDocumentoNavigation)
                    .Include(Sexo => Sexo.IdSexoNavigation)
                    .Include(identGenero => identGenero.IdIdentidadGeneroNavigation)
                    .Include(GPoblacional => GPoblacional.IdGrupoPobNavigation)
                    .Include(PoblPrioritaria => PoblPrioritaria.IdPoblacionPrioritariaNavigation)
                    .Include(Etnia => Etnia.IdEtniaNavigation)
                    .Include(Regimen => Regimen.IdRegimenNavigation)
                    .Include(Discapacidad => Discapacidad.IdDiscapacidadNavigation)
                    .Include(Parentesco => Parentesco.IdParentescoNavigation)
                    .Include(MomentoCursoVida => MomentoCursoVida.IdMomentoCursoVidaNavigation)
                    .ToList();
                return _mapper.Map<List<PacienteDTO>>(listaPaciente);
            }
            catch
            {
                throw;
            }
        }


    }
}
