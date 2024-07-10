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
    public class SexoService: ISexoService
    {
        private readonly IGenericRepository<Sexo> _sexoRepositorio;
        private readonly IMapper _mapper;

        public SexoService(IGenericRepository<Sexo> sexoRepositorio, IMapper mapper)
        {
            _sexoRepositorio = sexoRepositorio;
            _mapper = mapper;
        }

        public async Task<List<SexoDTO>> Lista()
        {
            try
            {
                var listaSexo = await _sexoRepositorio.Consultar();
                return _mapper.Map<List<SexoDTO>>(listaSexo.ToList());

            }
            catch
            {
                throw;
            }
        }



    }
}
