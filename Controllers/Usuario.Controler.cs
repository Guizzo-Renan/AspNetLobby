using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UsuarioAPI.Models;
//using UsuarioAPI.Db;
using DataBaseAPI.Db;
//using BCrypt.Net;

namespace UsuarioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly DataBaseContext Newcontext;

        public UsuarioController(DataBaseContext context)
        {
            Newcontext = context;
        }

        // GET: api/Usuario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
          if (Newcontext.Usuarios == null)
          {
              return NotFound();
          }
            return await Newcontext.Usuarios.ToListAsync();
        }




/*
        // GET: api/Usuario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
          if (Newcontext.Usuarios == null)
          {
              return NotFound();
          }
            var Usuario = await Newcontext.Usuarios.FindAsync(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }
*/

[HttpGet("{id}")]
public async Task<ActionResult<Usuario>> GetUsuario(int id)
{
    var usuario = await Newcontext.Usuarios.Include(u => u.Icone).FirstOrDefaultAsync(u => u.UsuarioId == id);

    if (usuario == null)
    {
        return NotFound();
    }

    return usuario;
}


















/*
        [HttpGet("icone/{id}")]
public async Task<ActionResult<Usuario>> GetUsuario2(int id)
{
    var usuario = await Newcontext.Usuarios
        .Include(u => u.Icone) // Carrega o ícone relacionado
        .FirstOrDefaultAsync(u => u.UsuarioId == id);

    if (usuario == null)
    {
        return NotFound();
    }

    // Verifica se o ícone está carregado corretamente
    if (usuario.Icone != null)
    {
        // Se o ícone não for nulo, você pode acessar o UrlImagem
        string urlimagem = usuario.Icone.Urlimagem;

        // Adiciona a URL da imagem ao objeto Usuario antes de retornar
       // usuario = urlimagem; 
       //const obj = {usuario;urlimagem}
    }

    return usuario;
}
*/

        // PUT: api/Usuario/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario Usuario)
        {
            if (id != Usuario.UsuarioId)
            {
                return BadRequest();
            }

            Newcontext.Entry(Usuario).State = EntityState.Modified;

            try
            {
                await Newcontext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(await Newcontext.Usuarios.ToListAsync());
        }

[HttpPut("UpdateIcone/{id}/{idIcone}")]
public async Task<IActionResult> UpdateIconeUsuario(int id, int idIcone)
{
    var usuario = await Newcontext.Usuarios.FindAsync(id);

    if (usuario == null)
    {
        return NotFound();
    }

    usuario.IdIcone = idIcone;

    try
    {
        await Newcontext.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
        if (!UsuarioExists(id))
        {
            return NotFound();
        }
        else
        {
            throw;
        }
    }

    return Ok(usuario);
}
        // POST: api/Usuario
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
       /* [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario Usuario)
        {
          if (Newcontext.Usuarios == null)
          {
              return Problem("Entity set 'UsuarioContext.Usuarios'  is null.");
          }
            Newcontext.Usuarios.Add(Usuario);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Usuarios.ToListAsync());
        }
*/
/*
[HttpPost]
public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
{
    if (Newcontext.Usuarios == null)
    {
        return Problem("Entity set 'UsuarioContext.Usuarios' is null.");
    }

    //var usuario = await Newcontext.Usuarios.Include(u => u.Icone).FirstOrDefaultAsync(u => u.UsuarioId == id);

 

    Newcontext.Usuarios.Add(usuario);
    await Newcontext.SaveChangesAsync();

    return Ok(await Newcontext.Usuarios.ToListAsync());
}*/
[HttpPost]
public async Task<ActionResult<Usuario>> PostUsuario(Usuario novoUsuario)
{
    if (Newcontext.Usuarios == null)
    {
        return Problem("Entity set 'UsuarioContext.Usuarios' is null.");
    }

    var usuarioExistente = await Newcontext.Usuarios.FirstOrDefaultAsync(u => u.email == novoUsuario.email);

    if (usuarioExistente != null)
    {
        // Se o usuário já existe, você pode retornar um erro ou tratar de acordo com sua lógica
        return Conflict("Usuário já existe"); // 409 Conflict status code
    }

    Newcontext.Usuarios.Add(novoUsuario);
    await Newcontext.SaveChangesAsync();

    return Ok(await Newcontext.Usuarios.ToListAsync());
}

        // DELETE: api/Usuario/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            if (Newcontext.Usuarios == null)
            {
                return NotFound();
            }
            var Usuario = await Newcontext.Usuarios.FindAsync(id);
            if (Usuario == null)
            {
                return NotFound();
            }

            Newcontext.Usuarios.Remove(Usuario);
            await Newcontext.SaveChangesAsync();

            return Ok(await Newcontext.Usuarios.ToListAsync());
        }

        private bool UsuarioExists(int id)
        {
            return (Newcontext.Usuarios?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
        }

/*
[HttpGet("icone/{id}")]
public async Task<ActionResult<Usuario>> GetUsuario2(int id)
{
    var usuario = await Newcontext.Usuarios
        .Include(u => u.Icones) // Carrega o ícone relacionado
        .FirstOrDefaultAsync(u => u.UsuarioId == id);

    if (usuario == null)
    {
        return NotFound();
    }

    return usuario;
}
*/
/*
[HttpGet("icone/{id}")]
public async Task<ActionResult<Usuario>> GetUsuario2(int id)
{
    var usuario = await Newcontext.Usuarios
        .Include(u => u.Icone) // Carrega o ícone relacionado
        .FirstOrDefaultAsync(u => u.UsuarioId == id);

    if (usuario == null)
    {
        return NotFound();
    }

    // Verifica se o ícone está carregado corretamente
    if (usuario.Icone != null)
    {
        // Se o ícone não for nulo, você pode acessar o UrlImagem
        string urlImagem = usuario.Icone.Urlimagem;
    }

    return usuario;
}
*/

        // POST: api/Usuario/Login
     // POST: api/Usuario/Login
[HttpPost("Login")]
public async Task<ActionResult<bool>> Login(Usuario usuarioLogin)
{
    if (Newcontext.Usuarios == null)
    {
        return Problem("Entity set 'UsuarioContext.Usuarios' is null.");
    }

    try
    {
        // Verifique se o usuário com o e-mail fornecido existe no banco de dados
        var usuario = await Newcontext.Usuarios.SingleOrDefaultAsync(u => u.email == usuarioLogin.email);

        if (usuario == null)
        {
            return NotFound("Usuário não encontrado");
        }

        // Verifique se a senha fornecida coincide com a senha armazenada no banco de dados
        if (!VerificarSenha(usuario.senha, usuarioLogin.senha))
        {
            return BadRequest("Credenciais inválidas");
        }

        // Se as credenciais forem válidas, você pode retornar true
        return Ok(usuario);
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