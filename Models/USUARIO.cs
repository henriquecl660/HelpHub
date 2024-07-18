using Microsoft.AspNetCore.Authentication;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HelpHub.Models
{
    [Table("USUARIO")]
    public class USUARIO
    {
        [Key]
        public int ID { get; set; }
        [Key]
        public int PK_USUARIO { get; set; }
        [Required]
        public string NOME { get; set; }
        [Required]
        public string EMAIL { get;set; }
        [Required]
        public string SENHA { get; set; }
        [Required]  
        public Int16 TIPO_USUARIO { get; set; }
        [Required]
        public DateTime DT_ULTIMO_LOGIN { get; set; }
        [Required]
        public int QTDE_PERGUNTAS_ENV { get; set; }
        [Required]
        public int QTDE_RESPOSTAS { get; set; }
        [Required]
        public int CONTA_ENCERRADA { get; set; }
        [Required]
        public int FK_ID_USUARIO_DEPARTAMENTO { get; set; }
        [Required]
        public int FK_USUARIO_DEPARTAMENTO { get; set; }
    }
}
