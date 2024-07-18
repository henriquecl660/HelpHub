using HelpHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpHub.Controllers
{
    public class RequestResponseController : Controller
    {


        private readonly IREQUESTRESPONSEDAL requestResponseDAL;
        public IHttpContextAccessor _httpContextAccessor;


        public RequestResponseController(IREQUESTRESPONSEDAL rr, IHttpContextAccessor httpContextAccessor)
        {

            requestResponseDAL = rr;
            _httpContextAccessor = httpContextAccessor;
            
        }

        public async Task<IActionResult> Index()
        {

            IEnumerable<SOLICITACAO> listaSOLICITACOEs = new List<SOLICITACAO>();

            listaSOLICITACOEs = requestResponseDAL.GetRequests();


            List<SelectListItem> selectItemList = new List<SelectListItem>();

            int i = 0;
            foreach(SOLICITACAO item in listaSOLICITACOEs)
            {
                i++;

                selectItemList.Add(new SelectListItem { Value = i.ToString(), Text = item.ID + " - " + item.TITULO + " - " + item.FK_SOLICITACAO_USUARIO });
            }



            ViewBag.lstDescricaoSolicitacao = selectItemList;

            return await Task.Run(() => View());

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,PK_RESPOSTA,DESCRICAO,FK_ID_RESPOSTA_SOLICITACAO,FK_RESPOSTA_SOLICITACAO,ID_USUARIO_RESPOSTA")] REQUESTRESPONSE rr)
        {
            string usuario_sessao_id_str = @_httpContextAccessor.HttpContext.Session.GetString("SessionID");
            int usuario_sessao_id = String.IsNullOrEmpty(usuario_sessao_id_str) ? 0 : int.Parse(usuario_sessao_id_str);

            if (ModelState.IsValid)
            {
                rr.ID_USUARIO_RESPOSTA = usuario_sessao_id;

                rr.FK_RESPOSTA_SOLICITACAO++;
                rr.FK_ID_RESPOSTA_SOLICITACAO = rr.FK_RESPOSTA_SOLICITACAO;

                requestResponseDAL.AddREQUESTRESPONSE(rr);

                ViewBag.Message = "Resposta enviada com sucesso!";
            }




            return await Task.Run(() => RedirectToAction("UserArea", "UserArea"));
        }




}
}
