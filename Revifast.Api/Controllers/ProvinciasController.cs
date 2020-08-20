using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Revifast.Api.Models.Provincia;
using Revifast.Data;
using Revifast.Entities;

namespace Revifast.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly DbRevifastContext _context;

        public ProvinciasController(DbRevifastContext context)
        {
            _context = context;
        }

        // GET: api/Provincias/List
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProvinciaViewModel>> List()
        {
            var provinciaList = await _context.Provincias.ToListAsync();

            return provinciaList.Select(c => new ProvinciaViewModel
            {
                ProvinciaId=c.ProvinciaId,
                Nombre=c.Nombre,       
            });
        }

        // GET: api/Provincias/5
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ProvinciaViewModel>> Show([FromRoute] int id)
        {
            var provincia = await _context.Provincias.FindAsync(id);

            if (provincia == null)
            {
                return NotFound();
            }

            return Ok(new ProvinciaViewModel
            {
                ProvinciaId = provincia.ProvinciaId,
                Nombre = provincia.Nombre
            });
        }

        // PUT: api/Provincias/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateProvinciaViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            if (model.ProvinciaId <= 0)//validando que el provinciaid llegue por parametro en positivo
            {
                return BadRequest();
            }

            //como todo es asincrono se le pone le await
            var cat = await _context.Provincias.FirstOrDefaultAsync(c => c.ProvinciaId == model.ProvinciaId);//si encuentra coincidencia lo asigna al cat(encuentra un objeto)
            if (cat == null)
            {
                return NotFound();
            }
            //el provinciaid ya esta por defecto
            cat.Nombre = model.Nombre;
            cat.DepartamentoId = model.DepartamentoId;

            try
            {
                //palabra reservada
                await _context.SaveChangesAsync();//guardando cambios hacia la bd, siempre se utiliza el try-catch
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Provincias
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("[action]")]
        public async Task<ActionResult<Provincia>> Create([FromBody]CreatePagoAdelantadoViewModel model)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }

            Provincia ca = new Provincia
            {
                Nombre = model.Nombre,
                DepartamentoId = model.DepartamentoId
                
            };

            _context.Provincias.Add(ca);//como si escribieras el insert sin ejecutar
            try
            {
                await _context.SaveChangesAsync();//con el savechanges lo aterrizas o actualizar los cambios en la bd
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Provincias/5
        [HttpDelete("[action]/{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)//validando
            {
                return BadRequest(ModelState);
            }
            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }
            _context.Provincias.Remove(provincia);
            try
            {
                await _context.SaveChangesAsync();//con el savechanges lo aterrizas o actualizar los cambios en la bd
            }
            catch (Exception)
            {

                return BadRequest();
            }

            return Ok();
        }

        private bool ProvinciaExists(int id)
        {
            return _context.Provincias.Any(e => e.ProvinciaId == id);
        }
    }
}
