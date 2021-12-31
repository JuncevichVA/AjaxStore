using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using laba_1.DAL.Data;
using laba_1.DAL.Entities;

namespace laba_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AjaxesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AjaxesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Ajaxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ajax>>> GetAjaxes(int? group)
        {
            return await _context.Ajaxes
                .Where(d => !group.HasValue || d.AjaxGroupId.Equals(group.Value))
                ?.ToListAsync();
        }

        // GET: api/Ajaxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ajax>> GetAjax(int id)
        {
            var ajax = await _context.Ajaxes.FindAsync(id);

            if (ajax == null)
            {
                return NotFound();
            }

            return ajax;
        }

        // PUT: api/Ajaxes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAjax(int id, Ajax ajax)
        {
            if (id != ajax.DivicesID)
            {
                return BadRequest();
            }

            _context.Entry(ajax).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AjaxExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ajaxes
        [HttpPost]
        public async Task<ActionResult<Ajax>> PostAjax(Ajax ajax)
        {
            _context.Ajaxes.Add(ajax);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAjax", new { id = ajax.DivicesID }, ajax);
        }

        // DELETE: api/Ajaxes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ajax>> DeleteAjax(int id)
        {
            var ajax = await _context.Ajaxes.FindAsync(id);
            if (ajax == null)
            {
                return NotFound();
            }

            _context.Ajaxes.Remove(ajax);
            await _context.SaveChangesAsync();

            return ajax;
        }

        private bool AjaxExists(int id)
        {
            return _context.Ajaxes.Any(e => e.DivicesID == id);
        }
    }
}
