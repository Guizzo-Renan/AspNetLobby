
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComentarioAPI.Models
{
  public class Comentario
  {
    public int ComentarioId { get; set; }
    public int IdUsuario { get; set; }
    public int IdQuadra { get; set; }

    [Column(TypeName ="nvarchar(300)")]
    public string ComentarioCompleto { get; set; }

  }
  public class ComentarioDTO
{
    public int ComentarioId { get; set; }
    public int IdUsuario { get; set; }
    public int IdQuadra { get; set; }
    public string ComentarioCompleto { get; set; }
    public string NomeUsuario { get; set; } // Adicione o nome do usuário aqui
}

}