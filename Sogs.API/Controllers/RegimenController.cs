using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegimenController : ControllerBase
    {
        private readonly IRegimenService _regimenServicio;

        public RegimenController(IRegimenService regimenServicio)
        {
            _regimenServicio = regimenServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<RegimenDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _regimenServicio.Lista();

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
