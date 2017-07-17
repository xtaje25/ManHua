using ManHuaAdmin.Models;
using ManHuaAdmin.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ManHuaAdmin.Controllers
{
    public class HomeController : Controller
    {
        private ArticleService _as = new ArticleService();

        /// <summary>
        /// 主页
        /// </summary>        
        public ActionResult Index()
        {
            return View();
        }

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
            vm.list = list;

            ViewBag.pi = vm;

            return View();
        }
    }
}