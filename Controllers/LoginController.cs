using HelpHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Nest;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mime;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using System.Diagnostics.Eventing.Reader;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration.UserSecrets;
using System.Linq;


namespace HelpHub.Controllers
{

    public class LoginController : Controller
    {


        private readonly IUSUARIODAL usuarioDAL;
        private readonly IREQUESTRESPONSEDAL requestResponseDAL;

        public IHttpContextAccessor _httpContextAccessor;

        public LoginController(IUSUARIODAL user, IREQUESTRESPONSEDAL uArea, IHttpContextAccessor httpContextAccessor) { 

                usuarioDAL = user;
                requestResponseDAL = uArea;
                _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run( () => View() );

        }


        // GET: ValidaLogin
        [HttpPost]
        public async Task<IActionResult> Valida(string loginOrEmail, string senha)
        {
            IEnumerable <USUARIO> listaUSUARIOs;

            listaUSUARIOs = usuarioDAL.GetUSUARIOs();

            bool containsLoginOrEmail = false;
            bool isPasswordCorret = false;

            foreach(USUARIO user in listaUSUARIOs)
            {
                if(user.EMAIL == loginOrEmail)
                {
                    containsLoginOrEmail = true;

                    if(user.SENHA == senha)
                    {

                        @_httpContextAccessor.HttpContext.Session.SetString("SessionNome", user.NOME);
                        @_httpContextAccessor.HttpContext.Session.SetString("SessionEmail",user.EMAIL);
                        @_httpContextAccessor.HttpContext.Session.SetString("SessionID", user.ID.ToString());
                        @_httpContextAccessor.HttpContext.Session.SetString("SessionTIPO_USUARIO", user.TIPO_USUARIO.ToString());

                        isPasswordCorret = true;
                    }
                }


                if (user.EMAIL == loginOrEmail || user.NOME == loginOrEmail)
                {
                    containsLoginOrEmail = true;

                    if (user.SENHA == senha)
                    {
                        isPasswordCorret = true;
                    }
                }
            }

            if(containsLoginOrEmail && isPasswordCorret){



                IEnumerable<SOLICITACAO> listaSOLICITACOEs = new List<SOLICITACAO>();

                listaSOLICITACOEs = requestResponseDAL.GetRequests().ToList();

                return await Task.Run(() => RedirectToAction("UserArea", "UserArea"));


            }
            else
            {
                ViewBag.Message = "Usuario ou senha invalidos!";
                return await Task.Run(() => View("~/Views/Login/Index.cshtml"));
         
            }

        }

    }
}
