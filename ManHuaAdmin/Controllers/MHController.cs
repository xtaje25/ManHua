using ManHuaAdmin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManHuaAdmin.Controllers
{
    public class MHController : Controller
    {
        [CustomAuthorize]
        [CustomLogin]
        public ActionResult Catalog()
        {
            return View();
        }
    }
}