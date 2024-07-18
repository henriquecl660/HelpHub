using HelpHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HelpHub.Controllers
{
    public class RegisterController : Controller
    {


        private readonly IUSUARIODAL usuarioDAL;
        private readonly IREQUESTRESPONSEDAL requestRESPONSEDAL;
        public IHttpContextAccessor _httpContextAccessor;

        public RegisterController(IUSUARIODAL user, IREQUESTRESPONSEDAL rr, IHttpContextAccessor httpContextAccessor)
        {

            usuarioDAL = user;
            this.requestRESPONSEDAL = rr;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => View());

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PK_USUARIO,NOME,EMAIL,SENHA,TIPO_USUARIO,DT_ULTIMO_LOGIN,QTDE_PERGUNTAS_ENV,QTDE_RESPOSTAS,CONTA_ENCERRADA,FK_ID_USUARIO_DEPARMENTO,FK_USUARIO_DEPARTAMENTO")] USUARIO user)
        {
   
            if (ModelState.IsValid)
            {


                user.FK_USUARIO_DEPARTAMENTO++;
                user.FK_ID_USUARIO_DEPARTAMENTO = user.FK_USUARIO_DEPARTAMENTO;
                user.DT_ULTIMO_LOGIN = System.DateTime.Now;
         
                usuarioDAL.AddUSUARIO(user);  
            }


            ViewBag.Message = "Cadastro realizado com sucesso!";


            IEnumerable<USUARIO> listaUSUARIOs;

            listaUSUARIOs = usuarioDAL.GetUSUARIOs();

        
            @_httpContextAccessor.HttpContext.Session.SetString("SessionNome", user.NOME);
            @_httpContextAccessor.HttpContext.Session.SetString("SessionEmail", user.EMAIL);
            @_httpContextAccessor.HttpContext.Session.SetString("SessionID",    (listaUSUARIOs.Count() + 1).ToString() );
            @_httpContextAccessor.HttpContext.Session.SetString("SessionTIPO_USUARIO", user.TIPO_USUARIO.ToString());

            IEnumerable<SOLICITACAO> listaSOLICITACOEs = new List<SOLICITACAO>();

            listaSOLICITACOEs = requestRESPONSEDAL.GetRequests().ToList();

            return await Task.Run(() => RedirectToAction("UserArea", "UserArea"));

        }
    }
}
