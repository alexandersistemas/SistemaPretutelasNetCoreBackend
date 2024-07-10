﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


using Sogs.BLL.Servicios.Contrato;
using Sogs.DTO;
using Sogs.API.Utilidad;

namespace Sogs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscapacidadController : ControllerBase
    {

        private readonly IDiscapacidadService _discapacidadServicio;

        public DiscapacidadController(IDiscapacidadService discapacidadServicio)
        {
            _discapacidadServicio = discapacidadServicio;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            var rsp = new Response<List<DiscapacidadDTO>>();

            try
            {
                rsp.status = true;
                rsp.value = await _discapacidadServicio.Lista();

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
