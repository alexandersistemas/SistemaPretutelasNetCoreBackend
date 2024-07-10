using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EapbController : ControllerBase
    {

        private readonly IEapbService _eapbServicio;

        public EapbController(IEapbService eapbServicio)
        {
            _eapbServicio = eapbServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<EapbDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _eapbServicio.Lista();

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
