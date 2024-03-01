
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConfirmacaoAPI.Models
{
  public class Confirmacao
{
    public int ConfirmacaoId { get; set; }
    public int IdLobby { get; set; }
    public int IdUsuario { get; set; }
    public bool Confirmado { get; set; }
}
}