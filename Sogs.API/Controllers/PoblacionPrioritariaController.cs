using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PoblacionPrioritariaController : ControllerBase
    {
        private readonly IPoblacionPrioritariaService _poblacionprioritariaServicio;

        public PoblacionPrioritariaController(IPoblacionPrioritariaService poblacionprioritariaServicio)
        {
            _poblacionprioritariaServicio = poblacionprioritariaServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<PoblacionPrioritariaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _poblacionprioritariaServicio.Lista();

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }

    }
}
