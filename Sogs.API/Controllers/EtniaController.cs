using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtniaController : ControllerBase
    {
        private readonly IEtniaService _etniaServicio;

        public EtniaController(IEtniaService etniaServicio)
        {
            _etniaServicio = etniaServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<EtniaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _etniaServicio.Lista();

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
