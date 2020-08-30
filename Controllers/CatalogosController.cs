using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICatalogo.DAO;
using APICatalogo.Models;

namespace APICatalogo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogosController : ControllerBase
    {
        private readonly CatalogoContext _context;

        public CatalogosController(CatalogoContext context)
        {
            _context = context;
        }

        // GET: api/Catalogoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalogo>>> GetCatalogos()
        {
            string teste = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                results = new List<Catalogo>()
                {
                    new Catalogo { CodBar = "1", Nome = "ABC", Valor = "ABC" },
                    new Catalogo { CodBar = "1", Nome = "ABC", Valor = "ABC" },
                }
            });

            return await _context.Catalogos.ToListAsync();
        }

        // GET: api/Catalogoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Catalogo>> GetCatalogo(long id)
        {
            var catalogo = await _context.Catalogos.FindAsync(id);

            if (catalogo == null)
            {
                return NotFound();
            }

            return catalogo;
        }

        // PUT: api/Catalogoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCatalogo(long id, Catalogo catalogo)
        {
            if (id != catalogo.Id)
            {
                return BadRequest();
            }

            _context.Entry(catalogo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CatalogoExists(id))
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

        // POST: api/Catalogoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Catalogo>> PostCatalogo(Catalogo catalogo)
        {
            _context.Catalogos.Add(catalogo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCatalogo", new { id = catalogo.Id }, catalogo);
        }

        // DELETE: api/Catalogoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Catalogo>> DeleteCatalogo(long id)
        {
            var catalogo = await _context.Catalogos.FindAsync(id);
            if (catalogo == null)
            {
                return NotFound();
            }

            _context.Catalogos.Remove(catalogo);
            await _context.SaveChangesAsync();

            return catalogo;
        }

        private bool CatalogoExists(long id)
        {
            return _context.Catalogos.Any(e => e.Id == id);
        }
    }
}
