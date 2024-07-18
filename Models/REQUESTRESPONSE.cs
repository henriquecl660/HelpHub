using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;

namespace HelpHub.Models
{
    public class REQUESTRESPONSE
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public int PK_RESPOSTA { get; set; }
        [Required]
        public string DESCRICAO { get; set; }
        [Required]
        public int FK_ID_RESPOSTA_SOLICITACAO { get; set; }
        [Required]
        public int FK_RESPOSTA_SOLICITACAO { get; set; }
        [Required]
        public int ID_USUARIO_RESPOSTA { get; set; }


    }
}
