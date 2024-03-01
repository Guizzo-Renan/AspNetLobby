using DataBaseAPI.Db;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AvaliacaoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoServiceAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvaliacaoController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public AvaliacaoController(DataBaseContext context)
        {
            _context = context;
        }

     [HttpGet]
        public async Task<ActionResult<IEnumerable<Avaliacao>>> GetComentarios()
        {
          if (_context.Avaliacoes == null)
          {
              return NotFound();
          }
            return await _context.Avaliacoes.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Avaliacao>> GetComentario(int id)
        {
          if (_context.Avaliacoes == null)
          {
              return NotFound();
          }
            var Avaliacao = await _context.Avaliacoes.FindAsync(id);

            if (Avaliacao == null)
            {
                return NotFound();
            }

            return Avaliacao;
        }



     //GET /api/seucontrolador/GetAvaliacaoPorIds?idQuadra=1&idUsuario=2
[HttpGet("GetAvaliacaoPorIds")]
public async Task<ActionResult<int>> GetAvaliacoesPorIds(int idQuadra, int idUsuario)
{
    // Primeiro, verifique se a confirmação existe com base nos IDs fornecidos
    var Avaliacoes = await _context.Avaliacoes
        .FirstOrDefaultAsync(c => c.IdQuadra == idQuadra && c.IdUsuario == idUsuario);

    // Se a confirmação não existe, retorne um status NotFound
    if (Avaliacoes == null)
    {
        return Ok(0);
    }

    // Caso contrário, retorne o status de confirmação (true/false)
    return Ok(Avaliacoes.Nota);
}


//GET /api/seucontrolador/GetAvaliacaoCompleta
/*
[HttpGet("GetAvaliacaoCompleta")]
public async Task<ActionResult<IEnumerable<object>>> GetAvaliacoes()
{
    var avaliacaoCompleta = await _context.Avaliacoes
        .Join(_context.Usuarios, avaliacao => avaliacao.IdUsuario, usuario => usuario.UsuarioId,
            (avaliacao, usuario) => new
            {
                Id = avaliacao.Id,
                Usuario = usuario.Nome, // Obtém o nome do usuário
                IdQuadra = avaliacao.IdQuadra,
                Nota = avaliacao.Nota
            })
        .Join(_context.Quadras, avaliacao => avaliacao.IdQuadra, quadra => quadra.QuadraId,
            (avaliacao, quadra) => new
            {
                Id = avaliacao.Id,
                Usuario = avaliacao.Usuario,
                IdQuadra = quadra.Nome, // Obtém o nome da quadra
                Nota = avaliacao.Nota
            })
        .ToListAsync();

    return Ok(avaliacaoCompleta);
}
*/
[HttpGet("GetAvaliacaoCompleta")]
public async Task<ActionResult<IEnumerable<object>>> GetAvaliacoes()
{
    var avaliacoesPorQuadra = await _context.Avaliacoes
        .Join(_context.Usuarios, avaliacao => avaliacao.IdUsuario, usuario => usuario.UsuarioId,
            (avaliacao, usuario) => new
            {
                Id = avaliacao.Id,
                Usuario = usuario.Nome, // Obtém o nome do usuário
                IdQuadra = avaliacao.IdQuadra,
                Nota = avaliacao.Nota
            })
        .Join(_context.Quadras, avaliacao => avaliacao.IdQuadra, quadra => quadra.QuadraId,
            (avaliacao, quadra) => new
            {
                Id = avaliacao.Id,
                Usuario = avaliacao.Usuario,
                IdQuadra = quadra.Nome, // Obtém o nome da quadra
                Nota = avaliacao.Nota
            })
        .GroupBy(avaliacao => avaliacao.IdQuadra) // Agrupa por IdQuadra
        .Select(grp => new
        {
            IdQuadra = grp.Key,
            MediaNota = grp.Average(avaliacao => avaliacao.Nota) // Calcula a média das notas por quadra
        })
        .ToListAsync();

    return Ok(avaliacoesPorQuadra);
}












        [HttpPost]
        public async Task<IActionResult> AdicionarAvaliacao([FromBody] Avaliacao avaliacao)
        {
            // Verifique se o usuário já avaliou a quadra
            var avaliacaoExistente = await _context.Avaliacoes
                .FirstOrDefaultAsync(a => a.IdUsuario == avaliacao.IdUsuario && a.IdQuadra == avaliacao.IdQuadra);

            if (avaliacaoExistente != null)
            {
                // Usuário já avaliou esta quadra; você pode tratar isso de acordo com sua lógica.
                return BadRequest("Você já avaliou esta quadra.");
            }

            _context.Avaliacoes.Add(avaliacao);
            await _context.SaveChangesAsync();
            return Ok("Avaliação adicionada com sucesso.");
        }

        [HttpGet("media/{idQuadra}")]
        public async Task<IActionResult> CalcularMedia(int idQuadra)
        {
            var media = await _context.Avaliacoes
                .Where(a => a.IdQuadra == idQuadra)
                .AverageAsync(a => a.Nota);

            return Ok(media);
        }
    }
}
