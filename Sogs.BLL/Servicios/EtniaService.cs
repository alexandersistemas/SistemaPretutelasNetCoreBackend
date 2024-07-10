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
    public class EtniaService:IEtniaService
    {
        private readonly IGenericRepository<Etnia> _etniaRepositorio;
        private readonly IMapper _mapper;

        public EtniaService(IGenericRepository<Etnia> etniaRepositorio, IMapper mapper)
        {
            _etniaRepositorio = etniaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<EtniaDTO>> Lista()
        {
            try
            {
                var listaEtnia = await _etniaRepositorio.Consultar();
                return _mapper.Map<List<EtniaDTO>>(listaEtnia.ToList());

            }
            catch
            {
                throw;
            }
        }
    }
}
