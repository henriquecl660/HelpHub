using Microsoft.AspNetCore.Authentication;
using Nest;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace HelpHub.Models
{
    [Table("SOLICITACAO")]
    public class SOLICITACAO
    {
        [Key]
        public int ID { get; set; }
        [Key]
        public int PK_SOLICITACAO { get; set; }
        [Required]
        public string TITULO { get; set; }
        [Required]
        public DateTime DT_CRIACAO { get; set; }
        [Required]
        public string PERGUNTA { get; set; }
        public string DESCRICAO { get; set; }
        [Required]
        public int QTD_CURTIDAS { get; set; }
        [Required]
        public int FK_ID_SOLICITACAO_USUARIO { get; set; }
        [Required]
        public int FK_SOLICITACAO_USUARIO { get; set; }


    }
}
