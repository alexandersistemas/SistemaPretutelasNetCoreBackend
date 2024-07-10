﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexoController : ControllerBase
    {
        private readonly ISexoService _sexoServicio;

        public SexoController(ISexoService sexoServicio)
        {
            _sexoServicio = sexoServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<SexoDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _sexoServicio.Lista();

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
