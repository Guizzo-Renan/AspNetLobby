using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuarioNovoAPI.Models;
//using UsuarioNovoAPI.Db;
using DataBaseAPI.Db;
//using BCrypt.Net;

namespace UsuarioNovoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioNovoController : ControllerBase
    {
        private readonly DataBaseContext Newcontext;

        public UsuarioNovoController(DataBaseContext context)
        {
            Newcontext = context;
        }

        // GET: api/UsuarioNovo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioNovo>>> GetUsuarioNovos()
        {
          if (Newcontext.UsuarioNovos == null)
          {
              return NotFound();
          }
            return await Newcontext.UsuarioNovos.ToListAsync();
        }




/*
        // GET: api/UsuarioNovo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioNovo>> GetUsuarioNovo(int id)
        {
          if (Newcontext.UsuarioNovos == null)
          {
              return NotFound();
          }
            var UsuarioNovo = await Newcontext.UsuarioNovos.FindAsync(id);

            if (UsuarioNovo == null)
            {
                return NotFound();
            }

            return UsuarioNovo;
        }
*/
/*
[HttpGet("{id}")]
public async Task<ActionResult<UsuarioNovo>> GetUsuarioNovo(int id)
{
    var UsuarioNovo = await Newcontext.UsuarioNovos.Include(u => u.Icone).FirstOrDefaultAsync(u => u.UsuarioNovoId == id);

    if (UsuarioNovo == null)
    {
        return NotFound();
    }

    return UsuarioNovo;
}
*/

















/*
        [HttpGet("icone/{id}")]
public async Task<ActionResult<UsuarioNovo>> GetUsuarioNovo2(int id)
{
    var UsuarioNovo = await Newcontext.UsuarioNovos
        .Include(u => u.Icone) // Carrega o ícone relacionado
        .FirstOrDefaultAsync(u => u.UsuarioNovoId == id);

    if (UsuarioNovo == null)
    {
        return NotFound();
    }

    // Verifica se o ícone está carregado corretamente
    if (UsuarioNovo.Icone != null)
    {
        // Se o ícone não for nulo, você pode acessar o UrlImagem
        string urlimagem = UsuarioNovo.Icone.Urlimagem;

        // Adiciona a URL da imagem ao objeto UsuarioNovo antes de retornar
       // UsuarioNovo = urlimagem; 
       //const obj = {UsuarioNovo;urlimagem}
    }

    return UsuarioNovo;
}
*/
/*
        // PUT: api/UsuarioNovo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioNovo(int id, UsuarioNovo UsuarioNovo)
        {
            if (id != UsuarioNovo.UsuarioNovoId)
            {
                return BadRequest();
            }

            Newcontext.Entry(UsuarioNovo).State = EntityState.Modified;

            try
            {
                await Newcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioNovoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await Newcontext.UsuarioNovos.ToListAsync());
        }
        */
/*
[HttpPut("UpdateIcone/{id}/{idIcone}")]
public async Task<IActionResult> UpdateIconeUsuarioNovo(int id, int idIcone)
{
    var UsuarioNovo = await Newcontext.UsuarioNovos.FindAsync(id);

    if (UsuarioNovo == null)
    {
        return NotFound();
    }

    UsuarioNovo.IdIcone = idIcone;

    try
    {
        await Newcontext.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!UsuarioNovoExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    return Ok(UsuarioNovo);
}
*/
        // POST: api/UsuarioNovo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPost]
        public async Task<ActionResult<UsuarioNovo>> PostUsuarioNovo(UsuarioNovo UsuarioNovo)
        {
          if (Newcontext.UsuarioNovos == null)
          {
              return Problem("Entity set 'UsuarioNovoContext.UsuarioNovos'  is null.");
          }
            Newcontext.UsuarioNovos.Add(UsuarioNovo);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.UsuarioNovos.ToListAsync());
        }
