using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentidadGeneroController : ControllerBase
    {
        private readonly IIdentidadGeneroService _identidadgeneroServicio;

        public IdentidadGeneroController(IIdentidadGeneroService identidadgeneroServicio)
        {
            _identidadgeneroServicio = identidadgeneroServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<IdentidadGeneroDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _identidadgeneroServicio.Lista();

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
