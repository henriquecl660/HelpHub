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
    public class AdmManagementController : Controller
    {


        private readonly IUSUARIODAL usuarioDAL;

        public AdmManagementController(IUSUARIODAL user)
        {

            usuarioDAL = user;
        }


        public async Task<IActionResult> Index()
        {
            IEnumerable<USUARIO> listaUSUARIOs;

            listaUSUARIOs = usuarioDAL.GetUSUARIOs().ToList();


            return await Task.Run(() => View(listaUSUARIOs));
     
        }

    }
}
