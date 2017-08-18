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
    public class UserController : Controller
    {
        private GongZhongHaoService _gzhs = new GongZhongHaoService();
        private UserService _us = new UserService();

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult ListView()
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

            var list = _us.GetUserList(pageIndex, pageSize, out totalPage, out totalRecord);

            VM_Page<Tab_User> vm = new VM_Page<Tab_User>();
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
            var id = Request.Form["gid"];
            var name = Request.Form["name"];

            if (name == null || name.Length < 1 || name.Length > 50)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "长度必须大于1个字符小于50字符" });
            }

            var gid = 0;
            if (!int.TryParse(id, out gid) || gid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "公众号ID不存在" });
            }

            Tab_User m = new Tab_User();
            m.F_Name = name;
            m.F_Password = Tools.MD5Encrypt32("123456");
            m.GZHId = gid;
            m.RoleId = 2; // 公众号管理员

            var i = _us.AddUser(m);

            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else if (i == 2)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "登录名已存在" });
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
            var a = Request.QueryString["id"]; // 账号id

            var uid = 0;

            if (!int.TryParse(a, out uid) || uid == 0)
            {
                return View();
            }

            ViewBag.list = _gzhs.GetGZHList();
            ViewBag.id = _us.GetUserGZH(uid);

            return View();
        }

        [CustomAuthorize]
        [CustomAjaxLogin]
        public ActionResult Edit()
        {
            var a = Request.Form["pwd"];
            var b = Request.Form["uid"];

            var pwd = 0;
            var uid = 0;
            if (!int.TryParse(a, out pwd) || pwd == 0)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "什么都没做!" });
            }

            if (!int.TryParse(b, out uid) || uid == 0)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "账号不存在" });
            }

            int i = _us.ResetPassword(uid);

            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
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
            var a = Request.QueryString["id"];

            var uid = 0;
            if (!int.TryParse(a, out uid) || uid == 0)
            {
                return Json(new DWZJson() { statusCode = (int)DWZStatusCode.ERROR, message = "用户不存在" });
            }

            int i = _us.DeleteUser(uid);

            if (i == 1)
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.OK, message = "成功" });
            }
            else
            {
                return Json(new DWZJson { statusCode = (int)DWZStatusCode.ERROR, message = "失败" });
            }
        }
    }
}