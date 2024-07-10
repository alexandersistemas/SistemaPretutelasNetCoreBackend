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
    public class SubCategoriaService : ISubCategoriaService
    {

        private readonly IGenericRepository<SubCategoria> _subcategoriaRepositorio;
        private readonly IMapper _mapper;

        public SubCategoriaService(IGenericRepository<SubCategoria> subcategoriaRepositorio, IMapper mapper)
        {
            _subcategoriaRepositorio = subcategoriaRepositorio;
            _mapper = mapper;
        }

        public async Task<List<SubCategoriaDTO>> Lista()
        {
            try
            {
                var listaSubCategoria = await _subcategoriaRepositorio.Consultar();
                return _mapper.Map<List<SubCategoriaDTO>>(listaSubCategoria.ToList());

            }
            catch
            {
                throw;
            }
        }


        public async Task<List<SubCategoriaDTO>> Obtener(int idCategoria)
        {
            try
            {
                var listaSubCategoria = await _subcategoriaRepositorio.Consultar(sc => sc.IdCategoria == idCategoria);
                return _mapper.Map<List<SubCategoriaDTO>>(listaSubCategoria.ToList());
            }
            catch
            {
                throw;
            }
        }

    }
}
