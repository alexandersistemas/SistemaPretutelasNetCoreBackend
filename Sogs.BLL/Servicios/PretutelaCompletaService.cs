
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
    public class PretutelaCompletaService : IPretutelaCompletaService
    {
       
        private readonly IGenericRepository<PretutelaPacienteRepresentadoDocDTO> _pretutelaRepositorio;        
        private readonly IMapper _mapper;

        public PretutelaCompletaService(IGenericRepository<PretutelaPacienteRepresentadoDocDTO> pretutelaRepositorio, IMapper mapper)
        {
            _pretutelaRepositorio = pretutelaRepositorio;
            _mapper = mapper;
        }

        public async Task<bool> GuardarPretutelaCompleta(PretutelaPacienteRepresentadoDocDTO modelo)
        {
            try
            {
                var pretutelaCreada = await _pretutelaRepositorio.GuardarPretutelaCompleta(modelo);

                if (!pretutelaCreada)
                    throw new TaskCanceledException("No se pudo crear la pretutela");

                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
