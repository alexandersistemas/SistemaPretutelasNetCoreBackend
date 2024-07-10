using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RespuestaController : ControllerBase
    {
        private readonly IRespuestaService _respuestaServicio;

        public RespuestaController(IRespuestaService respuestaServicio)
        {
            _respuestaServicio = respuestaServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<RespuestaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _respuestaServicio.Lista();

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
