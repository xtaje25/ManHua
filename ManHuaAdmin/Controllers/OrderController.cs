using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManHuaAdmin.Controllers
{
    public class OrderController : Controller
    {
        public ActionResult PayView()
        {
            return View();
        }

        public ActionResult CancelView()
        {
            return View();
        }
    }
}