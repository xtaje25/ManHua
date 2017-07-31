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
using System.Web.Security;

namespace ManHuaAdmin.Controllers
{
    public class MHController : Controller
    {
        private MHCatalogService _ms = new MHCatalogService();
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

            var list = _ms.GetMHList(pageIndex, pageSize, out totalPage, out totalRecord);

            VM_Page<Tab_MHCatalog> vm = new VM_Page<Tab_MHCatalog>();
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
            ViewBag.list = _gzhs.GetGZHList();

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Add()
        {
            var name = Request.Form["name"];
            var id = Request.Form["gid"];

            if (name == null || name.Length < 1 || name.Length > 50)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "长度必须大于1个字符小于50字符" });
            }

            var gid = 0;
            if (!int.TryParse(id, out gid) || gid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "公众号ID不存在" });
            }

            HttpCookie authCookie = Request.Cookies["a"]; // 获取cookie
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); // 解密
            var user = SerializeHelper.FromJson<Tab_User>(ticket.UserData);

            Tab_MHCatalog m = new Tab_MHCatalog();
            m.F_Catalog = name;
            m.F_GZHId = gid;
            m.F_CreateUser = user.F_Id;

            int i = _ms.AddMH(m); // 0：没执行；1：执行成功；2：漫画目录名称重复；

            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else if (i == 2)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "漫画目录名称重复" });
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

            var mhid = 0;
            int.TryParse(id, out mhid);

            ViewBag.g = null;
            ViewBag.list = _gzhs.GetGZHList();

            if (mhid > 0)
            {
                var m = _ms.GetMH(mhid);
                ViewBag.m = m;
            }

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Edit()
        {
            var name = Request.Form["name"];
            var id1 = Request.Form["gid"];
            var id2 = Request.Form["id"];

            if (name == null || name.Length < 1 || name.Length > 50)
            {
                return View(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "长度必须大于1个字符小于50字符" });
            }

            var gid = 0;
            if (!int.TryParse(id1, out gid) || gid == 0)
            {
                return View(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "公众号不存在" });
            }

            var id = 0;
            if (!int.TryParse(id2, out id) || id == 0)
            {
                return View(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "漫画不存在" });
            }

            var logo = "";
            if (Request.Files.Count > 0)
            {
                var str = Tools.DateTimeToTimeStamp(DateTime.Now);
                var lg = str.Substring(0, str.IndexOf('.'));
                var key = "MH/" + gid + "/" + id + "/" + lg + ".jpg";

                FormUploader fu = new FormUploader();
                HttpResult result = fu.UploadStream(Request.Files[0].InputStream, key, QN.GetUploadToken(QN.BUCKET, key));
                if (result.Code == 200)
                {
                    logo = QN.IMGSRC + "/" + key;
                }
            }

            Tab_MHCatalog m = new Tab_MHCatalog();
            m.F_Catalog = name;
            m.F_GZHId = gid;
            m.F_Logo = logo != "" ? logo : null;
            m.F_Id = id;

            int i = _ms.UpdateMH(m);

            if (i == 1)
            {
                return View(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else
            {
                return View(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "失败" });
            }
        }
    }
}