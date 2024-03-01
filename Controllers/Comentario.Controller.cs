using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ComentarioAPI.Models;
using UsuarioAPI.Models;
//using ConfirmacaoAPI.Db;
using DataBaseAPI.Db;
//using BCrypt.Net;

namespace ComentarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioController : ControllerBase
    {
        private readonly DataBaseContext Newcontext;

        public ComentarioController(DataBaseContext context)
        {
            Newcontext = context;
        }

        // GET: api/Comentario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Comentario>>> GetComentarios()
        {
          if (Newcontext.Comentarios == null)
          {
              return NotFound();
          }
            return await Newcontext.Comentarios.ToListAsync();
        }

        // GET: api/Comentario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comentario>> GetComentario(int id)
        {
          if (Newcontext.Comentarios == null)
          {
              return NotFound();
          }
            var Comentario = await Newcontext.Comentarios.FindAsync(id);

            if (Comentario == null)
            {
                return NotFound();
            }

            return Comentario;
        }

        // PUT: api/Comentario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComentario(int id, Comentario Comentario)
        {
            if (id != Comentario.ComentarioId)
            {
                return BadRequest();
            }

            Newcontext.Entry(Comentario).State = EntityState.Modified;

            try
            {
                await Newcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComentarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await Newcontext.Comentarios.ToListAsync());
        }

[HttpPost]
public async Task<ActionResult<Comentario>> PostComentario(Comentario Comentario)
{
    if (Newcontext.Comentarios == null)
    {
        return Problem("Entity set 'ComentarioContext.Comentarios' is null.");
    }

    // Verificar se já existe uma confirmação para o mesmo usuário e lobby
    var existingComentario = await Newcontext.Comentarios
        .FirstOrDefaultAsync(c =>
            c.IdUsuario == Comentario.IdUsuario &&
            c.IdQuadra == Comentario.IdQuadra);

    if (existingComentario != null)
    {
        // Já existe uma confirmação para o mesmo usuário e lobby, você pode retornar um erro ou fazer o que for apropriado
        return Conflict("Já existe uma confirmação para este usuário e lobby.");
    }

    // Não existe uma confirmação duplicada, então você pode adicioná-la
    Newcontext.Comentarios.Add(Comentario);
    await Newcontext.SaveChangesAsync();

    return Ok(await Newcontext.Comentarios.ToListAsync());
}
        // DELETE: api/Comentario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComentario(int id)
        {
            if (Newcontext.Comentarios == null)
            {
                return NotFound();
            }
            var Comentario = await Newcontext.Comentarios.FindAsync(id);
            if (Comentario == null)
            {
                return NotFound();
            }

            Newcontext.Comentarios.Remove(Comentario);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Comentarios.ToListAsync());
        }

        private bool ComentarioExists(int id)
        {
            return (Newcontext.Comentarios?.Any(e => e.ComentarioId == id)).GetValueOrDefault();
        }

        // POST: api/Comentario/Login


     //GET /api/seucontrolador/GetComentarioPorIds?idQuadra=1&idUsuario=2
[HttpGet("GetComentarioPorIds")]
public async Task<ActionResult<bool>> GetComentarioPorIds(int idQuadra, int idUsuario)
{
    // Primeiro, verifique se a confirmação existe com base nos IDs fornecidos
    var Comentario = await Newcontext.Comentarios
        .FirstOrDefaultAsync(c => c.IdQuadra == idQuadra && c.IdUsuario == idUsuario);

    // Se a confirmação não existe, retorne um status NotFound
    if (Comentario == null)
    {
        return Ok(false);
    }

    // Caso contrário, retorne o status de confirmação (true/false)
    return Ok(true);
}


[HttpGet("TodosComentarios/{quadraId}")]
public async Task<IActionResult> GetComentarios(int quadraId)
{
    var comentarios = await Newcontext.Comentarios
        .Where(c => c.IdQuadra == quadraId)
        .Join(
            Newcontext.Usuarios,
            comentario => comentario.IdUsuario,
            usuario => usuario.UsuarioId,
            (comentario, usuario) => new ComentarioDTO
            {
                ComentarioId = comentario.ComentarioId,
                IdUsuario = comentario.IdUsuario,
                IdQuadra = comentario.IdQuadra,
                ComentarioCompleto = comentario.ComentarioCompleto,
                NomeUsuario = usuario.Nome
            }
        )
        .ToListAsync();

    return Ok(comentarios);
}

    }
}