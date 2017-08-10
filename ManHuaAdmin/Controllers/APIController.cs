using ManHuaAdmin.Models;
using ManHuaAdmin.Service;
using ManHuaAdmin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManHuaAdmin.Controllers
{
    public class APIController : Controller
    {
        private MHCatalogService _mcs = new MHCatalogService();
        private MHImgService _mis = new MHImgService();

        public ActionResult Index()
        {
            var mlist = _mcs.GetMHList();

            mlist.ForEach(x =>
            {
                if (x.f_logo == null)
                    x.f_logo = QN.IMGSRC + "/" + QN.DEFAULTSRC + "-1x1.jpg";
                else
                    x.f_logo = QN.IMGSRC + "/" + x.f_logo + "-1x1.jpg";
            });

            ViewModels<VM_Tab_MHCatalog> vm = new ViewModels<VM_Tab_MHCatalog>();
            vm.status = 1;
            vm.data = mlist;

            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetMHDir()
        {
            var id = Request.QueryString["id"];

            var mhid = 0;
            int.TryParse(id, out mhid);
            mhid = mhid == 0 ? 1 : mhid;

            var mlist = _mis.GetImgList(mhid);

            ViewModels<VM_Tab_MHImg> vm = new ViewModels<VM_Tab_MHImg>();
            vm.status = 1;
            vm.data = mlist;

            return Json(vm, JsonRequestBehavior.AllowGet);
        }
    }
}