*/
[HttpPost]
public async Task<ActionResult<UsuarioNovo>> PostUsuarioNovo(UsuarioNovo UsuarioNovo)
{
    if (Newcontext.UsuarioNovos == null)
    {
        return Problem("Entity set 'UsuarioNovoContext.UsuarioNovos' is null.");
    }

    //var UsuarioNovo = await Newcontext.UsuarioNovos.Include(u => u.Icone).FirstOrDefaultAsync(u => u.UsuarioNovoId == id);

 

    Newcontext.UsuarioNovos.Add(UsuarioNovo);
    await Newcontext.SaveChangesAsync();

    return Ok(await Newcontext.UsuarioNovos.ToListAsync());
}

/*
        // DELETE: api/UsuarioNovo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioNovo(int id)
        {
            if (Newcontext.UsuarioNovos == null)
            {
                return NotFound();
            }
            var UsuarioNovo = await Newcontext.UsuarioNovos.FindAsync(id);
            if (UsuarioNovo == null)
            {
                return NotFound();
            }

            Newcontext.UsuarioNovos.Remove(UsuarioNovo);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.UsuarioNovos.ToListAsync());
        }

        private bool UsuarioNovoExists(int id)
        {
            return (Newcontext.UsuarioNovos?.Any(e => e.UsuarioNovoId == id)).GetValueOrDefault();
        }
*/
/*
[HttpGet("icone/{id}")]
public async Task<ActionResult<UsuarioNovo>> GetUsuarioNovo2(int id)
{
    var UsuarioNovo = await Newcontext.UsuarioNovos
        .Include(u => u.Icones) // Carrega o ícone relacionado
        .FirstOrDefaultAsync(u => u.UsuarioNovoId == id);

    if (UsuarioNovo == null)
    {
        return NotFound();
    }

    return UsuarioNovo;
}
*/
/*
[HttpGet("icone/{id}")]
public async Task<ActionResult<UsuarioNovo>> GetUsuarioNovo2(int id)
{
    var UsuarioNovo = await Newcontext.UsuarioNovos
        .Include(u => u.Icone) // Carrega o ícone relacionado
        .FirstOrDefaultAsync(u => u.UsuarioNovoId == id);

    if (UsuarioNovo == null)
    {
        return NotFound();
    }

    // Verifica se o ícone está carregado corretamente
    if (UsuarioNovo.Icone != null)
    {
        // Se o ícone não for nulo, você pode acessar o UrlImagem
        string urlImagem = UsuarioNovo.Icone.Urlimagem;
    }

    return UsuarioNovo;
}
*/

        // POST: api/UsuarioNovo/Login
     // POST: api/UsuarioNovo/Login
[HttpPost("Login")]
public async Task<ActionResult<bool>> Login(UsuarioNovo UsuarioNovoLogin)
{
    if (Newcontext.UsuarioNovos == null)
    {
        return Problem("Entity set 'UsuarioNovoContext.UsuarioNovos' is null.");
    }

    try
    {
        // Verifique se o usuário com o e-mail fornecido existe no banco de dados
        var UsuarioNovo = await Newcontext.UsuarioNovos.SingleOrDefaultAsync(u => u.email == UsuarioNovoLogin.email);

        if (UsuarioNovo == null)
        {
            return NotFound("Usuário não encontrado");
        }

        // Verifique se a senha fornecida coincide com a senha armazenada no banco de dados
        if (!VerificarSenha(UsuarioNovo.senha, UsuarioNovoLogin.senha))
        {
            return BadRequest("Credenciais inválidas");
        }

        // Se as credenciais forem válidas, você pode retornar true
        return Ok(UsuarioNovo);
    }
    catch (Exception ex)
    {
        return StatusCode(500, $"Erro interno: {ex.Message}");
    }
}

private bool VerificarSenha(string senhaArmazenada, string senhaFornecida)
{
    return senhaArmazenada == senhaFornecida;
}
    }
}