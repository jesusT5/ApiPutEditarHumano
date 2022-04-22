using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ApiPutEditarHumano.Data;
using ApiPutEditarHumano.Modelo;

namespace ApiPutEditarHumano.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HumanosController : ControllerBase
    {
        private readonly ApiPutEditarHumanoContext _context;

        public HumanosController(ApiPutEditarHumanoContext context)
        {
            _context = context;
        }

        // POST: Humanos/Edit/5
        [HttpPut("Edit")]
        public async Task<IActionResult> Edit([Bind("Id,Nombre,Sexo,Edad,Altura,Peso")] Humano humano)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!HumanoExists(humano.Id))
                    {
                        return NotFound();
                    }

                    _context.Update(humano);
                    await _context.SaveChangesAsync();
                    return Ok(humano);
                }
                catch (Exception)
                {
                    return BadRequest(404);
                }
            }
            return Ok(humano);
        }

        private bool HumanoExists(int id)
        {
            return _context.Humano.Any(e => e.Id == id);
        }
    }
}
