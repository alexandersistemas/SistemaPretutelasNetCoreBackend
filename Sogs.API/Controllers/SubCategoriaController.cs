using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoriaController : ControllerBase
    {
        private readonly ISubCategoriaService _subcategoriaServicio;

        public SubCategoriaController(ISubCategoriaService subcategoriaServicio)
        {
            _subcategoriaServicio = subcategoriaServicio;
        }


        [HttpGet]
        [Route("Obtener")]
        public async Task<IActionResult> Obtener(int idCategoria)
        {
            var rsp = new Response<List<SubCategoriaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _subcategoriaServicio.Obtener(idCategoria);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<SubCategoriaDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _subcategoriaServicio.Lista();

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
