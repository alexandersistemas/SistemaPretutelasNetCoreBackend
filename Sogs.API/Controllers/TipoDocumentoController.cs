using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {

        private readonly ITipoDocumentoService _tipoDocumentoServicio;

        public TipoDocumentoController(ITipoDocumentoService tipoDocumentoServicio)
        {
            _tipoDocumentoServicio = tipoDocumentoServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<TipoDocumentoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _tipoDocumentoServicio.Lista();

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
