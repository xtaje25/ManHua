using ManHuaAdmin.Models;
using ManHuaAdmin.Service;
using ManHuaAdmin.Utility;
using Qiniu.Http;
using Qiniu.IO;
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
        public ActionResult CatalogView()
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

            VM_Page<Tab_GongZhongHao> vm = new VM_Page<Tab_GongZhongHao>();
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
        public ActionResult InfoView()
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

            VM_Page<Tab_GongZhongHao> vm = new VM_Page<Tab_GongZhongHao>();
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

            ViewBag.g = null;

            if (gid > 0)
            {
                var g = _gzhs.GetGZH(gid);
                ViewBag.g = g;
            }

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Edit()
        {
            var name = Request.Form["name"];
            var wxin = Request.Form["wxin"];
            var id = Request.Form["id"];

            var gid = 0;
            if (!int.TryParse(id, out gid) || gid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "公众号不存在" });
            }

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
            m.F_Id = gid;

            int i = _gzhs.UpdateGZH(m); // 0：没执行；1：执行成功；2：公号名称重复；3：关联微信号重复；

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
        public ActionResult Delete()
        {
            var id = Request.QueryString["id"];

            var gid = 0;
            if (!int.TryParse(id, out gid) || gid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "公众号不存在" });
            }

            int i = _gzhs.DeleteGZH(gid);
            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "公众号不存在" });
            }
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult InfoEditView()
        {
            var id = Request.QueryString["id"];

            var gid = 0;
            int.TryParse(id, out gid);

            ViewBag.g = null;

            if (gid > 0)
            {
                var g = _gzhs.GetGZH(gid);
                ViewBag.g = g;
            }

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult InfoEdit()
        {
            var id = Request.Form["id"];
            var about = Request.Form["about"];

            var gid = 0;
            if (!int.TryParse(id, out gid) || gid == 0)
            {
                // IE浏览器对非ajax请求Content-Type:是json的不友好所以使用View而非Json
                return View(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "公号不存在" });
            }

            if (about != null && about.Length > 4000)
            {
                return View(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "公号简介长度必须小于4000字符" });
            }

            var logo = "";
            if (Request.Files.Count > 0
                && Request.Files[0].ContentLength > 0
                && new string[] { ".gif", ".jpeg", ".jpg", ".png" }.Contains(System.IO.Path.GetExtension(Request.Files[0].FileName.ToLower())))
            {

                var key = QN.GZHLogo(gid);

                FormUploader fu = new FormUploader();
                HttpResult result = fu.UploadStream(Request.Files[0].InputStream, key, QN.GetUploadToken(QN.BUCKET, key));
                if (result.Code == 200)
                {
                    logo = key;
                }
            }

            Tab_GongZhongHao g = new Tab_GongZhongHao();
            g.F_About = (about != null && about.Length > 0) ? about : null;
            g.F_Logo = logo != "" ? logo : null;
            g.F_Id = gid;

            var i = _gzhs.UpdateGZHInfo(g);

            if (i == 1)
            {
                return View(new DWZJson() { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else
            {
                return View(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "失败" });
            }
        }
    }
}