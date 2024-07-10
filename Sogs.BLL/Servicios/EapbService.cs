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
    public class EapbService : IEapbService
    {
        private readonly IGenericRepository<Eapb> _eapbRepositorio;
        private readonly IMapper _mapper;

        public EapbService(IGenericRepository<Eapb> eapbRepositorio, IMapper mapper)
        {
            _eapbRepositorio = eapbRepositorio;
            _mapper = mapper;
        }

        public async Task<List<EapbDTO>> Lista()
        {
            try
            {
                var listaEapb = await _eapbRepositorio.Consultar();
                return _mapper.Map<List<EapbDTO>>(listaEapb.ToList());

            }
            catch
            {
                throw;
            }
        }
    }
}
