using AutoMapper;
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
    public class RegimenService:IRegimenService
    {
        private readonly IGenericRepository<Regimen> _regimenRepositorio;
        private readonly IMapper _mapper;

        public RegimenService(IGenericRepository<Regimen> regimenRepositorio, IMapper mapper)
        {
            _regimenRepositorio = regimenRepositorio;
            _mapper = mapper;
        }

        public async Task<List<RegimenDTO>> Lista()
        {
            try
            {
                var listaRegimen = await _regimenRepositorio.Consultar();
                return _mapper.Map<List<RegimenDTO>>(listaRegimen.ToList());

            }
            catch
            {
                throw;
            }
        }

    }
}
