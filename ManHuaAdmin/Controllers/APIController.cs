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

        public ActionResult GetInfo()
        {
            var id = Request.QueryString["id"];

            var mhid = 0;
            int.TryParse(id, out mhid);
            mhid = mhid == 0 ? 1 : mhid;

            var mod = _mcs.GetAPIMH(mhid);
            mod.f_logo = QN.IMGSRC + "/" + mod.f_logo + "-1x1.jpg";

            var sort = _mis.GetLastSort(mhid);
            mod.sort = sort;

            ViewModels_obj vm = new ViewModels_obj();
            vm.status = 1;
            vm.data = mod;

            return Json(vm, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetImgInfo()
        {
            ViewModels_obj vm = new ViewModels_obj();

            var id = Request.QueryString["id"];
            var st = Request.QueryString["st"];

            var mhid = 0;
            var sort = 0;

            int.TryParse(id, out mhid);
            int.TryParse(st, out sort);

            if (mhid == 0 || sort == 0)
            {
                vm.msg = "参数不正确";
                vm.data = new { };
                return Json(vm, JsonRequestBehavior.AllowGet);
            }

            mhid = mhid == 0 ? 1 : mhid;
            sort = sort == 0 ? 1 : sort;

            var img = _mis.GetMH(mhid, sort);

            if (img != null)
            {
                img.f_img = QN.IMGSRC + "/" + img.f_img + "-1x1.jpg";
            }
            else
            {
                vm.msg = "章节不存在";
                vm.data = new { };
                return Json(vm, JsonRequestBehavior.AllowGet);
            }

            var list = _mis.GetMHList(mhid);

            var m1 = list.Find(x => x.f_sort == sort);

            if (m1.sort == 1)
            {
                img.previous = 0;
            }
            else
            {
                var m2 = list.Find(x => x.sort == m1.sort - 1);
                img.previous = m2 != null ? m2.f_sort : 0;
            }

            if (m1.sort == list.Count)
            {
                img.next = 0;
            }
            else
            {
                var m2 = list.Find(x => x.sort == m1.sort + 1);
                img.next = m2 != null ? m2.f_sort : 0;
            }

            vm.status = img == null ? 0 : 1;
            vm.msg = img == null ? "漫画没找到" : "";
            vm.data = img;

            return Json(vm, JsonRequestBehavior.AllowGet);
        }
    }
}