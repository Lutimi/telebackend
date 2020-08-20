using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.PagoAdelantado;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoAdelantadosController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public PagoAdelantadosController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/PagoAdelantados
        [HttpGet("[action]")]
        public async Task<IEnumerable<PagoAdelantadoViewModel>> List()//CAMBIAR
        {
            var PagoAdelantadoList = await _context.PagoAdelantados.ToListAsync();//CAMBIAR

            return PagoAdelantadoList.Select(c => new PagoAdelantadoViewModel//CAMBIAR
            {
                PagoAdelantadoId = c.PagoAdelantadoId,//CAMBIAR
                Nombre = c.Nombre,
                Procentaje = c.Procentaje,
                Descripcion = c.Descripcion
            });
        }

        // GET: api/PagoAdelantados/Show/5
        [HttpGet("{id}")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PagoAdelantadoViewModel>> Show([FromRoute] int id)//CAMBIAR
        {
            var PagoAdelantado = await _context.PagoAdelantados.FindAsync(id);//CAMBIAR

            if (PagoAdelantado == null)//CAMBIAR
            {
                return NotFound();
            }

            return Ok(new PagoAdelantadoViewModel//CAMBIAR
            {
                PagoAdelantadoId = PagoAdelantado.PagoAdelantadoId,//CAMBIAR
                Nombre = PagoAdelantado.Nombre,
                Procentaje = PagoAdelantado.Procentaje,
                Descripcion = PagoAdelantado.Descripcion
            });
        }

        // PUT: api/PagoAdelantados/Update/5
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdatePagoAdelantadoViewModel model)//CAMBIAR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (model.PagoAdelantadoId <= 0)//CAMBIAR
            {
                return BadRequest();
            }

            //CAMBIAR
            var PagoAdelantado = await _context.PagoAdelantados.FirstOrDefaultAsync(c => c.PagoAdelantadoId == model.PagoAdelantadoId);
            if (PagoAdelantado == null)//CAMBIAR
            {
                return NotFound();
            }
            //ID POR DEFECTO
            PagoAdelantado.Nombre = model.Nombre;//CAMBIAR
            PagoAdelantado.Procentaje = model.Procentaje;
            PagoAdelantado.Descripcion = model.Descripcion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/PagoAdelantados/Create
        [HttpPost("[action]")]
        public async Task<ActionResult<PagoAdelantado>> Create([FromBody]CreatePagoAdelantadoViewModel model)//CAMBIAR
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PagoAdelantado PagoAdelantado = new PagoAdelantado//CAMBIAR
            {
                Nombre = model.Nombre,//CAMBIAR
                Procentaje = model.Procentaje,
                Descripcion = model.Descripcion
            };


            _context.PagoAdelantados.Add(PagoAdelantado);//CAMBIAR
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/PagoAdelantados/Delete/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var r = await _context.PagoAdelantados.FindAsync(id); //CAMBIAR
            if (r == null)//CAMBIAR
            {
                return NotFound();
            }
            _context.PagoAdelantados.Remove(r);//CAMBIAR
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }
    }
}
