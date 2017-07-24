using ManHuaAdmin.Models;
using ManHuaAdmin.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ManHuaAdmin.Service
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 重写时，提供一个入口点用于进行自定义授权检查。
        /// </summary>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie authCookie = httpContext.Request.Cookies["a"]; // 获取cookie
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); // 解密
                var user = SerializeHelper.FromJson<Tab_User>(ticket.UserData);
                var u = new UserService().GetUser(user.F_Name, user.F_Password);
                if (u != null)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 处理未能授权的 HTTP 请求。
        /// </summary>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Home/Login");
        }
    }

    public class CustomAjaxAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        /// 重写时，提供一个入口点用于进行自定义授权检查。
        /// </summary>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            HttpCookie authCookie = httpContext.Request.Cookies["a"]; // 获取cookie
            if (authCookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value); // 解密
                var user = SerializeHelper.FromJson<Tab_User>(ticket.UserData);
                var u = new UserService().GetUser(user.F_Name, user.F_Password);
                if (u != null)
                    return true;
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 处理未能授权的 HTTP 请求。
        /// </summary>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Home/AjaxLogin");
        }
    }
}