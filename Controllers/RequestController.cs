using HelpHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System;
using System.Threading.Tasks;

namespace HelpHub.Controllers
{
    public class RequestController : Controller
    {


        private readonly ISOLICITACAODAL solicitacaoDAL;

        IHttpContextAccessor httpContextAccessor;

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());

        }

        public RequestController(ISOLICITACAODAL soli, IHttpContextAccessor httpContextAccessor)
        {

            solicitacaoDAL = soli;
            this.httpContextAccessor = httpContextAccessor;
        }


        public async Task<IActionResult> Create([Bind("ID,PK_SOLICITACAO,TITULO,DT_CRIACAO,PERGUNTA,DESCRICAO,QTE_CURTIDAS,FK_ID_SOLICITACAO_USUARIO,FK_SOLICITACAO_USUARIO")] SOLICITACAO soli)
        {
            if (ModelState.IsValid)
            {


                string usuario_sessao_id_str = httpContextAccessor.HttpContext.Session.GetString("SessionID");
                int usuario_sessao_id = String.IsNullOrEmpty(usuario_sessao_id_str) ? 0 : int.Parse(usuario_sessao_id_str);

                soli.FK_ID_SOLICITACAO_USUARIO = usuario_sessao_id;
                soli.FK_SOLICITACAO_USUARIO = usuario_sessao_id; 

                soli.DT_CRIACAO = System.DateTime.Now;

                solicitacaoDAL.AddSOLICITACAO(soli);
                ViewBag.Message = "Solicitacao cadastrada com sucesso!";
            }





            return await Task.Run(() => RedirectToAction("UserArea", "UserArea"));

        }

    }
}
