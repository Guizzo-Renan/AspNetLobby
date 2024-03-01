
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeAPI.Models
{
    public class Home
    {
        [Key]
        public int idHome { get; set; }

        [Column(TypeName ="nvarchar(100)")]
        public string Quadra { get; set; } = "";

        [Column(TypeName = "nvarchar(16)")]
        public string Email { get; set; } = "";

        //mm/yy
        [Column(TypeName = "nvarchar(5)")]
        public string Telefone { get; set; } = "";

        [Column(TypeName = "nvarchar(3)")]
        public string Senha { get; set; } = "";
    }
}