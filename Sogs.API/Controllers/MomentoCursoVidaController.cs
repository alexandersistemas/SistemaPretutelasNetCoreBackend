using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MomentoCursoVidaController : ControllerBase
    {
        private readonly IMomentoCursoVidaService _momentocursovidaServicio;

        public MomentoCursoVidaController(IMomentoCursoVidaService momentocursovidaServicio)
        {
            _momentocursovidaServicio = momentocursovidaServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<MomentoCursoVidaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _momentocursovidaServicio.Lista();

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
