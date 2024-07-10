using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoPoblacionalController : ControllerBase
    {
        private readonly IGrupoPoblacionalService _grupopoblacionalServicio;

        public GrupoPoblacionalController(IGrupoPoblacionalService grupopoblacionalServicio)
        {
            _grupopoblacionalServicio = grupopoblacionalServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<GrupoPoblacionalDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _grupopoblacionalServicio.Lista();

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
