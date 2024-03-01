//using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LobbyAPI.Models;
//using JogadorAPI.Db;
using DataBaseAPI.Db;


namespace TimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private readonly DataBaseContext Newcontext;

        public JogadorController(DataBaseContext context)
        {
            Newcontext = context;
        }

        // GET: api/Jogador
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogador>>> GetJogadores()
        {
          if (Newcontext.Jogadores == null)
          {
              return NotFound();
          }
            return await Newcontext.Jogadores.ToListAsync();
        }

        // GET: api/Jogador/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Jogador>> GetJogador(int id)
        {
          if (Newcontext.Jogadores == null)
          {
              return NotFound();
          }
            var Jogador = await Newcontext.Jogadores.FindAsync(id);

            if (Jogador == null)
            {
                return NotFound();
            }

            return Jogador;
        }

        // PUT: api/Jogador/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJogador(int id, Jogador Jogador)
        {
            if (id != Jogador.JogadoresId)
            {
                return BadRequest();
            }

            Newcontext.Entry(Jogador).State = EntityState.Modified;

            try
            {
                await Newcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!JogadorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await Newcontext.Jogadores.ToListAsync());
        }

        // POST: api/Jogador
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Jogador>> PostJogador(Jogador Jogador)
        {
          if (Newcontext.Jogadores == null)
          {
              return Problem("Entity set 'JogadorContext.Jogadores'  is null.");
          }
            Newcontext.Jogadores.Add(Jogador);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Jogadores.ToListAsync());
        }

        // DELETE: api/Jogador/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJogador(int id)
        {
            if (Newcontext.Jogadores == null)
            {
                return NotFound();
            }
            var Jogador = await Newcontext.Jogadores.FindAsync(id);
            if (Jogador == null)
            {
                return NotFound();
            }

            Newcontext.Jogadores.Remove(Jogador);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Jogadores.ToListAsync());
        }

        private bool JogadorExists(int id)
        {
            return (Newcontext.Jogadores?.Any(e => e.JogadoresId == id)).GetValueOrDefault();
        }

[HttpPost("LimparJogadores")]
public async Task<IActionResult> InicializarJogadores()
{
    var jogadores = await Newcontext.Jogadores.ToListAsync();

    foreach (var jogador in jogadores)
    {
        jogador.Jogador1 = 0;
        jogador.Jogador2 = 0;
        jogador.Jogador3 = 0;
        jogador.Jogador4 = 0;
        jogador.Jogador5 = 0;
        jogador.Jogador6 = 0;
        jogador.Jogador7 = 0;
        jogador.Jogador8 = 0;
        jogador.Jogador9 = 0;
        jogador.Jogador10 = 0;
        jogador.Jogador11 = 0;
        jogador.Jogador12 = 0;
        jogador.Jogador13 = 0;
        jogador.Jogador14 = 0;
        jogador.Jogador15 = 0;
        jogador.Jogador16 = 0;
        jogador.Jogador17 = 0;
        jogador.Jogador18 = 0;
        jogador.Jogador19 = 0;
        jogador.Jogador20 = 0;
        jogador.Jogador21 = 0;
        jogador.Jogador22 = 0;
        jogador.Jogador23 = 0;
        jogador.Jogador24 = 0;
        

        // Salve as alterações no contexto
        Newcontext.SaveChanges();
    }

    return Ok("Valores dos jogadores definidos como 0");
}








    }  
}
