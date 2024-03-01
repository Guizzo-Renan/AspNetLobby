//using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LobbyAPI.Models;
//using LobbyAPI.Db;
using DataBaseAPI.Db;


namespace LobbyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LobbyController : ControllerBase
    {
        private readonly DataBaseContext Newcontext;

        public LobbyController(DataBaseContext context)
        {
            Newcontext = context;
        }

        // GET: api/Lobby
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lobby>>> GetLobbys()
        {
          if (Newcontext.Lobbys == null)
          {
              return NotFound();
          }
            return await Newcontext.Lobbys.ToListAsync();
        }

        // GET: api/Lobby/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lobby>> GetLobby(int id)
        {
          if (Newcontext.Lobbys == null)
          {
              return NotFound();
          }
            var Lobby = await Newcontext.Lobbys.FindAsync(id);

            if (Lobby == null)
            {
                return NotFound();
            }

            return Lobby;
        }
      
        // PUT: api/Lobby/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLobby(int id, Lobby Lobby)
        {
            if (id != Lobby.LobbyId)
            {
                return BadRequest();
            }

            Newcontext.Entry(Lobby).State = EntityState.Modified;

            try
            {
                await Newcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LobbyExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await Newcontext.Lobbys.ToListAsync());
        }

        // POST: api/Lobby
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lobby>> PostLobby(Lobby Lobby)
        {
          if (Newcontext.Lobbys == null)
          {
              return Problem("Entity set 'LobbyContext.Lobbys'  is null.");
          }
            Newcontext.Lobbys.Add(Lobby);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Lobbys.ToListAsync());
        }

        // DELETE: api/Lobby/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLobby(int id)
        {
            if (Newcontext.Lobbys == null)
            {
                return NotFound();
            }
            var Lobby = await Newcontext.Lobbys.FindAsync(id);
            if (Lobby == null)
            {
                return NotFound();
            }

            Newcontext.Lobbys.Remove(Lobby);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Lobbys.ToListAsync());
        }

        private bool LobbyExists(int id)
        {
            return (Newcontext.Lobbys?.Any(e => e.LobbyId == id)).GetValueOrDefault();
        }

    
   
    [HttpGet("quadra/{quadraId}")]
public async Task<ActionResult<IEnumerable<Lobby>>> GetLobbysPorQuadra(int quadraId)
{
    var lobbies = await Newcontext.Lobbys
        .Where(l => l.IdQuadra == quadraId)
        .ToListAsync();

    if (lobbies == null || lobbies.Count == 0)
    {
        return NotFound();
    }

    return lobbies;
}

/*
   [HttpPut("/Jogadores/{id}")]
        public async Task<IActionResult> PutJogadores(int id, Jogador Jogador)
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
               
                    throw;
                
            }

            return Ok(await Newcontext.Jogadores.ToListAsync());
        }*/

    }
}
