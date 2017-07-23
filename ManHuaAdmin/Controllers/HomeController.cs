using ManHuaAdmin.Models;
using ManHuaAdmin.Service;
using ManHuaAdmin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ManHuaAdmin.Controllers
{
    public class HomeController : Controller
    {
        private ArticleService _as = new ArticleService();
        private UserService _us = new UserService();

        /// <summary>
        /// 主页
        /// </summary>        
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 测试
        /// </summary>
        public ActionResult Test()
        {
            return View();
        }

        /// <summary>
        /// 分页
        /// </summary>        
        public ActionResult Paging()
        {
            var option = new int[] { 20, 50, 100, 200 };

            var pageNum = Request.Form["pageNum"];
            var numPerPage = Request.Form["numPerPage"];
            var title = Request.Form["title"];

            var pageIndex = 0;
            var pageSize = 0;
            var totalPage = 0;
            var totalRecord = 0;

            int.TryParse(pageNum, out pageIndex);
            int.TryParse(numPerPage, out pageSize);

            pageIndex = pageIndex == 0 ? 1 : pageIndex;
            pageSize = pageSize == 0 ? 50 : pageSize;

            var list = _as.GetArticleList(title, pageIndex, pageSize, out totalPage, out totalRecord);

            VM_Paging vm = new VM_Paging();
            vm.pageNum = pageIndex;
            vm.numPerPage = pageSize;
            vm.totalcount = totalRecord;
            vm.option = option;
            vm.title = title == null ? string.Empty : title;
            vm.list = list;

            ViewBag.pi = vm;

            return View();
        }

        /// <summary>
        /// 添加文章
        /// </summary>        
        public ActionResult Article()
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName]; // 获取cookie
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); // 解密
            var user = SerializeHelper.FromJson<Tab_User>(ticket.UserData);

            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        public ActionResult Login()
        {
            var username = Request.Form["username"];
            var password = Request.Form["password"];

            if (username != null && password != null)
            {
                var user = _us.GetUser(username, password);
                if (user != null)
                {
                    var now = DateTime.Now;

                    user.F_CreateDate = DateTime.Now;
                    string UserData = SerializeHelper.ToJson<Tab_User>(user); // 序列化用户实体

                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "user", now, now, true, UserData);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)); // 加密身份信息，保存至Cookie
                    cookie.HttpOnly = true;
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }
    }
}