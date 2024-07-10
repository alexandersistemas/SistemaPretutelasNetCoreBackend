using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentescoController : ControllerBase
    {
        private readonly IParentescoService _parentescoServicio;

        public ParentescoController(IParentescoService parentescoServicio)
        {
            _parentescoServicio = parentescoServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<ParentescoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _parentescoServicio.Lista();

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
