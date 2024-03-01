using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LobbyAPI.Models
{
    public class Lobby
    {
        [Key]
        public int LobbyId { get; set; }

        [Column(TypeName ="nvarchar(20)")]
        public string Hora { get; set; }
        public int IdQuadra { get; set; }


        [ForeignKey("Jogadores")]
        public int JogadoresId { get; set; }

    }

    public class Jogador
   {
        [Key]
        public int JogadoresId { get; set; }

        public int Jogador1 { get; set; }
        public int Jogador2 { get; set; }
        public int Jogador3 { get; set; }
        public int Jogador4 { get; set; }
        public int Jogador5 { get; set; }
        public int Jogador6 { get; set; }
        public int Jogador7 { get; set; }
        public int Jogador8 { get; set; }
        public int Jogador9 { get; set; }
        public int Jogador10 { get; set; }
        public int Jogador11 { get; set; }
        public int Jogador12 { get; set; }
        public int Jogador13 { get; set; }
        public int Jogador14 { get; set; }
        public int Jogador15 { get; set; }
        public int Jogador16 { get; set; }
        public int Jogador17 { get; set; }
        public int Jogador18 { get; set; }
        public int Jogador19 { get; set; }
        public int Jogador20 { get; set; }
        public int Jogador21 { get; set; }
        public int Jogador22 { get; set; }
        public int Jogador23 { get; set; }
        public int Jogador24 { get; set; }
    

    }
}

