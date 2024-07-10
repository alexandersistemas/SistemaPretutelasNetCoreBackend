using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;
using Microsoft.EntityFrameworkCore;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PretutelaController : ControllerBase
    {

        private readonly IPretutelaService _pretutelaServicio;

        public PretutelaController(IPretutelaService pretutelaServicio)
        {
            _pretutelaServicio = pretutelaServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<PretutelaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _pretutelaServicio.lista();

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
        public async Task<IActionResult> Guardar([FromBody] PretutelaDTO pretutela)
        {
            var rsp = new Response<PretutelaDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _pretutelaServicio.Crear(pretutela);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] PretutelaDTO pretutela)
        {
            var rsp = new Response<bool>();

            try
            {
                rsp.status = true;
                rsp.value = await _pretutelaServicio.Editar(pretutela);

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
                rsp.value = await _pretutelaServicio.Eliminar(id);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Historial")]
        public async Task<IActionResult> Historial( string buscarPor, string? numeroRadicado, string? fechaInicio, string? fechaFin, string? numeroDocumento)
        {
            var rsp = new Response<List<PretutelaDTO>>();
            numeroRadicado= numeroRadicado is null ? "" : numeroRadicado;
            fechaInicio = fechaInicio is null ? "" : fechaInicio;
            fechaFin = fechaFin is null ? "" : fechaFin;

            try
            {
                rsp.status = true;
                rsp.value = await _pretutelaServicio.Historial(buscarPor, numeroRadicado, fechaInicio, fechaFin, numeroDocumento);

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
