using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuadraAPI.Models;
using AvaliacaoAPI.Models;
//using QuadraAPI.Db;
using DataBaseAPI.Db;

namespace QuadraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuadraController : ControllerBase
    {
        private readonly DataBaseContext Newcontext;

        public QuadraController(DataBaseContext context)
        {
            Newcontext = context;
        }

        // GET: api/Quadra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quadra>>> GetQuadras()
        {
          if (Newcontext.Quadras == null)
          {
              return NotFound();
          }
            return await Newcontext.Quadras.ToListAsync();
        }

        // GET: api/Quadra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quadra>> GetQuadra(int id)
        {
          if (Newcontext.Quadras == null)
          {
              return NotFound();
          }
            var Quadra = await Newcontext.Quadras.FindAsync(id);

            if (Quadra == null)
            {
                return NotFound();
            }

            return Quadra;
        }

        // PUT: api/Quadra/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuadra(int id, Quadra Quadra)
        {
            if (id != Quadra.QuadraId)
            {
                return BadRequest();
            }

            Newcontext.Entry(Quadra).State = EntityState.Modified;

            try
            {
                await Newcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuadraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await Newcontext.Quadras.ToListAsync());
        }

        // POST: api/Quadra
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quadra>> PostQuadra(Quadra Quadra)
        {
          if (Newcontext.Quadras == null)
          {
              return Problem("Entity set 'QuadraContext.Quadras'  is null.");
          }
            Newcontext.Quadras.Add(Quadra);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Quadras.ToListAsync());
        }

        // DELETE: api/Quadra/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuadra(int id)
        {
            if (Newcontext.Quadras == null)
            {
                return NotFound();
            }
            var Quadra = await Newcontext.Quadras.FindAsync(id);
            if (Quadra == null)
            {
                return NotFound();
            }

            Newcontext.Quadras.Remove(Quadra);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Quadras.ToListAsync());
        }

        private bool QuadraExists(int id)
        {
            return (Newcontext.Quadras?.Any(e => e.QuadraId == id)).GetValueOrDefault();
        }
    
      /*  [HttpPut("Avaliar/{id}")]
    public async Task<IActionResult> AvaliarQuadra(int id, [FromBody] AvaliacaoModel avaliacao)
    {
    var quadra = await Newcontext.Quadras.FindAsync(id);

    if (quadra == null)
    {
        return NotFound();
    }

    // Atualizar a média das avaliações e o total
    quadra.avaliacaoQuadra = ((quadra.avaliacaoQuadra * quadra.TotalAvaliacoes) + avaliacao.Rating) / (quadra.TotalAvaliacoes + 1);
    quadra.TotalAvaliacoes++;

    Newcontext.Entry(quadra).State = EntityState.Modified;

    try
    {
        await Newcontext.SaveChangesAsync();
        return Ok(quadra);
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!QuadraExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }
}
       */ 
    
    
    }
}