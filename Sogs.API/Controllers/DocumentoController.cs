using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;


namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoController : ControllerBase
    {
        private readonly IDocumentoService _documentoServicio;

        public DocumentoController(IDocumentoService documentoServicio)
        {
            _documentoServicio = documentoServicio;
        }


        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<DocumentoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _documentoServicio.lista();

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
        public async Task<IActionResult> Guardar([FromBody] DocumentoDTO documento)
        {
            var rsp = new Response<DocumentoDTO>();

            try
            {
                rsp.status = true;
                rsp.value = await _documentoServicio.Crear(documento);

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
                rsp.value = await _documentoServicio.Eliminar(id);

            }
            catch (Exception ex)
            {
                rsp.status = false;
                rsp.msg = ex.Message;

            }
            return Ok(rsp);
        }




        [HttpGet("pretutelaDocs/{pretutelaId:int}")]
        public async Task<IActionResult> GetDocumentsByPretutela(int pretutelaId)
        {
            var rsp = new Response<List<DocumentoDTO>>();
            try
            {
                rsp.status = true;
                rsp.value = await _documentoServicio.GetDocumentsByPretutela(pretutelaId);

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
