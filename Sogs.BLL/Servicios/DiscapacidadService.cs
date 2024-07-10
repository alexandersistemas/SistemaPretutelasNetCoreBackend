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
    public class DiscapacidadService : IDiscapacidadService
    {
        private readonly IGenericRepository<Discapacidad> _discapacidadRepositorio;
        private readonly IMapper _mapper;

        public DiscapacidadService(IGenericRepository<Discapacidad> discapacidadRepositorio, IMapper mapper)
        {
            _discapacidadRepositorio = discapacidadRepositorio;
            _mapper = mapper;
        }


        public async Task<List<DiscapacidadDTO>> Lista()
        {
            try
            {
                var listaDiscapacidad= await _discapacidadRepositorio.Consultar();
                return _mapper.Map<List<DiscapacidadDTO>>(listaDiscapacidad.ToList());

            }
            catch
            {
                throw;
            }
        }
    }
}
