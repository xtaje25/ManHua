using ManHuaAdmin.Models;
using ManHuaAdmin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManHuaAdmin.Controllers
{
    public class GZHController : Controller
    {
        private GongZhongHaoService _gzhs = new GongZhongHaoService();

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Catalog()
        {
            var option = new int[] { 20, 50, 100, 200 };

            var pageNum = Request.Form["pageNum"];
            var numPerPage = Request.Form["numPerPage"];

            var pageIndex = 0;
            var pageSize = 0;
            var totalPage = 0;
            var totalRecord = 0;

            int.TryParse(pageNum, out pageIndex);
            int.TryParse(numPerPage, out pageSize);

            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 50 : pageSize;

            var list = _gzhs.GetGZHList(pageIndex, pageSize, out totalPage, out totalRecord);

            VM_Catalog vm = new VM_Catalog();
            vm.pageNum = pageIndex;
            vm.numPerPage = pageSize;
            vm.totalcount = totalRecord;
            vm.option = option;
            vm.list = list;

            ViewBag.ca = vm;

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Info()
        {
            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult AddView()
        {
            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Add()
        {
            var name = Request.Form["name"];
            var wxin = Request.Form["wxin"];

            if (name == null || name.Length < 1 || name.Length > 200)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "长度必须大于1个字符小于200字符" });
            }

            if (wxin == null || wxin.Length < 1 || wxin.Length > 200)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "长度必须大于1个字符小于200字符" });
            }

            Tab_GongZhongHao m = new Tab_GongZhongHao();
            m.F_GZHName = name;
            m.F_WXName = wxin;

            int i = _gzhs.AddGZH(m); // 0：没执行；1：执行成功；2：公号名称重复；3：关联微信号重复；

            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else if (i == 2)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "公号名称重复" });
            }
            else if (i == 3)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "关联微信号重复" });
            }
            else
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "失败" });
            }
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult EditView()
        {
            var id = Request.QueryString["id"];

            var gid = 0;
            int.TryParse(id, out gid);

            if (gid > 0)
            {
                var g = _gzhs.GetGZH(gid);
            }

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Edit()
        {
            return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "失败" });
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Delete()
        {
            return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "失败" });
        }
    }
}