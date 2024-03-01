using Microsoft.EntityFrameworkCore;
using QuadraAPI.Models;
using UsuarioAPI.Models;
using LobbyAPI.Models;
using AvaliacaoAPI.Models;
using ConfirmacaoAPI.Models;
using ComentarioAPI.Models;
using UsuarioNovoAPI.Models;


namespace DataBaseAPI.Db
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Quadra> Quadras { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<UsuarioNovo> UsuarioNovos { get; set; }

        public DbSet<Lobby> Lobbys { get; set; }
        
        public DbSet<Jogador> Jogadores { get; set; }

        public DbSet<Avaliacao> Avaliacoes { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<Confirmacao> Confirmacoes { get; set; }

     //   public DbSet<Icone> Icones { get; set; }


    }
}