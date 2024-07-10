using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PretutelaDocumentoController : ControllerBase
    {
        private readonly IPretutelaDocumentoService _pretuteladocumentoServicio;

        public PretutelaDocumentoController(IPretutelaDocumentoService pretuteladocumentoServicio)
        {
            _pretuteladocumentoServicio = pretuteladocumentoServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<PretutelaDocumentoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _pretuteladocumentoServicio.lista();

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] PretutelaDocumentoDTO pretueladocumento)
        {
            var rsp = new Response<PretutelaDocumentoDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _pretuteladocumentoServicio.Crear(pretueladocumento);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }


        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _pretuteladocumentoServicio.Eliminar(id);

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
