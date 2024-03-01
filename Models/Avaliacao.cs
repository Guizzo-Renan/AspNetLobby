
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AvaliacaoAPI.Models
{
    public class Avaliacao
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdQuadra { get; set; }
        public int Nota { get; set; }
    }

}