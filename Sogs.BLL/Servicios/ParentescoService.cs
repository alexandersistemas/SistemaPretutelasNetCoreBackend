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
    public class ParentescoService: IParentescoService
    {
        private readonly IGenericRepository<Parentesco> _parentescoRepositorio;
        private readonly IMapper _mapper;

        public ParentescoService(IGenericRepository<Parentesco> parentescoRepositorio, IMapper mapper)
        {
            _parentescoRepositorio = parentescoRepositorio;
            _mapper = mapper;
        }


        public async Task<List<ParentescoDTO>> Lista()
        {
            try
            {
                var listaParentesco = await _parentescoRepositorio.Consultar();
                return _mapper.Map<List<ParentescoDTO>>(listaParentesco.ToList());

            }
            catch
            {
                throw;
            }
        }


    }
}
