using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;
using Azure.Core;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PretutelaPacienteRepresentadoDocController : ControllerBase
    {

        private readonly IPretutelaCompletaService _pretutelaCompletaServicio;

        public PretutelaPacienteRepresentadoDocController(IPretutelaCompletaService pretutelaCompletaServicio)
        {
            _pretutelaCompletaServicio = pretutelaCompletaServicio;
        }


        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] PretutelaPacienteRepresentadoDocDTO pretutela)
        {
            var rsp = new Response<bool>();


            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                rsp.status = true;
                rsp.value = await _pretutelaCompletaServicio.GuardarPretutelaCompleta(pretutela);

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
