using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConfirmacaoAPI.Models;
//using ConfirmacaoAPI.Db;
using DataBaseAPI.Db;
//using BCrypt.Net;

namespace ConfirmacaoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfirmacaoController : ControllerBase
    {
        private readonly DataBaseContext Newcontext;

        public ConfirmacaoController(DataBaseContext context)
        {
            Newcontext = context;
        }

        // GET: api/Confirmacao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Confirmacao>>> GetConfirmacoes()
        {
          if (Newcontext.Confirmacoes == null)
          {
              return NotFound();
          }
            return await Newcontext.Confirmacoes.ToListAsync();
        }

        // GET: api/Confirmacao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Confirmacao>> GetConfirmacao(int id)
        {
          if (Newcontext.Confirmacoes == null)
          {
              return NotFound();
          }
            var Confirmacao = await Newcontext.Confirmacoes.FindAsync(id);

            if (Confirmacao == null)
            {
                return NotFound();
            }

            return Confirmacao;
        }

        // PUT: api/Confirmacao/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutConfirmacao(int id, Confirmacao Confirmacao)
        {
            if (id != Confirmacao.ConfirmacaoId)
            {
                return BadRequest();
            }

            Newcontext.Entry(Confirmacao).State = EntityState.Modified;

            try
            {
                await Newcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConfirmacaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await Newcontext.Confirmacoes.ToListAsync());
        }

        // POST: api/Confirmacao
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
     /*   [HttpPost]
        public async Task<ActionResult<Confirmacao>> PostConfirmacao(Confirmacao Confirmacao)
        {
          if (Newcontext.Confirmacoes == null)
          {
              return Problem("Entity set 'ConfirmacaoContext.Confirmacoes'  is null.");
          }
            Newcontext.Confirmacoes.Add(Confirmacao);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Confirmacoes.ToListAsync());
        }
*/
[HttpPost]
public async Task<ActionResult<Confirmacao>> PostConfirmacao(Confirmacao confirmacao)
{
    if (Newcontext.Confirmacoes == null)
    {
        return Problem("Entity set 'ConfirmacaoContext.Confirmacoes' is null.");
    }

    // Verificar se já existe uma confirmação para o mesmo usuário e lobby
    var existingConfirmacao = await Newcontext.Confirmacoes
        .FirstOrDefaultAsync(c =>
            c.IdUsuario == confirmacao.IdUsuario &&
            c.IdLobby == confirmacao.IdLobby);

    if (existingConfirmacao != null)
    {
        // Já existe uma confirmação para o mesmo usuário e lobby, você pode retornar um erro ou fazer o que for apropriado
        return Conflict("Já existe uma confirmação para este usuário e lobby.");
    }

    // Não existe uma confirmação duplicada, então você pode adicioná-la
    Newcontext.Confirmacoes.Add(confirmacao);
    await Newcontext.SaveChangesAsync();

    return Ok(await Newcontext.Confirmacoes.ToListAsync());
}
        // DELETE: api/Confirmacao/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteConfirmacao(int id)
        {
            if (Newcontext.Confirmacoes == null)
            {
                return NotFound();
            }
            var Confirmacao = await Newcontext.Confirmacoes.FindAsync(id);
            if (Confirmacao == null)
            {
                return NotFound();
            }

            Newcontext.Confirmacoes.Remove(Confirmacao);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Confirmacoes.ToListAsync());
        }

        private bool ConfirmacaoExists(int id)
        {
            return (Newcontext.Confirmacoes?.Any(e => e.ConfirmacaoId == id)).GetValueOrDefault();
        }

        // POST: api/Confirmacao/Login
     // POST: api/Confirmacao/Login



     //GET /api/seucontrolador/GetConfirmacaoPorIds?idLobby=1&idUsuario=2
[HttpGet("GetConfirmacaoPorIds")]
public async Task<ActionResult<bool>> GetConfirmacaoPorIds(int idLobby, int idUsuario)
{
    // Primeiro, verifique se a confirmação existe com base nos IDs fornecidos
    var confirmacao = await Newcontext.Confirmacoes
        .FirstOrDefaultAsync(c => c.IdLobby == idLobby && c.IdUsuario == idUsuario);

    // Se a confirmação não existe, retorne um status NotFound
    if (confirmacao == null)
    {
        return NotFound();
    }

    // Caso contrário, retorne o status de confirmação (true/false)
    return Ok(confirmacao.Confirmado);
}


    }
}