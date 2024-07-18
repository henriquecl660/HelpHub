using HelpHub.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpHub.Controllers
{
    public class UserAreaController : Controller
    {
        private readonly IREQUESTRESPONSEDAL requestResponseDAL;



        public UserAreaController(IREQUESTRESPONSEDAL uArea)
        {

            requestResponseDAL = uArea;

        }

        public async Task<IActionResult> UserArea()
        {

            IEnumerable<SOLICITACAO> listaSOLICITACOEs = new List<SOLICITACAO>();

            listaSOLICITACOEs = requestResponseDAL.GetRequests().ToList();

            return await Task.Run(() => View(listaSOLICITACOEs));
        }


        public async Task<IActionResult> Requests(int? ID)
        {

            if (ID == null)
            {
                return NotFound();
            }

            IEnumerable<REQUESTRESPONSE> lstREQUESTRESPONSE = requestResponseDAL.GetRequestsByID(ID);

            return await Task.Run(() => View("~/Views/UserArea/Requests.cshtml", lstREQUESTRESPONSE));
        }


        public async Task<IActionResult> Logout()
        {



            @HttpContext.Session.SetString("SessionNome", "0");
            @HttpContext.Session.SetString("SessionEmail", "vazio");
            @HttpContext.Session.SetString("SessionID", "0");
            @HttpContext.Session.SetString("SessionTIPO_USUARIO", "0");

            return await Task.Run(() => RedirectToAction("Index", "Home"));




        }

    }
}
